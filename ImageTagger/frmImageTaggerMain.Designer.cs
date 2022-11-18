namespace ImageTagger
{
    partial class frmImageTaggerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageTaggerMain));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlResizableFilter = new System.Windows.Forms.Panel();
            this.tagSelectorFilter = new ImageTagger.TagsSelector();
            this.txtFilter = new System.Windows.Forms.RichTextBox();
            this.pnlBatch = new System.Windows.Forms.Panel();
            this.btnExitBatch = new System.Windows.Forms.Button();
            this.chkBatchTag = new System.Windows.Forms.CheckBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.pnlResizableTags = new System.Windows.Forms.Panel();
            this.tagsSelectorImage = new ImageTagger.TagsSelector();
            this.txtTags = new System.Windows.Forms.RichTextBox();
            this.lblTrainingData = new System.Windows.Forms.Label();
            this.pnlResizableTrainingBounds = new System.Windows.Forms.Panel();
            this.gridTrainingSources = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aspect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.pnlDatabase = new System.Windows.Forms.Panel();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.btnLoadDatabase = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblSettings = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblScrollSpeed = new System.Windows.Forms.Label();
            this.numScrollSpeed = new System.Windows.Forms.NumericUpDown();
            this.btnChangeBackground = new System.Windows.Forms.Button();
            this.cmbInterpolationModes = new System.Windows.Forms.ComboBox();
            this.btnCollapseSidePanel = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTagDrag_13 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_12 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_11 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_10 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_9 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_8 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_7 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_6 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_5 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_4 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_3 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_2 = new System.Windows.Forms.ComboBox();
            this.cmbTagDrag_1 = new System.Windows.Forms.ComboBox();
            this.pnlFilterHeader = new System.Windows.Forms.Panel();
            this.pnlTagsHeader = new System.Windows.Forms.Panel();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftFlow.SuspendLayout();
            this.pnlResizableFilter.SuspendLayout();
            this.pnlBatch.SuspendLayout();
            this.pnlResizableTags.SuspendLayout();
            this.pnlResizableTrainingBounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingSources)).BeginInit();
            this.pnlDatabase.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollSpeed)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlFilterHeader.SuspendLayout();
            this.pnlTagsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.pnlLeftFlow);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(141, 1002);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlLeftFlow
            // 
            this.pnlLeftFlow.AutoScroll = true;
            this.pnlLeftFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.pnlLeftFlow.Controls.Add(this.pnlFilterHeader);
            this.pnlLeftFlow.Controls.Add(this.pnlResizableFilter);
            this.pnlLeftFlow.Controls.Add(this.pnlBatch);
            this.pnlLeftFlow.Controls.Add(this.pnlTagsHeader);
            this.pnlLeftFlow.Controls.Add(this.pnlResizableTags);
            this.pnlLeftFlow.Controls.Add(this.lblTrainingData);
            this.pnlLeftFlow.Controls.Add(this.pnlResizableTrainingBounds);
            this.pnlLeftFlow.Controls.Add(this.lblDatabase);
            this.pnlLeftFlow.Controls.Add(this.pnlDatabase);
            this.pnlLeftFlow.Controls.Add(this.lblSettings);
            this.pnlLeftFlow.Controls.Add(this.pnlSettings);
            this.pnlLeftFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLeftFlow.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftFlow.Name = "pnlLeftFlow";
            this.pnlLeftFlow.Size = new System.Drawing.Size(139, 1000);
            this.pnlLeftFlow.TabIndex = 0;
            this.pnlLeftFlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Location = new System.Drawing.Point(0, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 13);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Filter <>";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            this.lblFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // pnlResizableFilter
            // 
            this.pnlResizableFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlResizableFilter.Controls.Add(this.tagSelectorFilter);
            this.pnlResizableFilter.Controls.Add(this.txtFilter);
            this.pnlResizableFilter.Location = new System.Drawing.Point(3, 18);
            this.pnlResizableFilter.Name = "pnlResizableFilter";
            this.pnlResizableFilter.Size = new System.Drawing.Size(133, 134);
            this.pnlResizableFilter.TabIndex = 8;
            this.pnlResizableFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseDown);
            this.pnlResizableFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseMove);
            this.pnlResizableFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseUp);
            // 
            // tagSelectorFilter
            // 
            this.tagSelectorFilter.AllowDrop = true;
            this.tagSelectorFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagSelectorFilter.BackColor = System.Drawing.Color.White;
            this.tagSelectorFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tagSelectorFilter.Location = new System.Drawing.Point(0, 0);
            this.tagSelectorFilter.Name = "tagSelectorFilter";
            this.tagSelectorFilter.Size = new System.Drawing.Size(136, 128);
            this.tagSelectorFilter.TabIndex = 5;
            this.tagSelectorFilter.Visible = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BackColor = System.Drawing.Color.White;
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Location = new System.Drawing.Point(0, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(136, 128);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.Text = "";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // pnlBatch
            // 
            this.pnlBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBatch.Controls.Add(this.btnExitBatch);
            this.pnlBatch.Controls.Add(this.chkBatchTag);
            this.pnlBatch.Location = new System.Drawing.Point(3, 158);
            this.pnlBatch.Name = "pnlBatch";
            this.pnlBatch.Size = new System.Drawing.Size(133, 55);
            this.pnlBatch.TabIndex = 11;
            this.pnlBatch.Visible = false;
            // 
            // btnExitBatch
            // 
            this.btnExitBatch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExitBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExitBatch.ForeColor = System.Drawing.Color.White;
            this.btnExitBatch.Location = new System.Drawing.Point(6, 3);
            this.btnExitBatch.Name = "btnExitBatch";
            this.btnExitBatch.Size = new System.Drawing.Size(121, 23);
            this.btnExitBatch.TabIndex = 4;
            this.btnExitBatch.Text = "< exit batch  >";
            this.btnExitBatch.UseVisualStyleBackColor = true;
            this.btnExitBatch.Click += new System.EventHandler(this.btnExitBatch_Click);
            // 
            // chkBatchTag
            // 
            this.chkBatchTag.AutoSize = true;
            this.chkBatchTag.BackColor = System.Drawing.Color.Transparent;
            this.chkBatchTag.ForeColor = System.Drawing.Color.White;
            this.chkBatchTag.Location = new System.Drawing.Point(6, 32);
            this.chkBatchTag.Name = "chkBatchTag";
            this.chkBatchTag.Size = new System.Drawing.Size(76, 17);
            this.chkBatchTag.TabIndex = 14;
            this.chkBatchTag.Text = "Batch Tag";
            this.chkBatchTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBatchTag.UseVisualStyleBackColor = false;
            this.chkBatchTag.CheckedChanged += new System.EventHandler(this.chkBatchTag_CheckedChanged);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.ForeColor = System.Drawing.Color.White;
            this.lblTags.Location = new System.Drawing.Point(0, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(46, 13);
            this.lblTags.TabIndex = 10;
            this.lblTags.Text = "Tags <>";
            this.lblTags.Click += new System.EventHandler(this.lblTags_Click);
            this.lblTags.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // pnlResizableTags
            // 
            this.pnlResizableTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResizableTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlResizableTags.Controls.Add(this.tagsSelectorImage);
            this.pnlResizableTags.Controls.Add(this.txtTags);
            this.pnlResizableTags.Location = new System.Drawing.Point(3, 234);
            this.pnlResizableTags.Name = "pnlResizableTags";
            this.pnlResizableTags.Size = new System.Drawing.Size(133, 155);
            this.pnlResizableTags.TabIndex = 9;
            this.pnlResizableTags.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseDown);
            this.pnlResizableTags.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseMove);
            this.pnlResizableTags.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseUp);
            // 
            // tagsSelectorImage
            // 
            this.tagsSelectorImage.AllowDrop = true;
            this.tagsSelectorImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsSelectorImage.BackColor = System.Drawing.Color.White;
            this.tagsSelectorImage.Location = new System.Drawing.Point(0, 0);
            this.tagsSelectorImage.Name = "tagsSelectorImage";
            this.tagsSelectorImage.Size = new System.Drawing.Size(133, 149);
            this.tagsSelectorImage.TabIndex = 4;
            this.tagsSelectorImage.Visible = false;
            // 
            // txtTags
            // 
            this.txtTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTags.BackColor = System.Drawing.Color.White;
            this.txtTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTags.Location = new System.Drawing.Point(0, 0);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(133, 149);
            this.txtTags.TabIndex = 0;
            this.txtTags.Text = "";
            this.txtTags.Leave += new System.EventHandler(this.txtTags_Leave);
            // 
            // lblTrainingData
            // 
            this.lblTrainingData.AutoSize = true;
            this.lblTrainingData.ForeColor = System.Drawing.Color.White;
            this.lblTrainingData.Location = new System.Drawing.Point(3, 395);
            this.lblTrainingData.Margin = new System.Windows.Forms.Padding(3);
            this.lblTrainingData.Name = "lblTrainingData";
            this.lblTrainingData.Size = new System.Drawing.Size(101, 13);
            this.lblTrainingData.TabIndex = 13;
            this.lblTrainingData.Text = "Training Sources ⏷";
            this.lblTrainingData.Click += new System.EventHandler(this.lblTrainingData_Click);
            this.lblTrainingData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // pnlResizableTrainingBounds
            // 
            this.pnlResizableTrainingBounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlResizableTrainingBounds.Controls.Add(this.gridTrainingSources);
            this.pnlResizableTrainingBounds.Location = new System.Drawing.Point(0, 411);
            this.pnlResizableTrainingBounds.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlResizableTrainingBounds.Name = "pnlResizableTrainingBounds";
            this.pnlResizableTrainingBounds.Size = new System.Drawing.Size(139, 96);
            this.pnlResizableTrainingBounds.TabIndex = 10;
            this.pnlResizableTrainingBounds.Visible = false;
            this.pnlResizableTrainingBounds.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseDown);
            this.pnlResizableTrainingBounds.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseMove);
            this.pnlResizableTrainingBounds.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseUp);
            // 
            // gridTrainingSources
            // 
            this.gridTrainingSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTrainingSources.BackgroundColor = System.Drawing.Color.White;
            this.gridTrainingSources.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTrainingSources.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTrainingSources.ColumnHeadersHeight = 18;
            this.gridTrainingSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTrainingSources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.W,
            this.H,
            this.Aspect});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTrainingSources.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridTrainingSources.Location = new System.Drawing.Point(0, 0);
            this.gridTrainingSources.Name = "gridTrainingSources";
            this.gridTrainingSources.RowHeadersWidth = 10;
            this.gridTrainingSources.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTrainingSources.ShowEditingIcon = false;
            this.gridTrainingSources.Size = new System.Drawing.Size(140, 90);
            this.gridTrainingSources.TabIndex = 4;
            this.gridTrainingSources.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridTrainingSources_EditingControlShowing);
            this.gridTrainingSources.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTrainingSources_RowEnter);
            // 
            // X
            // 
            dataGridViewCellStyle2.Format = "#0";
            dataGridViewCellStyle2.NullValue = null;
            this.X.DefaultCellStyle = dataGridViewCellStyle2;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 26;
            // 
            // Y
            // 
            dataGridViewCellStyle3.Format = "#0";
            dataGridViewCellStyle3.NullValue = null;
            this.Y.DefaultCellStyle = dataGridViewCellStyle3;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 26;
            // 
            // W
            // 
            dataGridViewCellStyle4.Format = "#0";
            dataGridViewCellStyle4.NullValue = null;
            this.W.DefaultCellStyle = dataGridViewCellStyle4;
            this.W.HeaderText = "W";
            this.W.Name = "W";
            this.W.Width = 26;
            // 
            // H
            // 
            dataGridViewCellStyle5.Format = "#0";
            dataGridViewCellStyle5.NullValue = null;
            this.H.DefaultCellStyle = dataGridViewCellStyle5;
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.Width = 26;
            // 
            // Aspect
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Aspect.DefaultCellStyle = dataGridViewCellStyle6;
            this.Aspect.HeaderText = "AR";
            this.Aspect.Name = "Aspect";
            this.Aspect.ReadOnly = true;
            this.Aspect.Width = 26;
            // 
            // lblDatabase
            // 
            this.lblDatabase.ForeColor = System.Drawing.Color.White;
            this.lblDatabase.Location = new System.Drawing.Point(3, 513);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(3);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(124, 13);
            this.lblDatabase.TabIndex = 16;
            this.lblDatabase.Text = "Database ⏷";
            this.lblDatabase.Click += new System.EventHandler(this.lblDatabase_Click);
            // 
            // pnlDatabase
            // 
            this.pnlDatabase.Controls.Add(this.btnSaveDatabase);
            this.pnlDatabase.Controls.Add(this.btnLoadDatabase);
            this.pnlDatabase.Controls.Add(this.txtDatabase);
            this.pnlDatabase.Location = new System.Drawing.Point(3, 532);
            this.pnlDatabase.Name = "pnlDatabase";
            this.pnlDatabase.Size = new System.Drawing.Size(133, 55);
            this.pnlDatabase.TabIndex = 4;
            this.pnlDatabase.Visible = false;
            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveDatabase.Location = new System.Drawing.Point(70, 3);
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.Size = new System.Drawing.Size(54, 23);
            this.btnSaveDatabase.TabIndex = 21;
            this.btnSaveDatabase.Text = "Save";
            this.btnSaveDatabase.UseVisualStyleBackColor = false;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);
            // 
            // btnLoadDatabase
            // 
            this.btnLoadDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadDatabase.Location = new System.Drawing.Point(6, 3);
            this.btnLoadDatabase.Name = "btnLoadDatabase";
            this.btnLoadDatabase.Size = new System.Drawing.Size(58, 23);
            this.btnLoadDatabase.TabIndex = 20;
            this.btnLoadDatabase.Text = "Load";
            this.btnLoadDatabase.UseVisualStyleBackColor = false;
            this.btnLoadDatabase.Click += new System.EventHandler(this.btnLoadDatabase_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(6, 30);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(118, 20);
            this.txtDatabase.TabIndex = 19;
            // 
            // lblSettings
            // 
            this.lblSettings.ForeColor = System.Drawing.Color.White;
            this.lblSettings.Location = new System.Drawing.Point(3, 593);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(3);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(124, 13);
            this.lblSettings.TabIndex = 14;
            this.lblSettings.Text = "Settings ⏷";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.lblScrollSpeed);
            this.pnlSettings.Controls.Add(this.numScrollSpeed);
            this.pnlSettings.Controls.Add(this.btnChangeBackground);
            this.pnlSettings.Controls.Add(this.cmbInterpolationModes);
            this.pnlSettings.Location = new System.Drawing.Point(3, 612);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(133, 63);
            this.pnlSettings.TabIndex = 15;
            this.pnlSettings.Visible = false;
            // 
            // lblScrollSpeed
            // 
            this.lblScrollSpeed.AutoSize = true;
            this.lblScrollSpeed.ForeColor = System.Drawing.Color.White;
            this.lblScrollSpeed.Location = new System.Drawing.Point(43, 10);
            this.lblScrollSpeed.Name = "lblScrollSpeed";
            this.lblScrollSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblScrollSpeed.TabIndex = 18;
            this.lblScrollSpeed.Text = "Speed:";
            // 
            // numScrollSpeed
            // 
            this.numScrollSpeed.DecimalPlaces = 1;
            this.numScrollSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numScrollSpeed.Location = new System.Drawing.Point(90, 8);
            this.numScrollSpeed.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numScrollSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numScrollSpeed.Name = "numScrollSpeed";
            this.numScrollSpeed.Size = new System.Drawing.Size(37, 20);
            this.numScrollSpeed.TabIndex = 17;
            this.numScrollSpeed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnChangeBackground
            // 
            this.btnChangeBackground.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeBackground.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChangeBackground.Location = new System.Drawing.Point(6, 5);
            this.btnChangeBackground.Name = "btnChangeBackground";
            this.btnChangeBackground.Size = new System.Drawing.Size(21, 23);
            this.btnChangeBackground.TabIndex = 14;
            this.btnChangeBackground.Text = "🎨";
            this.btnChangeBackground.UseVisualStyleBackColor = false;
            this.btnChangeBackground.Click += new System.EventHandler(this.chkChangeBackground_Click);
            // 
            // cmbInterpolationModes
            // 
            this.cmbInterpolationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterpolationModes.FormattingEnabled = true;
            this.cmbInterpolationModes.Location = new System.Drawing.Point(6, 34);
            this.cmbInterpolationModes.Name = "cmbInterpolationModes";
            this.cmbInterpolationModes.Size = new System.Drawing.Size(121, 21);
            this.cmbInterpolationModes.TabIndex = 16;
            this.cmbInterpolationModes.SelectedIndexChanged += new System.EventHandler(this.cmbInterpolationModes_SelectedIndexChanged);
            // 
            // btnCollapseSidePanel
            // 
            this.btnCollapseSidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollapseSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.btnCollapseSidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapseSidePanel.ForeColor = System.Drawing.Color.White;
            this.btnCollapseSidePanel.Location = new System.Drawing.Point(140, 960);
            this.btnCollapseSidePanel.Name = "btnCollapseSidePanel";
            this.btnCollapseSidePanel.Size = new System.Drawing.Size(19, 42);
            this.btnCollapseSidePanel.TabIndex = 3;
            this.btnCollapseSidePanel.Text = "<";
            this.btnCollapseSidePanel.UseVisualStyleBackColor = false;
            this.btnCollapseSidePanel.Click += new System.EventHandler(this.btnCollapseSidePanel_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.comboBox5);
            this.pnlRight.Controls.Add(this.comboBox1);
            this.pnlRight.Controls.Add(this.comboBox2);
            this.pnlRight.Controls.Add(this.comboBox3);
            this.pnlRight.Controls.Add(this.comboBox4);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.cmbTagDrag_13);
            this.pnlRight.Controls.Add(this.cmbTagDrag_12);
            this.pnlRight.Controls.Add(this.cmbTagDrag_11);
            this.pnlRight.Controls.Add(this.cmbTagDrag_10);
            this.pnlRight.Controls.Add(this.cmbTagDrag_9);
            this.pnlRight.Controls.Add(this.cmbTagDrag_8);
            this.pnlRight.Controls.Add(this.cmbTagDrag_7);
            this.pnlRight.Controls.Add(this.cmbTagDrag_6);
            this.pnlRight.Controls.Add(this.cmbTagDrag_5);
            this.pnlRight.Controls.Add(this.cmbTagDrag_4);
            this.pnlRight.Controls.Add(this.cmbTagDrag_3);
            this.pnlRight.Controls.Add(this.cmbTagDrag_2);
            this.pnlRight.Controls.Add(this.cmbTagDrag_1);
            this.pnlRight.Location = new System.Drawing.Point(1077, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(141, 1002);
            this.pnlRight.TabIndex = 4;
            this.pnlRight.Visible = false;
            // 
            // comboBox5
            // 
            this.comboBox5.AllowDrop = true;
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.IntegralHeight = false;
            this.comboBox5.Location = new System.Drawing.Point(8, 966);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(123, 33);
            this.comboBox5.TabIndex = 17;
            this.comboBox5.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.comboBox5.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(8, 912);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 33);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.comboBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // comboBox2
            // 
            this.comboBox2.AllowDrop = true;
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(8, 858);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(123, 33);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.comboBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // comboBox3
            // 
            this.comboBox3.AllowDrop = true;
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.IntegralHeight = false;
            this.comboBox3.Location = new System.Drawing.Point(8, 804);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(123, 33);
            this.comboBox3.TabIndex = 14;
            this.comboBox3.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.comboBox3.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // comboBox4
            // 
            this.comboBox4.AllowDrop = true;
            this.comboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.IntegralHeight = false;
            this.comboBox4.Location = new System.Drawing.Point(8, 750);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(123, 33);
            this.comboBox4.TabIndex = 13;
            this.comboBox4.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.comboBox4.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 49);
            this.label1.TabIndex = 11;
            this.label1.Text = "Drag & Drop Images Into Tags";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // cmbTagDrag_13
            // 
            this.cmbTagDrag_13.AllowDrop = true;
            this.cmbTagDrag_13.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_13.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_13.FormattingEnabled = true;
            this.cmbTagDrag_13.IntegralHeight = false;
            this.cmbTagDrag_13.Location = new System.Drawing.Point(8, 696);
            this.cmbTagDrag_13.Name = "cmbTagDrag_13";
            this.cmbTagDrag_13.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_13.TabIndex = 12;
            this.cmbTagDrag_13.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_13.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_12
            // 
            this.cmbTagDrag_12.AllowDrop = true;
            this.cmbTagDrag_12.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_12.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_12.FormattingEnabled = true;
            this.cmbTagDrag_12.IntegralHeight = false;
            this.cmbTagDrag_12.Location = new System.Drawing.Point(8, 642);
            this.cmbTagDrag_12.Name = "cmbTagDrag_12";
            this.cmbTagDrag_12.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_12.TabIndex = 11;
            this.cmbTagDrag_12.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_12.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_11
            // 
            this.cmbTagDrag_11.AllowDrop = true;
            this.cmbTagDrag_11.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_11.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_11.FormattingEnabled = true;
            this.cmbTagDrag_11.IntegralHeight = false;
            this.cmbTagDrag_11.Location = new System.Drawing.Point(8, 588);
            this.cmbTagDrag_11.Name = "cmbTagDrag_11";
            this.cmbTagDrag_11.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_11.TabIndex = 10;
            this.cmbTagDrag_11.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_11.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_10
            // 
            this.cmbTagDrag_10.AllowDrop = true;
            this.cmbTagDrag_10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_10.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_10.FormattingEnabled = true;
            this.cmbTagDrag_10.IntegralHeight = false;
            this.cmbTagDrag_10.Location = new System.Drawing.Point(8, 534);
            this.cmbTagDrag_10.Name = "cmbTagDrag_10";
            this.cmbTagDrag_10.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_10.TabIndex = 9;
            this.cmbTagDrag_10.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_10.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_9
            // 
            this.cmbTagDrag_9.AllowDrop = true;
            this.cmbTagDrag_9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_9.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_9.FormattingEnabled = true;
            this.cmbTagDrag_9.IntegralHeight = false;
            this.cmbTagDrag_9.Location = new System.Drawing.Point(8, 480);
            this.cmbTagDrag_9.Name = "cmbTagDrag_9";
            this.cmbTagDrag_9.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_9.TabIndex = 8;
            this.cmbTagDrag_9.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_9.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_8
            // 
            this.cmbTagDrag_8.AllowDrop = true;
            this.cmbTagDrag_8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_8.FormattingEnabled = true;
            this.cmbTagDrag_8.IntegralHeight = false;
            this.cmbTagDrag_8.Location = new System.Drawing.Point(8, 426);
            this.cmbTagDrag_8.Name = "cmbTagDrag_8";
            this.cmbTagDrag_8.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_8.TabIndex = 7;
            this.cmbTagDrag_8.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_8.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_7
            // 
            this.cmbTagDrag_7.AllowDrop = true;
            this.cmbTagDrag_7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_7.FormattingEnabled = true;
            this.cmbTagDrag_7.IntegralHeight = false;
            this.cmbTagDrag_7.Location = new System.Drawing.Point(8, 372);
            this.cmbTagDrag_7.Name = "cmbTagDrag_7";
            this.cmbTagDrag_7.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_7.TabIndex = 6;
            this.cmbTagDrag_7.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_7.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_6
            // 
            this.cmbTagDrag_6.AllowDrop = true;
            this.cmbTagDrag_6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_6.FormattingEnabled = true;
            this.cmbTagDrag_6.IntegralHeight = false;
            this.cmbTagDrag_6.Location = new System.Drawing.Point(8, 318);
            this.cmbTagDrag_6.Name = "cmbTagDrag_6";
            this.cmbTagDrag_6.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_6.TabIndex = 5;
            this.cmbTagDrag_6.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_6.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_5
            // 
            this.cmbTagDrag_5.AllowDrop = true;
            this.cmbTagDrag_5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_5.FormattingEnabled = true;
            this.cmbTagDrag_5.IntegralHeight = false;
            this.cmbTagDrag_5.Location = new System.Drawing.Point(8, 264);
            this.cmbTagDrag_5.Name = "cmbTagDrag_5";
            this.cmbTagDrag_5.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_5.TabIndex = 4;
            this.cmbTagDrag_5.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_5.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_4
            // 
            this.cmbTagDrag_4.AllowDrop = true;
            this.cmbTagDrag_4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_4.FormattingEnabled = true;
            this.cmbTagDrag_4.IntegralHeight = false;
            this.cmbTagDrag_4.Location = new System.Drawing.Point(8, 210);
            this.cmbTagDrag_4.Name = "cmbTagDrag_4";
            this.cmbTagDrag_4.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_4.TabIndex = 3;
            this.cmbTagDrag_4.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_4.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_3
            // 
            this.cmbTagDrag_3.AllowDrop = true;
            this.cmbTagDrag_3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_3.FormattingEnabled = true;
            this.cmbTagDrag_3.IntegralHeight = false;
            this.cmbTagDrag_3.Location = new System.Drawing.Point(8, 156);
            this.cmbTagDrag_3.Name = "cmbTagDrag_3";
            this.cmbTagDrag_3.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_3.TabIndex = 2;
            this.cmbTagDrag_3.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_3.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_2
            // 
            this.cmbTagDrag_2.AllowDrop = true;
            this.cmbTagDrag_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_2.FormattingEnabled = true;
            this.cmbTagDrag_2.IntegralHeight = false;
            this.cmbTagDrag_2.Location = new System.Drawing.Point(8, 102);
            this.cmbTagDrag_2.Name = "cmbTagDrag_2";
            this.cmbTagDrag_2.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_2.TabIndex = 1;
            this.cmbTagDrag_2.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_2.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // cmbTagDrag_1
            // 
            this.cmbTagDrag_1.AllowDrop = true;
            this.cmbTagDrag_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTagDrag_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTagDrag_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagDrag_1.FormattingEnabled = true;
            this.cmbTagDrag_1.IntegralHeight = false;
            this.cmbTagDrag_1.Location = new System.Drawing.Point(8, 48);
            this.cmbTagDrag_1.Name = "cmbTagDrag_1";
            this.cmbTagDrag_1.Size = new System.Drawing.Size(123, 33);
            this.cmbTagDrag_1.TabIndex = 0;
            this.cmbTagDrag_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragDrop);
            this.cmbTagDrag_1.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbTagDrag_DragEnter);
            // 
            // pnlFilterHeader
            // 
            this.pnlFilterHeader.Controls.Add(this.lblFilter);
            this.pnlFilterHeader.Location = new System.Drawing.Point(3, 0);
            this.pnlFilterHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlFilterHeader.Name = "pnlFilterHeader";
            this.pnlFilterHeader.Size = new System.Drawing.Size(133, 15);
            this.pnlFilterHeader.TabIndex = 17;
            // 
            // pnlTagsHeader
            // 
            this.pnlTagsHeader.Controls.Add(this.lblTags);
            this.pnlTagsHeader.Location = new System.Drawing.Point(3, 216);
            this.pnlTagsHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTagsHeader.Name = "pnlTagsHeader";
            this.pnlTagsHeader.Size = new System.Drawing.Size(133, 15);
            this.pnlTagsHeader.TabIndex = 16;
            // 
            // frmImageTaggerMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(222)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(1216, 1002);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.btnCollapseSidePanel);
            this.Controls.Add(this.pnlLeft);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageTaggerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Tagger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImageTaggerMain_FormClosing);
            this.Load += new System.EventHandler(this.form_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.form_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseEnter += new System.EventHandler(this.form_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.form_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.Resize += new System.EventHandler(this.frmImageTaggerMain_Resize);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftFlow.ResumeLayout(false);
            this.pnlLeftFlow.PerformLayout();
            this.pnlResizableFilter.ResumeLayout(false);
            this.pnlBatch.ResumeLayout(false);
            this.pnlBatch.PerformLayout();
            this.pnlResizableTags.ResumeLayout(false);
            this.pnlResizableTrainingBounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingSources)).EndInit();
            this.pnlDatabase.ResumeLayout(false);
            this.pnlDatabase.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollSpeed)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilterHeader.ResumeLayout(false);
            this.pnlFilterHeader.PerformLayout();
            this.pnlTagsHeader.ResumeLayout(false);
            this.pnlTagsHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.FlowLayoutPanel pnlLeftFlow;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnExitBatch;
        private System.Windows.Forms.Panel pnlResizableFilter;
        private System.Windows.Forms.Panel pnlResizableTags;
        private System.Windows.Forms.Button btnCollapseSidePanel;
        private System.Windows.Forms.Panel pnlBatch;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.CheckBox chkBatchTag;
        private System.Windows.Forms.Panel pnlResizableTrainingBounds;
        private System.Windows.Forms.Label lblTrainingData;
        private System.Windows.Forms.RichTextBox txtFilter;
        private System.Windows.Forms.RichTextBox txtTags;
        private System.Windows.Forms.Button btnChangeBackground;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.ComboBox cmbInterpolationModes;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.NumericUpDown numScrollSpeed;
        private System.Windows.Forms.Label lblScrollSpeed;
        private System.Windows.Forms.Button btnLoadDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Panel pnlDatabase;
        private System.Windows.Forms.Button btnSaveDatabase;
        private System.Windows.Forms.DataGridView gridTrainingSources;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aspect;
        private TagsSelector tagsSelectorImage;
        private TagsSelector tagSelectorFilter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ComboBox cmbTagDrag_13;
        private System.Windows.Forms.ComboBox cmbTagDrag_12;
        private System.Windows.Forms.ComboBox cmbTagDrag_11;
        private System.Windows.Forms.ComboBox cmbTagDrag_10;
        private System.Windows.Forms.ComboBox cmbTagDrag_9;
        private System.Windows.Forms.ComboBox cmbTagDrag_8;
        private System.Windows.Forms.ComboBox cmbTagDrag_7;
        private System.Windows.Forms.ComboBox cmbTagDrag_6;
        private System.Windows.Forms.ComboBox cmbTagDrag_5;
        private System.Windows.Forms.ComboBox cmbTagDrag_4;
        private System.Windows.Forms.ComboBox cmbTagDrag_3;
        private System.Windows.Forms.ComboBox cmbTagDrag_2;
        private System.Windows.Forms.ComboBox cmbTagDrag_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Panel pnlFilterHeader;
        private System.Windows.Forms.Panel pnlTagsHeader;
    }
}

