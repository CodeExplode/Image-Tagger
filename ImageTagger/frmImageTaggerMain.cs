using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Linq;


// TODO
// + searches with exclusions, e.g. SourceName, -SourceName_ to find images with the source but not a character name (could have a negative filter)
// + searching by image properties such as resolution (not possible currently unless can read that quickly on import, maybe can set selection then too)
//   https://stackoverflow.com/a/112711   https://stackoverflow.com/a/9687096   https://stackoverflow.com/a/111349  https://gist.github.com/dejanstojanovic/c5df7310174b570c16bc
// + ideally would only write changes/additions to the database rather than the whole file (not such an issue if not auto-saving)
// + group images by directory in database, and load per directory (save a large amount of text space and make it easier to change a directory)
//      could also have tags per directory, and select all in a directory easily
// + duplicate detector
// + maybe a validate button which will compile a list of all images which no longer exist, and give an option to clear them or potentially
//   relocate them (scanning in existing directories). Could cache some image info for that and duplicate detection, like file size, resolution
// + Add gif playback https://stackoverflow.com/a/13486374
// + Add webp support
// + maybe shouldn't add new images to database automatically, and gallery should hold a cache of unsaved images. Maybe have an 'Add to Database (count)' button
// + allow minimum zoom to at least be the original size of the picture, for small pictures
// + maybe add an auto-zoom checkbox to settings
// + undo/redo on selection sizing

namespace ImageTagger
{
    public partial class frmImageTaggerMain : Form
    {
        ImageTaggerDatabase database;
        Gallery gallery;
        bool inBatchMode;

        Timer timerSlideshow;
        Timer timerFilterCooldown;

        RectangleF imageBounds = new RectangleF();
        bool cursorOnImage; // a hack to get around there being no scroll events on forms
        Point lastCursor = new Point(0, 0);
        Point mouseDownAt = new Point(0, 0);
        PointF pan = new PointF(0f, 0f); // focused point on image, as percentage offset from centre
        float zoom = 1.0f;
        Point zoomCursor = new Point(int.MinValue, 0); // record cursor pos when setting a zoom target so know if it's moved
        PointF zoomTarget = new PointF(0, 0); // zoom target as image width/height percent, will move pan towards a little with each zoom scroll

        enum TrainingAreaDragMode { none, centre, left, right, top, bottom, cornerTL, cornerTR, cornerBL, cornerBR };
        TrainingAreaDragMode trainingDragMode = TrainingAreaDragMode.none;
        int[] trainingDragBounds = new int[4]; // rather than try to add mouse delta each motion, do a delta from the original size

        public frmImageTaggerMain()
        {
            InitializeComponent();
        }

        private void form_Load(object sender, EventArgs e)
        {
            cmbInterpolationModes.DataSource = new BindingList<InterpolationMode>() {
                InterpolationMode.NearestNeighbor,
                InterpolationMode.Bilinear,
                InterpolationMode.Bicubic,
                InterpolationMode.HighQualityBilinear,
                InterpolationMode.HighQualityBicubic
            };

            timerSlideshow = new Timer();
            timerSlideshow.Tick += new System.EventHandler(this.timerSlideshow_Tick);

            timerFilterCooldown = new Timer();
            timerFilterCooldown.Tick += new System.EventHandler(this.timerFilterCooldown_Tick);
            timerFilterCooldown.Interval = 1000;

            txtDatabase.Text = "./TagsDatabase.txt";

            database = new ImageTaggerDatabase();
            database.Load(txtDatabase.Text, false);
            gallery = new Gallery(database);

            SetBatchMode(false);
            ClearFocus();
        }


        #region DRAG & DROP

