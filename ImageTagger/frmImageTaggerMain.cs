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
// + ideally would only write changes/additions to the database rather than the whole file
// + group images in database per directory, and load per directory (save a large amount of text space and make it easier to change a directory)
//      could also have tags per directory, and select all in a directory easily
// + Add gif playback https://stackoverflow.com/a/13486374
// + maybe shouldn't add new images to database automatically, and gallery should hold cache of unsaved images. Maybe have an 'Add to Database (count)' button
// + maybe a validate button which will compile a list of all images which no longer exist,and give an option to clear them
//   or potentially relocate them (scanning in existing directories). Could cache some more imageinfo for that, like file size, resolution
// + allow minimum zoom to at least be the original size of the picture, for small pictures
// + maybe add an auto-zoom checkbox to settings

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


        public frmImageTaggerMain()
        {
            InitializeComponent();
        }

        private void form_Load(object sender, EventArgs e)
        {
            SetBatchMode(false);

            database = new ImageTaggerDatabase();
            database.Load();

            gallery = new Gallery(database);

            ClearFocus();

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
            timerFilterCooldown.Interval = 1500;
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
                    bool isBatch = images.Count > 1 || inBatchMode;
                    bool clearGallery = !isBatch || !inBatchMode;
                    AddToGallery(images, clearGallery, isBatch);
                }
            }
        }

        #endregion


        #region GALLERY

        private void AddToGallery(List<TaggedImage> images, bool clearGallery, bool isBatch)
        {
            gallery.AddImages(images, clearGallery);
            SetBatchMode(isBatch);
            ClearFocus();
            gallery.index = (images.Count == 0 ? 0 : gallery.images.IndexOf(images[0]));
            ImageChanged();
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

            ImageChanged();

            // allow clicks and key presses in fullscreen to scroll the gallery
            if (timerSlideshow.Enabled)
            {
                timerSlideshow.Stop();
                timerSlideshow.Start();
            }
        }

        private void ImageChanged()
        {
            this.zoom = 1f;
            this.pan.X = 0;
            this.pan.Y = 0;

            if (gallery.images.Count == 0)
            {
                this.Text = "Image Tagger";
                txtTags.Text = "";
                // TODO clear training area values (maybe even hide tags and training area)
            }
            else
            {
                Image image = gallery.CurrentImageData();
                this.Text = Path.GetFileName(gallery.CurrentImage().filepath); // + $" ({image.Size.Width}x{image.Size.Height})";
                // TODO fill in training area values

                if (!chkBatchTag.Checked)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control focusedControl = Util.FindFocusedControl(this);
            bool onTextBox = (focusedControl is TextBox || focusedControl is RichTextBox) ;

            if (!onTextBox && (keyData == Keys.Left || keyData == Keys.Right))
            {
                ScrollGallery(keyData == Keys.Right);
                return true;
            }

            if (!onTextBox && keyData == Keys.Space)
            {
                ToggleSlideshow();
            }

            // should really have a flag for in slideshow rather than check this way
            if (!onTextBox && keyData == Keys.Escape && this.FormBorderStyle == FormBorderStyle.None)
            {
                ToggleSlideshow();
            }

            return base.ProcessCmdKey(ref msg, keyData); // https://stackoverflow.com/a/34168026
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownAt = e.Location;
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoPan(e.Location.X - lastCursor.X, e.Location.Y - lastCursor.Y, false);
            }

            lastCursor = e.Location;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
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

        #endregion


        #region BATCHES

        private void SetBatchMode(bool inBatchMode)
        {
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

            // print tagIndices
            string tagsText = "";

            foreach (string tag in tags)
                tagsText += tag + ", ";

            txtTags.Text = tagsText;
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            // update
        }

        // need to remove from any tags now not in
        // so need to iterate all tags
        private void txtTags_Leave(object sender, EventArgs e)
        {
            if (gallery.images.Count == 0) return;
            TaggedImage currentImage = (chkBatchTag.Checked ? null : gallery.CurrentImage());

            List<string> tagWords = Util.ParseTagText(txtTags.Text);

            foreach (string tagWord in tagWords)
                database.EnsureTagExists(tagWord);

            foreach (KeyValuePair<string, List<TaggedImage>> tagDetails in database.tags)
            {
                List<TaggedImage> imagesForTag = tagDetails.Value;
                bool validTag = tagWords.Contains(tagDetails.Key);

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
            if (timerFilterCooldown.Enabled)
                timerFilterCooldown.Stop();

            timerFilterCooldown.Enabled = true;
            timerFilterCooldown.Start();
        }

        private void timerFilterCooldown_Tick(object sender, EventArgs e)
        {
            timerFilterCooldown.Enabled = false;

            List<string> tagWords = Util.ParseTagText(txtFilter.Text);
            List<TaggedImage> newGallery = database.GetImagesWithTags(tagWords, true);

            AddToGallery(newGallery, true, false);
        }

        #endregion


        #region TRAINING AREAS

        private void lblTrainingData_Click(object sender, EventArgs e)
        {
            chkTrainingFull.Visible = !chkTrainingFull.Visible;
            lblTrainingData.Text = "Training Area " + (chkTrainingFull.Visible ? "⏶" : "⏷");
            UpdateTrainingBoundsVisibility();
        }

        private void chkTrainingFull_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTrainingBoundsVisibility();
        }

        private void UpdateTrainingBoundsVisibility()
        {
            pnlResizableTrainingBounds.Visible = !chkTrainingFull.Checked;
            //chkTrainingFull.Text = (chkTrainingFull.Checked ? "Full Image" : "Selections");
        }

        private void txtTrainingBounds_TextChanged(object sender, EventArgs e)
        {
            ParseTrainingBounds(true);
        }

        private void ParseTrainingBounds(bool userEdit)
        {
            if (userEdit)
            {
                // TODO clear current image bounds
            }

            int textCursorPosition = txtTrainingBounds.SelectionStart;
            String[] lines = txtTrainingBounds.Lines;
            String[] aspects = new String[lines.Length];

            for (int i = 0, iLen = lines.Length; i < iLen; i++)
            {
                string line = lines[i];
                string newLine = Regex.Replace(line, "[^0-9, ]", "");
                lines[i] = newLine;
                textCursorPosition -= line.Length - newLine.Length;

                newLine = Regex.Replace(newLine, "[ ]", "");
                string[] components = newLine.Split(',');
                string aspect = "";
                try
                {
                    if (components.Length == 4)
                    {
                        int x = int.Parse(components[0]),
                            y = int.Parse(components[1]),
                            w = int.Parse(components[2]),
                            h = int.Parse(components[3]),
                            gcd = Util.GreatestCommonDivisor(w, h);

                        // TODO need to ensure are valid for image
                        //MessageBox.Show("w: " + w + ", h: " + h + " , gcd: " + gcd);

                        aspect += w / gcd + ":" + h / gcd;

                        if (userEdit)
                        {
                            // TODO add new bounds to current image
                        }
                    }
                } catch { }

                aspects[i] = aspect;
            }

            txtTrainingBounds.Lines = lines;
            txtTrainingBounds.SelectionStart = textCursorPosition;
            txtTrainingAspects.Lines = aspects;
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

        private void lblSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible;
            lblSettings.Text = "Settings " + (pnlSettings.Visible ? "⏶" : "⏷");
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
        public int index = 0;
        public List<TaggedImage> images = new List<TaggedImage>();
        public Dictionary<TaggedImage, Image> imageData = new Dictionary<TaggedImage, Image>();

        private static int max_images_in_memory = 20;

        public Gallery(ImageTaggerDatabase database)
        {
            this.database = database;
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
                if (this.imageData.Count > max_images_in_memory)
                    this.imageData.Clear();

                this.imageData[currentImage] = currentImageData;
            }

            return currentImageData;
        }
    }

    internal class ImageTaggerDatabase
    {
        string databaseLocation = "./images_tags_database.txt";
        //public List<string> tags = new List<string>();
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

        // maybe don't save any tags with 0 entries, from typos etc along the way
        public void Save()
        {
            /*
            string tempPath = databaseLocation + "_temp";

            if (File.Exists(tempPath))
            {
                MessageBox.Show(tempPath + " already exists, cannot save tags", "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamWriter writetext = new StreamWriter(tempPath))
            {
                writetext.WriteLine(string.Join(",", tags)); // write the tags on the first line

                foreach (TaggedImage taggedImage in images)
                {
                    writetext.WriteLine(
                        taggedImage.filepath + ',' +
                        string.Join(",", taggedImage.selection) + ',' +
                        string.Join(",", taggedImage.tagIndices) );
                }
            }

            if (File.Exists(databaseLocation))
                File.Delete(databaseLocation);
            System.IO.File.Move(tempPath, databaseLocation);
            */
        }

        public void Load()
        {
            /*
            if (!File.Exists(databaseLocation))
                return;

            string[] lines = File.ReadAllLines(databaseLocation);

            for (int i = 0, iLen = lines.Length; i < iLen; i++)
            {
                string[] line = lines[i].Split(',');

                if (i == 0)
                    foreach (string tag in line) tags.Add(tag);
                else
                {
                    TaggedImage taggedImage = new TaggedImage ( line[0] );

                    for (int j = 1, jLen = line.Length; j < jLen; j++)
                    {
                        int number = int.Parse(line[j]);

                        if (j <= 4)
                            taggedImage.selection[j - 1] = number; // bounds are first 4 numbers
                        else
                            taggedImage.tagIndices.Add(number); // tag indices are the rest
                    }
                }
            }
            */
        }

        public List<string> GetImageTags(TaggedImage image)
        {
            List<string> imageTags = new List<string>();

            foreach (KeyValuePair<string, List<TaggedImage>> entry in this.tags)
            {
                if (entry.Value.Contains(image))
                    imageTags.Add(entry.Key);
            }

            return imageTags;
        }

        public List<string> GetSharedImageTags(List<TaggedImage> images)
        {
            List<string> imageTags = new List<string>();

            foreach (KeyValuePair<string, List<TaggedImage>> entry in this.tags)
            {
                if (Util.ContainsAll(entry.Value, images))
                    imageTags.Add(entry.Key);
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

        public List<TaggedImage> GetImagesWithTags(List<string> tagList, bool requiresAllTags)
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

    }

    internal class TaggedImage
    {
        public string filepath = "";
        public string[] selections = new string[0];
        //public List<int> tagIndices = new List<int>();

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

        public static void PruneToSharedEntries<T>(List<T> list, List<T> secondary)
        {
            // https://stackoverflow.com/a/4066127
            list.RemoveAll(item => !secondary.Contains(item));
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