        private void form_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void form_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var filenames = data as string[];
                List<TaggedImage> images = database.GetImageInfo(filenames, true);
                if (images.Count> 0)
                {
                    txtFilter.Clear();
                    bool isBatch = images.Count > 1 || inBatchMode;
                    bool clearGallery = !isBatch || !inBatchMode;
                    AddToGallery(images, clearGallery, isBatch, "drop");
                }
                RefreshDatabaseCountLabel();
            }
        }

        #endregion

        
        #region GALLERY

        private void AddToGallery(List<TaggedImage> images, bool clearGallery, bool isBatch, string source)
        {
            gallery.AddImages(images, clearGallery);
            SetBatchMode(isBatch);
            if (source != "filter")
                ClearFocus();
            lblFilter.Text = "Filter" + (gallery.images.Count > 0 ? $"({gallery.images.Count})" : "");
            gallery.index = (images.Count == 0 ? 0 : gallery.images.IndexOf(images[0]));
            ImageChanged(source == "drop");
        }

        private void ScrollGallery(bool toRight)
        {
            int gallerySize = gallery.images.Count;

            if (gallerySize < 2) return;

            gallery.index += (toRight ? 1 : -1);

            if (gallery.index < 0)
                gallery.index = gallerySize - 1;
            else if (gallery.index >= gallerySize)
                gallery.index = 0;

            ImageChanged(false);

            // allow clicks and key presses in fullscreen to scroll the gallery
            if (timerSlideshow.Enabled)
            {
                timerSlideshow.Stop();
                timerSlideshow.Start();
            }
        }

        private void ImageChanged(bool fromDrop)
        {
            this.zoom = 1f;
            this.pan.X = 0;
            this.pan.Y = 0;

            if (gallery.images.Count == 0)
            {
                this.Text = "Image Tagger";
                txtTags.Text = "";
                gridTrainingSources.Rows.Clear();
            }
            else
            {
                //Image imageData = gallery.CurrentImageData();
                this.Text = Path.GetFileName(gallery.CurrentImage().filepath); // + $" ({imageData.Size.Width}x{imageData.Size.Height})";
                TrainingData_PopulateGrid(false);
                if (!chkBatchTag.Checked || fromDrop)
                    DisplayTags();
            }

            Repaint();
        }

        private void DoPan(float deltaX, float deltaY, bool percentDelta)
        {
            if (!percentDelta)
            {
                deltaX = deltaX / imageBounds.Width;
                deltaY = deltaY / imageBounds.Height;
            }

            pan.X += deltaX;
            pan.Y += deltaY;

            Repaint();
        }

        private void Repaint()
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            Image image = gallery.CurrentImageData();

            if (image != null)
            {
                float scalarX = DisplayRectangle.Width / (float)image.Width;
                float scalarY = DisplayRectangle.Height / (float)image.Height;
                imageBounds.Width = (scalarX < scalarY ? DisplayRectangle.Width : image.Width * scalarY) * zoom;
                imageBounds.Height = (scalarY < scalarX ? DisplayRectangle.Height : image.Height * scalarX) * zoom;
                imageBounds.X = DisplayRectangle.Width / 2f - imageBounds.Width / 2f;
                imageBounds.Y = DisplayRectangle.Height / 2f - imageBounds.Height / 2f;

                ConstrainPan();
                imageBounds.X += pan.X * imageBounds.Width;
                imageBounds.Y += pan.Y * imageBounds.Height;

                paintEventArgs.Graphics.InterpolationMode = (InterpolationMode)cmbInterpolationModes.SelectedItem;
                paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode.Half; // needed for nearest neighbor, left on for all for consistent positioning

                // these don't seem to help with slow bicubic draw speed when zoomed in
                // might need to try instead drawing only correct part of image
                //paintEventArgs.Graphics.Clip = new Region(new Rectangle(0, 0, DisplayRectangle.Width, DisplayRectangle.Height));
                //paintEventArgs.Graphics.SetClip(DisplayRectangle);

                paintEventArgs.Graphics.DrawImage(image, imageBounds.X, imageBounds.Y, imageBounds.Width, imageBounds.Height);

                // if the training data grid is visible, draw the bounds for the currenty selected row
                float[] trainingBounds = DrawableTrainingBounds(image);

                if (trainingBounds.Length == 4)
                {
                    Pen glow = new Pen(Color.FromArgb(255/4, 255, 255, 255), 3);
                    Pen stroke = new Pen(Color.Red, 1);
                    //paintEventArgs.Graphics.DrawRectangle(glow, trainingBounds[0], trainingBounds[1], trainingBounds[2], trainingBounds[3]); // seems kind of offputting, need to work on it
                    paintEventArgs.Graphics.DrawRectangle(stroke, trainingBounds[0], trainingBounds[1], trainingBounds[2], trainingBounds[3]);
                    
                    // reply on https://stackoverflow.com/q/11238628 claims pens need to be disposed of
                    glow.Dispose();
                    stroke.Dispose();
                }
            }

            base.OnPaint(paintEventArgs);
        }

        private void ConstrainPan()
        {
            if (imageBounds.Width <= DisplayRectangle.Width) pan.X = 0;
            else
            {
                float diffLeft = imageBounds.X + pan.X * imageBounds.Width;
                float diffRight = DisplayRectangle.Width - (imageBounds.X + (1 + pan.X) * imageBounds.Width);

                if (pnlLeft.Visible) diffLeft -= pnlLeft.Size.Width; // allow tolerance for panning to reveal picture hidden under panel

                if (diffLeft > 0) pan.X -= diffLeft / imageBounds.Width;
                if (diffRight > 0) pan.X += diffRight / imageBounds.Width;
            }

            if (imageBounds.Height <= DisplayRectangle.Height) pan.Y = 0;
            else
            {
                float diffTop = imageBounds.Y + pan.Y * imageBounds.Height;
                float diffBot = DisplayRectangle.Height - (imageBounds.Y + (1 + pan.Y) * imageBounds.Height);

                if (diffTop > 0) pan.Y -= diffTop / imageBounds.Height;
                if (diffBot > 0) pan.Y += diffBot / imageBounds.Height;
            }
        }
        
        private void cmbInterpolationModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repaint();
        }

        private PointF PointToImage(Point point, bool returnPercent)
        {
            PointF imgPoint = new PointF();

            imgPoint.X = (point.X - imageBounds.X) / imageBounds.Width;
            imgPoint.Y = (point.Y - imageBounds.Y) / imageBounds.Height;

            if (!returnPercent)
            {
                Image image = gallery.CurrentImageData();

                if (image != null)
                {
                    imgPoint.X *= image.Width;
                    imgPoint.Y *= image.Height;
                }
            }

            return imgPoint;
        }

        private void ToggleSlideshow()
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable && this.gallery.images.Count > 0)
            {
                ClearFocus();

                btnChangeBackground.Tag = this.BackColor;
                this.BackColor = Color.Black;
                this.FormBorderStyle = FormBorderStyle.None;
                btnCollapseSidePanel.Visible = false;
                btnCollapseSidePanel.Tag = pnlLeft.Visible;
                pnlLeft.Visible = false;

                // https://stackoverflow.com/a/8868761
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;

                timerSlideshow.Interval = (int)(numScrollSpeed.Value * 1000);
                timerSlideshow.Enabled = true;
            }
            else if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.BackColor = (Color)btnChangeBackground.Tag;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                btnCollapseSidePanel.Visible = true;
                pnlLeft.Visible = (bool)btnCollapseSidePanel.Tag;

                // https://stackoverflow.com/a/8868761
                // could cache previous size/window state if not maximized, but don't want to create more vars and not really a valid tag for dodgy storage
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                timerSlideshow.Enabled = false;
            }
        }


        private void timerSlideshow_Tick(object sender, EventArgs e)
        {
            ScrollGallery(true);
        }


        #endregion


        #region INPUTS

        private bool IsInputControlFocused()
        {
            Control focusedControl = Util.FindFocusedControl(this);
            return (focusedControl is TextBox || focusedControl is RichTextBox || focusedControl is DataGridView);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool inputFocused = IsInputControlFocused();

            if (!inputFocused)
            {
                if (keyData == Keys.Left || keyData == Keys.Right)
                {
                    ScrollGallery(keyData == Keys.Right);
                    return true;
                }

                if (keyData == Keys.Space)
                    ToggleSlideshow();

                // should really have a flag for in slideshow rather than check this way
                if (keyData == Keys.Escape && this.FormBorderStyle == FormBorderStyle.None)
                    ToggleSlideshow();
            }

            return base.ProcessCmdKey(ref msg, keyData); // https://stackoverflow.com/a/34168026
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownAt = e.Location;

            TrainingAreaDragMode mode = CheckTrainingBoxCursor(e.Location.X, e.Location.Y);
            if (mode != TrainingAreaDragMode.none)
                StartTrainingDrag(mode);
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (trainingDragMode == TrainingAreaDragMode.none)
                    DoPan(e.Location.X - lastCursor.X, e.Location.Y - lastCursor.Y, false);
                else {
                    bool altKey = (Control.ModifierKeys & Keys.Alt) != 0; // https://stackoverflow.com/a/13941232
                    DragTrainingBounds(e.Location.X - mouseDownAt.X, e.Location.Y - mouseDownAt.Y, !altKey);
                }
            }
            else
            {
                Cursor cursor = Cursors.Default;

                TrainingAreaDragMode mode = CheckTrainingBoxCursor(e.Location.X, e.Location.Y);

                if (mode == TrainingAreaDragMode.left || mode == TrainingAreaDragMode.right) cursor = Cursors.SizeWE;
                else if (mode == TrainingAreaDragMode.top || mode == TrainingAreaDragMode.bottom) cursor = Cursors.SizeNS;
                else if (mode == TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerBR) cursor = Cursors.SizeNWSE;
                else if (mode == TrainingAreaDragMode.cornerTR || mode == TrainingAreaDragMode.cornerBL) cursor = Cursors.SizeNESW;
                //else if (mode == TrainingAreaDragMode.centre) cursor = Cursors.SizeAll; // seems obstructive

                this.Cursor = cursor;
            }

            lastCursor = e.Location;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            if (trainingDragMode != TrainingAreaDragMode.none)
            {
                trainingDragMode = TrainingAreaDragMode.none;
            }
            
            // only consider it a click if the image wasn't dragged (could replace with doneDrag)
            if (Math.Abs(e.Location.X - mouseDownAt.X) < 1 && Math.Abs(e.Location.Y - mouseDownAt.Y) < 1)
            {
                ClearFocus();

                // move this to mouse up/press, only if didn't move cursor much from down position
                if (e.X > this.Size.Width * 0.9)
                    ScrollGallery(true);
                else if (e.X < this.Size.Width * 0.1 + (pnlLeft.Visible ? pnlLeft.Size.Width : 0))
                    ScrollGallery(false);
            }
        }

        private void form_MouseEnter(object sender, EventArgs e)
        {
            cursorOnImage = true;
        }

        private void form_MouseLeave(object sender, EventArgs e)
        {
            cursorOnImage = false;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (cursorOnImage && e.Delta != 0)
            {
                // allow a little leeway for mouse movement during zooming before setting a new zoom target
                if (Math.Abs(zoomCursor.X - e.X) > 10 || Math.Abs(zoomCursor.Y - e.Y) > 10)
                {
                    zoomCursor = new Point(e.X, e.Y);
                    zoomTarget = PointToImage(e.Location, true);
                }

                float zoomStep = 1.25f;
                float newZoom = zoom * (e.Delta > 0 ? zoomStep : 0.9625f / zoomStep); // zoom out a bit faster than in
                newZoom = Math.Min(Math.Max(.5f, newZoom), 12f); // cap zoom ranges
                
                if ((zoom > 1f && newZoom < 1f) || (zoom < 1f && newZoom > 1f) || Math.Abs(1 - newZoom) < Math.Min(0.05, zoomStep / 2))
                    newZoom = 1f; // snap to 1.0 zoom when passing over it or when very close

                if (newZoom != zoom)
                {
                    zoom = newZoom;

                    float blendSpeed = 0.65f;
                    pan.X = pan.X * (1 - blendSpeed) + (0.5f - zoomTarget.X) * blendSpeed;
                    pan.Y = pan.Y * (1 - blendSpeed) + (0.5f - zoomTarget.Y) * blendSpeed;

                    Repaint();
                }
            }
        }

        private void clearFocus_click(object sender, MouseEventArgs e)
        {
            ClearFocus();
        }

        private void ClearFocus()
        {
            this.ActiveControl = null; // https://stackoverflow.com/a/24417483
        }

        private void chkChangeBackground_Click(object sender, EventArgs e)
        {
            // https://stackoverflow.com/a/21049848
            ColorDialog clrDialog = new ColorDialog();
            
            clrDialog.Color = this.BackColor;
            clrDialog.CustomColors = new int[] { 0xD6DED4, 0xDDDDDD, 0xA1A1A1, 0x6D6A67, 0x4B4B4B, 0x242424, 0x000000 };

            if (clrDialog.ShowDialog() == DialogResult.OK)
                this.BackColor = clrDialog.Color;
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            if (database.images.Count > 0)
            {
                var confirmResult = MessageBox.Show("Unload your current database and batch?", "Proceed?", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.No)
                    return;
            }

            database = new ImageTaggerDatabase();
            database.Load(txtDatabase.Text, true);
            gallery.SetDatabase(database);
            SetBatchMode(false);

            RefreshDatabaseCountLabel();
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (txtDatabase.Text != database.loadedFrom && File.Exists(txtDatabase.Text))
            {
                string warning = $"Replace {txtDatabase.Text}";
                
                if (database.loadedFrom.Length > 0) warning += $" with this database loaded from {database.loadedFrom}";
                else  warning += " with this new database";

                warning += $" which contains {database.images.Count} images?";

                var confirmResult = MessageBox.Show(warning, "Replace File?", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.No)
                    return;
            }

            database.Save(txtDatabase.Text);
        }

        #endregion


        #region BATCHES

        private void SetBatchMode(bool inBatchMode)
        {
            if (this.inBatchMode && !inBatchMode)
                txtFilter.Text = ""; // clear filter whenever exit batch mode, as is often a previous filter string

            this.inBatchMode = inBatchMode;
            pnlResizableFilter.Visible = !inBatchMode;
            pnlBatch.Visible = inBatchMode;
            //chkBatchTag.Checked = inBatchMode;

            if (inBatchMode)
                chkBatchTag.Text = $"Batch Tag ({gallery.images.Count})";
        }

        private void btnExitBatch_Click(object sender, EventArgs e)
        {
            SetBatchMode(false);
        }

        private void chkBatchTag_CheckedChanged(object sender, EventArgs e)
        {
            DisplayTags();
        }

        #endregion


        #region TAGS

        private void DisplayTags()
        {
            List<string> tags = new List<string>();

            if (gallery.images.Count > 0)
                if (!chkBatchTag.Checked)
                    tags = database.GetImageTags(gallery.CurrentImage());
                else
                    tags = database.GetSharedImageTags(gallery.images);

            tags.Sort();

            // print tagIndices
            string tagsText = "";

            foreach (string tag in tags)
                tagsText += tag + ", ";

            txtTags.Text = tagsText;
        }
        
        private void txtTags_Leave(object sender, EventArgs e)
        {
            if (gallery.images.Count == 0) return;
            TaggedImage currentImage = (chkBatchTag.Checked ? null : gallery.CurrentImage());

            List<string> tagWords = Util.ParseTagText(txtTags.Text);

            foreach (string tagWord in tagWords)
                database.EnsureTagExists(tagWord);

            foreach (KeyValuePair<string, List<TaggedImage>> tagImages in database.tags)
            {
                List<TaggedImage> imagesForTag = tagImages.Value;
                bool validTag = tagWords.Contains(tagImages.Key);

                if (chkBatchTag.Checked)
                {
                    if (validTag)
                        Util.AddNewElements(imagesForTag, gallery.images);
                }
                else
                {
                    bool imageIsTagged = imagesForTag.Contains(currentImage);

                    if (validTag && !imageIsTagged)
                        imagesForTag.Add(currentImage);
                    else if (!validTag && imageIsTagged)
                        imagesForTag.Remove(currentImage);
                }
            }

            // remove any tags which all the batch items have, but which aren't in the text set (means was manually removed from the list)
            if (chkBatchTag.Checked)
            {
                List<string> sharedTags = database.GetSharedImageTags(gallery.images);
                IEnumerable<string> invalidBatchTags = sharedTags.Except(tagWords);

                foreach (string invalidtag in invalidBatchTags)
                {
                    List<TaggedImage> imagesForTag = database.tags[invalidtag];
                    Util.RemoveElements(imagesForTag, gallery.images);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // determine if changed by user or code
            if (!((RichTextBox)sender).Modified)
                return;

            if (timerFilterCooldown.Enabled)
                timerFilterCooldown.Stop();

            timerFilterCooldown.Enabled = true;
            timerFilterCooldown.Start();
        }

        private void timerFilterCooldown_Tick(object sender, EventArgs e)
        {
            timerFilterCooldown.Enabled = false;

            BuildGalleryFromFilter();
        }

        private void BuildGalleryFromFilter()
        {
            List<string> tagWords = Util.ParseTagText(txtFilter.Text);
            List<TaggedImage> newGallery = database.GetFilteredImages(tagWords, true);
            AddToGallery(newGallery, true, false, "filter");
        }

        #endregion


        #region TRAINING AREA

        private void TrainingData_EnsureDefaults(TaggedImage image, Image imageData)
        {
            // not reading images when first loaded into the database (too slow), so instead populate initial selection values when need them
            if (image.selections.Length == 0)
            {
                Image currentImageData = gallery.CurrentImageData();

                int imgW = currentImageData.Width;
                int imgH = currentImageData.Height;

                int square_size = Math.Min(imgW, imgH);
                int x = (square_size == imgW) ? 0 : Math.Max(0, imgW / 2 - square_size / 2);
                int y = (square_size == imgH) ? 0 : Math.Max(0, imgH / 2 - square_size / 2);

                image.selections = new int[] { x, y, square_size, square_size };
            }
        }

        private void lblTrainingData_Click(object sender, EventArgs e)
        {
            pnlResizableTrainingBounds.Visible = !pnlResizableTrainingBounds.Visible;
            lblTrainingData.Text = Util.FormatCollapsibleHeader(lblTrainingData.Text, !pnlResizableTrainingBounds.Visible);

            this.Repaint(); // repaint to add/remove visible selection box
        }

        private void TrainingData_PopulateGrid(bool maintainPosition)
        {
            TaggedImage currentImage = gallery.CurrentImage();
            TrainingData_EnsureDefaults(currentImage, gallery.CurrentImageData());

            int[] selections = currentImage.selections;

            int posRow = (maintainPosition ? gridTrainingSources.CurrentCell.RowIndex : 0);
            int posCol = (maintainPosition ? gridTrainingSources.CurrentCell.ColumnIndex : 0);

            gridTrainingSources.Rows.Clear();

            for (int i = 0; i < selections.Length; i += 4)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridTrainingSources);
                row.Cells[0].Value = selections[i];
                row.Cells[1].Value = selections[i + 1];
                row.Cells[2].Value = selections[i + 2];
                row.Cells[3].Value = selections[i + 3];
                gridTrainingSources.Rows.Add(row);
            }

            if (maintainPosition)
            {
                gridTrainingSources.CurrentCell = gridTrainingSources[posCol, posRow];
            }

            TrainingData_UpdateAspectRatios();
        }

        private void TrainingData_UpdateAspectRatios()
        {
            int[] selections = gallery.CurrentImage().selections;
            DataGridViewRowCollection rows = gridTrainingSources.Rows;

            for (int i = 0, j=0; i < selections.Length; i += 4, j++)
            {
                DataGridViewRow row = rows[j];

                try
                {
                    int w = selections[i + 2],
                        h = selections[i + 3],
                        gcd = Util.GreatestCommonDivisor(w, h);

                    string aspect = $"{w / gcd}:{h / gcd}";

                    //if (aspect.Length > 4) aspect = $"{(w/(float)h):#.#}";

                    row.Cells[4].Value = aspect;
                }
                catch { }
            }
        }

        private void TrainingData_ReadFromGrid(int currentCellValue)
        {
            // getting the active cell's value is difficult while being edited
            // so pass in the value from the update event on the temporary editing control, will be -1 if empty or invalid

            DataGridViewRowCollection rows = gridTrainingSources.Rows; // has an additional blank 'new' row which must be subtracted on Count checks
            DataGridViewCell currentCell = (currentCellValue == -1 ? null : gridTrainingSources.CurrentCell);

            // just assign a new selections array each time and write whatever is in the table, don't worry about perfect retaining of data if inputs are messed up
            int[] selections = new int[(rows.Count - 1) * 4];
            gallery.CurrentImage().selections = selections;

            for (int i = 0; i < rows.Count - 1; i++)
            {
                DataGridViewRow row = rows[i];

                for (int j=0; j<4; j++)
                    selections[i * 4 + j] = (row.Cells[j] == currentCell ? currentCellValue : Util.TryParseInt(row.Cells[j].Value));
            }

            TrainingData_UpdateAspectRatios();
            this.Repaint();
        }

        private void gridTrainingSources_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // get a proper cell changed event, based on https://stackoverflow.com/a/20440447
            TextBox tb = (TextBox)e.Control;
            tb.TextChanged -= gridTrainingCell_TextChanged; // not sure if this is the same instance each time, but remove any previous assignment just in case
            tb.TextChanged += gridTrainingCell_TextChanged;
        }

        private void gridTrainingCell_TextChanged(object sender, EventArgs e)
        {
            string currentCellText = ((TextBox)sender).Text;
            int currentCellValue;
            if (int.TryParse(currentCellText, out currentCellValue) == false)
                currentCellValue = -1;

            TrainingData_ReadFromGrid(currentCellValue);
        }

        private void gridTrainingSources_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Repaint(); // draw new bounding box
        }

        private float[] DrawableTrainingBounds(Image imageData)
        {
            if (imageData!=null && gridTrainingSources.Visible && gridTrainingSources.Rows.Count > 0)
            {
                try
                {
                    int[] selections = gallery.CurrentImage().selections;
                    int rowIndex = gridTrainingSources.CurrentCell.RowIndex;

                    float x = selections[rowIndex * 4];
                    float y = selections[rowIndex * 4 + 1];
                    float w = selections[rowIndex * 4 + 2];
                    float h = selections[rowIndex * 4 + 3];

                    if (w > 0 && h > 0)
                    {
                        x = imageBounds.X + x * imageBounds.Size.Width / imageData.Size.Width;
                        y = imageBounds.Y + y * imageBounds.Size.Height / imageData.Size.Height;
                        w *= imageBounds.Size.Width / imageData.Size.Width;
                        h *= imageBounds.Size.Height / imageData.Size.Height;

                        return new float[] { x, y, w, h };
                    }
                }
                catch { }
            }

            return new float[0];
        }

        private TrainingAreaDragMode CheckTrainingBoxCursor(int mX, int mY)
        {
            TrainingAreaDragMode mode = TrainingAreaDragMode.none;

            float[] trainingBounds = DrawableTrainingBounds(gallery.CurrentImageData());
            if (trainingBounds.Length == 4)
            {
                float x = trainingBounds[0];
                float y = trainingBounds[1];
                float w = trainingBounds[2];
                float h = trainingBounds[3];

                int cornerRange = 30;
                int edgeRange = 10;

                if (Util.Dist(mX, mY, x, y) < cornerRange) mode = TrainingAreaDragMode.cornerTL;
                else if (Util.Dist(mX, mY, x + w, y) < cornerRange) mode = TrainingAreaDragMode.cornerTR;
                else if (Util.Dist(mX, mY, x, y + h) < cornerRange) mode = TrainingAreaDragMode.cornerBL;
                else if (Util.Dist(mX, mY, x + w, y + h) < cornerRange) mode = TrainingAreaDragMode.cornerBR;
                else if (Util.DistToLineSegment(mX, mY, x, y, x + w, y) < edgeRange) mode = TrainingAreaDragMode.top;
                else if (Util.DistToLineSegment(mX, mY, x, y + h, x + w, y + h) < edgeRange) mode = TrainingAreaDragMode.bottom;
                else if (Util.DistToLineSegment(mX, mY, x, y, x, y + h) < edgeRange) mode = TrainingAreaDragMode.left;
                else if (Util.DistToLineSegment(mX, mY, x + w, y, x + w, y + h) < edgeRange) mode = TrainingAreaDragMode.right;
                else if (Util.IsInsideRect(mX, mY, x, y, x + w, y + h)) mode = TrainingAreaDragMode.centre;
            }

            return mode;
        }

        private void StartTrainingDrag(TrainingAreaDragMode mode)
        {
            this.trainingDragMode = mode;

            // cache original training area to do edits with each frame, to make dragging feel better, rather than applying deltas
            int rowIndex = gridTrainingSources.CurrentCell.RowIndex;
            int[] selections = gallery.CurrentImage().selections;
            Array.Copy(selections, rowIndex * 4, trainingDragBounds, 0, 4);
        }

        private void DragTrainingBounds(int deltaX, int deltaY, bool diagonalsMaintainAspect)
        {
            // account for how the image is currently scaled to the screen
            Image image = gallery.CurrentImageData();
            int imgW = image.Size.Width;
            int imgH = image.Size.Height;
            deltaX = (int)(deltaX / (imageBounds.Width / imgW));
            deltaY = (int)(deltaY / (imageBounds.Height / imgH));

            int[] selections = gallery.CurrentImage().selections;
            int rowIndex = gridTrainingSources.CurrentCell.RowIndex;

            int x = trainingDragBounds[0];
            int y = trainingDragBounds[1];
            int w = trainingDragBounds[2];
            int h = trainingDragBounds[3];

            TrainingAreaDragMode mode = this.trainingDragMode; // just to shorten code

            if (mode == TrainingAreaDragMode.centre)
            {
                x += deltaX;
                y += deltaY;

                x = Math.Max(x, 0);
                y = Math.Max(y, 0);
                x = Math.Min(x, imgW - w);
                y = Math.Min(y, imgH - h);
            }

            // probably not the best way to do this, but it works for now
            if (diagonalsMaintainAspect && (mode==TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerTR || mode == TrainingAreaDragMode.cornerBL || mode == TrainingAreaDragMode.cornerBR))
            {
                int gcd = Util.GreatestCommonDivisor(w, h);
                int widthIntervals = w / gcd;
                int heightIntervals = h / gcd;

                bool useHoriz = Math.Abs(deltaX) > Math.Abs(deltaY);
                int steps = (int)(useHoriz ? Math.Abs(Math.Round(deltaX / (double)widthIntervals)) : Math.Abs(Math.Round(deltaY / (double)heightIntervals)));
                bool posX = deltaX > 0;
                bool posY = deltaY > 0;

                if (mode == TrainingAreaDragMode.cornerTL)
                {
                    if (useHoriz) posY = (deltaX > 0); else posX = (deltaY > 0);
                    
                    if (!posX || !posY) steps = Math.Min(steps, Math.Min(x / widthIntervals, y / heightIntervals));
                }
                else if (mode == TrainingAreaDragMode.cornerBR)
                {
                    if (useHoriz) posY = (deltaX > 0); else posX = (deltaY > 0);

                    if (posX || posY) steps = Math.Min(steps, Math.Min((imgW - x - w) / widthIntervals, (imgH - y - h) / heightIntervals));
                }
                else if (mode == TrainingAreaDragMode.cornerTR)
                {
                    if (useHoriz) posY = (deltaX < 0); else posX = (deltaY < 0);

                    if (posX || !posY) steps = Math.Min(steps, Math.Min((imgW - x - w) / widthIntervals, y / heightIntervals));
                }
                else if (mode == TrainingAreaDragMode.cornerBL)
                {
                    if (useHoriz) posY = (deltaX < 0); else posX = (deltaY < 0);

                    if (!posX || posY) steps = Math.Min(steps, Math.Min(x / widthIntervals, (imgH - y - h) / heightIntervals));
                }

                deltaX = steps * widthIntervals * (posX ? 1 : -1);
                deltaY = steps * heightIntervals * (posY ? 1 : -1);
            }


            if (mode == TrainingAreaDragMode.left || mode == TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerBL)
            {
                deltaX = Math.Max(deltaX, 0-x);

                x += deltaX;
                w -= deltaX;
            }

            if (mode == TrainingAreaDragMode.right || mode == TrainingAreaDragMode.cornerTR || mode == TrainingAreaDragMode.cornerBR)
            {
                deltaX = Math.Min(deltaX, imgW-(x+w));

                w += deltaX;
            }

            if (mode == TrainingAreaDragMode.top || mode == TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerTR)
            {
                deltaY = Math.Max(deltaY, 0 - y);

                y += deltaY;
                h -= deltaY;
            }

            if (mode == TrainingAreaDragMode.bottom ||mode == TrainingAreaDragMode.cornerBL || mode == TrainingAreaDragMode.cornerBR)
            {
                deltaY = Math.Min(deltaY, imgH - (y+h));

                h += deltaY;
            }

            /*// old snapping to valid SD aspect ratios for all images, not very useful it turns out
            if (snapping && mode != TrainingAreaDragMode.centre)
            {
                bool left = (mode == TrainingAreaDragMode.left || mode == TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerBL);
                bool top = (mode == TrainingAreaDragMode.top || mode == TrainingAreaDragMode.cornerTL || mode == TrainingAreaDragMode.cornerTR);

                int xMove = left ? (x - selections[rowIndex * 4]) : (w - selections[rowIndex * 4 + 2]);
                int yMove = top ? (y - selections[rowIndex * 4 + 1]) : (h - selections[rowIndex * 4 + 3]);

                if (xMove != 0 || yMove != 0)
                    Util.SnapToAspectRatio(ref x, ref y, ref w, ref h, imgW, imgH, xMove, yMove, left, top);
            }*/

            if (w != 0 && h != 0)
            {
                selections[rowIndex * 4] = x;
                selections[rowIndex * 4 + 1] = y;
                selections[rowIndex * 4 + 2] = w;
                selections[rowIndex * 4 + 3] = h;
            }

            TrainingData_PopulateGrid(true);
            Repaint();
        }

        #endregion


        #region RESIZABLE PANELS

        private void panelResizeable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ((System.Windows.Forms.Panel)sender).Tag = "resizing";
        }

        private void panelResizeable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ((System.Windows.Forms.Panel)sender).Tag = "";
        }

        private void panelResizeable_MouseMove(object sender, MouseEventArgs e)
        {
            if ((string)(((System.Windows.Forms.Panel)sender).Tag) == "resizing")
            {
                ((System.Windows.Forms.Panel)sender).Size = new Size(((System.Windows.Forms.Panel)sender).Size.Width, e.Y);
            }
        }

        private void btnCollapseSidePanel_Click(object sender, EventArgs e)
        {
            pnlLeft.Visible = !pnlLeft.Visible;
            int buttonLeft = (pnlLeft.Visible ? pnlLeft.Width : 0);
            btnCollapseSidePanel.Location = new Point(buttonLeft, btnCollapseSidePanel.Location.Y);
            btnCollapseSidePanel.Text = (pnlLeft.Visible ? "<" : ">");
            Repaint();
        }

        private void lblDatabase_Click(object sender, EventArgs e)
        {
            pnlDatabase.Visible = !pnlDatabase.Visible;
            RefreshDatabaseCountLabel();
        }

        private void RefreshDatabaseCountLabel()
        {
            lblDatabase.Text = "Database";
            if (database.images.Count > 0)
                lblDatabase.Text += $"({Util.FormatNumberToKMB(database.images.Count)})";

            lblDatabase.Text = Util.FormatCollapsibleHeader(lblDatabase.Text, !pnlDatabase.Visible);
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible;
            lblSettings.Text = Util.FormatCollapsibleHeader(lblSettings.Text, !pnlSettings.Visible);
        }

        private void frmImageTaggerMain_Resize(object sender, EventArgs e)
        {
            Repaint();
        }


        #endregion
    }

    #region DATABASE

    internal class Gallery
    {
        public ImageTaggerDatabase database;
        public int index;
        public List<TaggedImage> images;
        public Dictionary<TaggedImage, Image> imageData;

        private static int max_images_in_memory = 20;

        public Gallery(ImageTaggerDatabase database)
        {
            this.SetDatabase(database);
        }

        public void SetDatabase(ImageTaggerDatabase database)
        {
            this.database = database;
            this.index = 0;
            this.images = new List<TaggedImage>();
            this.imageData = new Dictionary<TaggedImage, Image>();
        }

        public void AddImages(List<TaggedImage> images, bool clear)
        {
            if (clear)
            {
                this.index = 0;
                this.images = images;
                this.imageData.Clear();
            }
            else
            {
                // TODO could be in a sorted set by filepath or something for quicker checking
                foreach (TaggedImage image in images)
                    if (!this.images.Contains(image))
                        this.images.Add(image);
            }
        }

        public TaggedImage CurrentImage()
        {
            return this.images[this.index];
        }

        public Image CurrentImageData()
        {
            if (this.images.Count == 0)
                return null;

            TaggedImage currentImage = this.CurrentImage();
            Image currentImageData;

            if (imageData.ContainsKey(currentImage))
            {
                currentImageData = imageData[currentImage];
            }
            else
            {
                currentImageData = Image.FromFile(currentImage.filepath);

                // naive pruning solution since dictionaries aren't ordered, just wipe the dictionary. Could check for neighbours from this.images list
                if (this.imageData.Count > max_images_in_memory) {
                    this.imageData.Clear();
                    GC.Collect();
                }

                this.imageData[currentImage] = currentImageData;
            }

            return currentImageData;
        }
    }

    internal class ImageTaggerDatabase
    {
        public string loadedFrom = "";
        public Dictionary<string, List<TaggedImage>> tags = new Dictionary<string, List<TaggedImage>>();
        public Dictionary<string, TaggedImage> images = new Dictionary<string, TaggedImage>();

        public List<TaggedImage> GetImageInfo(string[] imagePaths, bool add)
        {
            List<TaggedImage> imagesInfo = new List<TaggedImage>();
            Util.ValidImageChecker imageChecker = new Util.ValidImageChecker();

            foreach (string imagePath in imagePaths)
            {
                TaggedImage image = null;
                
                if (images.ContainsKey(imagePath))
                {
                    image = images[imagePath];
                }
                else if (add)
                {
                    if (!imageChecker.IsValidImageFile(imagePath))
                        continue;

                    image = new TaggedImage(imagePath);
                    this.images[imagePath] = image;
                }

                if (image != null)
                    imagesInfo.Add(image);
            }

            return imagesInfo;
        }
        
        public void Save(string path)
        {
            string tempPath = path + "_temp";

            if (File.Exists(tempPath))
            {
                MessageBox.Show(tempPath + " already exists, cannot save tags", "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamWriter writetext = new StreamWriter(tempPath))
            {
                Dictionary<TaggedImage, List<string>> allImageTags = GetAllImageTags();

                foreach (KeyValuePair<TaggedImage, List<string>> imageTags in allImageTags)
                {
                    TaggedImage image = imageTags.Key;

                    writetext.WriteLine(image.filepath);
                    writetext.WriteLine($"{string.Join(",", imageTags.Value)}");
                    writetext.WriteLine($"{string.Join(",", image.selections)}"); // can't validate these if the image data was never loaded, so python will need to fall back to same implementation
                }
            }

            if (File.Exists(path))
                File.Delete(path);
            System.IO.File.Move(tempPath, path);
        }

        public void Load(string path, bool userActivated)
        {
            if (!File.Exists(path))
            {
                if (userActivated)
                    MessageBox.Show(path + " doesn't exist", "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.tags.Clear();
            this.images.Clear();
            this.loadedFrom = path;

            using (StreamReader sr = new StreamReader(path))
            {
                int stage = 0;
                TaggedImage image = null;
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (stage==0)
                    {
                        image = new TaggedImage(line);
                        images[line] = image;
                    }
                    else if (stage==1)
                    {
                        string[] imageTags = line.Split(',');
                        foreach (string tag in imageTags)
                        {
                            EnsureTagExists(tag);
                            this.tags[tag].Add(image);
                        }
                    }
                    else
                    {
                        if (line.Length > 0)
                            image.selections = (line.Split(',').Select(x => int.Parse(x))).ToArray();
                    }

                    stage = (stage + 1) % 3;
                }
            }
        }

        public List<string> GetImageTags(TaggedImage image)
        {
            List<string> imageTags = new List<string>();

            foreach (KeyValuePair<string, List<TaggedImage>> tagImages in this.tags)
            {
                if (tagImages.Value.Contains(image))
                    imageTags.Add(tagImages.Key);
            }

            return imageTags;
        }

        public List<string> GetSharedImageTags(List<TaggedImage> images)
        {
            List<string> imageTags = new List<string>();

            foreach (KeyValuePair<string, List<TaggedImage>> tagImages in this.tags)
            {
                if (Util.ContainsAll(tagImages.Value, images))
                    imageTags.Add(tagImages.Key);
            }

            return imageTags;
        }

        public void EnsureTagExists(string tag)
        {
            if (!this.tags.ContainsKey(tag))
            {
                this.tags[tag] = new List<TaggedImage>();
            }
        }

        public List<TaggedImage> GetFilteredImages(List<string> tagList, bool requiresAllTags)
        {
            List<TaggedImage> images = new List<TaggedImage>();

            for (int i = 0; i < tagList.Count; i++)
            {
                string tag = tagList[i];

                if (!this.tags.ContainsKey(tag))
                {
                    if (requiresAllTags)
                        return new List<TaggedImage>(); // won't have any results for an invalid tag where all tags are required
                    continue;
                }

                List<TaggedImage> imagesForTag = this.tags[tag];

                if (i == 0)
                    images.AddRange(imagesForTag);
                else
                {
                    if (requiresAllTags)
                        Util.PruneToSharedEntries(images, imagesForTag);
                    else
                        Util.AddNewElements(images, imagesForTag);
                }
            }

            return images;
        }

        public Dictionary<TaggedImage, List<string>> GetAllImageTags()
        {
            Dictionary<TaggedImage, List<string>> allImageTags = new Dictionary<TaggedImage, List<string>>();

            foreach (TaggedImage image in this.images.Values)
                allImageTags[image] = new List<string>();

            foreach (KeyValuePair<string, List<TaggedImage>> tagImages in this.tags)
                foreach (TaggedImage image in tagImages.Value)
                    allImageTags[image].Add(tagImages.Key);

            return allImageTags;
        }
    }

    internal class TaggedImage
    {
        public string filepath = "";
        public int[] selections = new int[0];

        public TaggedImage(string filepath)
        {
            this.filepath = filepath;
        }
    }

    #endregion


    internal static class Util
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            // https://stackoverflow.com/a/1186465
            return (b == 0) ? a : GreatestCommonDivisor(b, a % b);
        }

        public static Control FindFocusedControl(Control control)
        {
            // https://stackoverflow.com/a/439606
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        public static void PruneToSharedEntries<T>(List<T> list, List<T> entries)
        {
            // https://stackoverflow.com/a/4066127
            list.RemoveAll(item => !entries.Contains(item));
        }

        public static bool ContainsAll<T>(IEnumerable<T> source, IEnumerable<T> values)
        {
            // https://stackoverflow.com/a/36856433
            return values.All(value => source.Contains(value));
        }

        public static void AddNewElements<T>(List<T> list, IEnumerable<T> elements)
        {
            // https://stackoverflow.com/a/48218620
            list.AddRange(elements.Except(list));
        }

        public static void RemoveElements<T>(List<T> list, IEnumerable<T> elements)
        {
            foreach (T element in elements)
                list.Remove(element);
        }

        public static List<string> ParseTagText(string text)
        {
            text = Regex.Replace(text, @"\t|\n|\r", ""); // trim new lines, https://stackoverflow.com/a/4140802

            List<string> tagWords = text.Split(',').ToList();
            for (int i = tagWords.Count - 1; i >= 0; i--)
            {
                string tagWord = tagWords[i].Trim(' ');
                if (tagWord.Length > 0)
                    tagWords[i] = tagWord;
                else
                    tagWords.RemoveAt(i); // remove any blank tags
            }

            return tagWords;
        }

        public static int TryParseInt(object obj)
        {
            if (obj != null)
            {
                int val;
                if (int.TryParse(obj.ToString(), out val))
                    return val;
            }

            return 0;
        }

        public static string FormatNumberToKMB(decimal num)
        {
            // https://stackoverflow.com/a/48000498
            if (num > 999999999 || num < -999999999)
                return num.ToString("0,,,.###B");
            else
            if (num > 999999 || num < -999999)
                return num.ToString("0,,.##M");
            else
            if (num > 999 || num < -999)
                return num.ToString("0,.#K");
            else
                return num.ToString();
        }

        public static string FormatCollapsibleHeader(string text, bool collapsed)
        {
            string replace = (collapsed ? "⏶" : "⏷");
            string with = (collapsed ? "⏷" : "⏶");

            if (!text.Contains(replace) && !text.Contains(with))
                return text + (text.EndsWith(" ") ? "" : " ") + with;

            return text.Replace(replace, with);
        }

        public static double Dist(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double DistToLineSegment(double x, double y, double x1, double y1, double x2, double y2, double from=0, double to=1)
        {
            if (from != 0 || to != 1)
            {
                double newX1 = x1 + (x2 - x1) * from;
                double newY1 = y1 + (y2 - y1) * from;
                double newX2 = x1 + (x2 - x1) * to;
                double newY2 = y1 + (y2 - y1) * to;

                x1 = newX1;
                y1 = newY1;
                x2 = newX2;
                y2 = newY2;
            }

            // adapted from: https://www.geeksforgeeks.org/minimum-distance-from-a-point-to-the-line-segment-using-vectors/
            double lenX = x2 - x1;
            double lenY = y2 - y1;
            double dx2 = x - x2;
            double dy2 = y - y2;
            double dx1 = x - x1;
            double dy1 = y - y1;

            // Calculating the dot product
            double dot2 = (lenX * dx2 + lenY * dy2);
            double dot1 = (lenX * dx1 + lenY * dy1);

            double dist = 0;

            if (dot2 > 0)
                dist = Dist(x, y, x2, y2);
            else if (dot1 < 0)
                dist = Dist(x, y, x1, y1);
            else
            {
                // Finding the perpendicular distance
                double mod = Math.Sqrt(lenX * lenX + lenY * lenY);
                dist = Math.Abs(lenX * dy1 - lenY * dx1) / (mod != 0 ? mod : 1);
            }
            return dist;
        }

        public static bool IsInsideRect(float x, float y, float x1, float y1, float x2, float y2)
        {
            return x >= x1 && x <= x2 && y >= y1 && y <= y2;
        }

        public class ValidImageChecker
        {
            // adapted from https://stackoverflow.com/a/49683945
            byte[] bmp = new byte[] { 0x42, 0x4D };               // BMP "BM"
            byte[] gif87a = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 };     // "GIF87a"
            byte[] gif89a = new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 };     // "GIF89a"
            byte[] png = new byte[] { 0x89, 0x50, 0x4e, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };   // PNG "\x89PNG\x0D\0xA\0x1A\0x0A"
            byte[] tiffI = new byte[] { 0x49, 0x49, 0x2A, 0x00 }; // TIFF II "II\x2A\x00"
            byte[] tiffM = new byte[] { 0x4D, 0x4D, 0x00, 0x2A }; // TIFF MM "MM\x00\x2A"
            byte[] jpeg = new byte[] { 0xFF, 0xD8, 0xFF };        // JPEG JFIF (SOI "\xFF\xD8" and half next marker xFF)
            byte[] jpegEnd = new byte[] { 0xFF, 0xD9 };           // JPEG EOI "\xFF\xD9"

            public bool IsValidImageFile(string file)
            {
                try
                {
                    byte[] buffer = new byte[8];
                    byte[] bufferEnd = new byte[2];

                    using (System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        if (fs.Length > buffer.Length)
                        {
                            fs.Read(buffer, 0, buffer.Length);
                            fs.Position = (int)fs.Length - bufferEnd.Length;
                            fs.Read(bufferEnd, 0, bufferEnd.Length);
                        }

                        fs.Close();
                    }

                    if (ByteArrayStartsWith(buffer, bmp) ||
                        ByteArrayStartsWith(buffer, gif87a) ||
                        ByteArrayStartsWith(buffer, gif89a) ||
                        ByteArrayStartsWith(buffer, png) ||
                        ByteArrayStartsWith(buffer, tiffI) ||
                        ByteArrayStartsWith(buffer, tiffM))
                    {
                        return true;
                    }

                    if (ByteArrayStartsWith(buffer, jpeg))
                    {
                        // Offset 0 (Two Bytes): JPEG SOI marker (FFD8 hex)
                        // Offest 1 (Two Bytes): Application segment (FF?? normally ??=E0)
                        // Trailer (Last Two Bytes): EOI marker FFD9 hex
                        if (ByteArrayStartsWith(bufferEnd, jpegEnd))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Image File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }

            private static bool ByteArrayStartsWith(byte[] a, byte[] b)
            {
                if (a.Length < b.Length)
                    return false;

                for (int i = 0; i < b.Length; i++)
                    if (a[i] != b[i])
                        return false;

                return true;
            }
        }
    }
}
