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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlResizableFilter = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.RichTextBox();
            this.pnlBatch = new System.Windows.Forms.Panel();
            this.btnExitBatch = new System.Windows.Forms.Button();
            this.chkBatchTag = new System.Windows.Forms.CheckBox();
            this.lblImageHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.pnlLeft.SuspendLayout();
            this.pnlLeftFlow.SuspendLayout();
            this.pnlResizableFilter.SuspendLayout();
            this.pnlBatch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlResizableTrainingBounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingSources)).BeginInit();
            this.pnlDatabase.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollSpeed)).BeginInit();
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
            this.pnlLeft.Size = new System.Drawing.Size(141, 843);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlLeftFlow
            // 
            this.pnlLeftFlow.AutoScroll = true;
            this.pnlLeftFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(106)))), ((int)(((byte)(109)))));
            this.pnlLeftFlow.Controls.Add(this.lblFilter);
            this.pnlLeftFlow.Controls.Add(this.pnlResizableFilter);
            this.pnlLeftFlow.Controls.Add(this.pnlBatch);
            this.pnlLeftFlow.Controls.Add(this.lblImageHeader);
            this.pnlLeftFlow.Controls.Add(this.panel1);
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
            this.pnlLeftFlow.Size = new System.Drawing.Size(139, 841);
            this.pnlLeftFlow.TabIndex = 0;
            this.pnlLeftFlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Filter";
            this.lblFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // pnlResizableFilter
            // 
            this.pnlResizableFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlResizableFilter.Controls.Add(this.txtFilter);
            this.pnlResizableFilter.Location = new System.Drawing.Point(3, 16);
            this.pnlResizableFilter.Name = "pnlResizableFilter";
            this.pnlResizableFilter.Size = new System.Drawing.Size(133, 102);
            this.pnlResizableFilter.TabIndex = 8;
            this.pnlResizableFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseDown);
            this.pnlResizableFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseMove);
            this.pnlResizableFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseUp);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Location = new System.Drawing.Point(0, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(136, 96);
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
            this.pnlBatch.Location = new System.Drawing.Point(3, 124);
            this.pnlBatch.Name = "pnlBatch";
            this.pnlBatch.Size = new System.Drawing.Size(133, 55);
            this.pnlBatch.TabIndex = 11;
            this.pnlBatch.Visible = false;
            // 
            // btnExitBatch
            // 
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
            // lblImageHeader
            // 
            this.lblImageHeader.AutoSize = true;
            this.lblImageHeader.ForeColor = System.Drawing.Color.White;
            this.lblImageHeader.Location = new System.Drawing.Point(3, 182);
            this.lblImageHeader.Name = "lblImageHeader";
            this.lblImageHeader.Size = new System.Drawing.Size(31, 13);
            this.lblImageHeader.TabIndex = 10;
            this.lblImageHeader.Text = "Tags";
            this.lblImageHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clearFocus_click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.txtTags);
            this.panel1.Location = new System.Drawing.Point(3, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 238);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResizeable_MouseUp);
            // 
            // txtTags
            // 
            this.txtTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTags.Location = new System.Drawing.Point(0, 0);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(133, 232);
            this.txtTags.TabIndex = 0;
            this.txtTags.Text = "";
            this.txtTags.Leave += new System.EventHandler(this.txtTags_Leave);
            // 
            // lblTrainingData
            // 
            this.lblTrainingData.AutoSize = true;
            this.lblTrainingData.ForeColor = System.Drawing.Color.White;
            this.lblTrainingData.Location = new System.Drawing.Point(3, 442);
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
            this.pnlResizableTrainingBounds.Location = new System.Drawing.Point(0, 458);
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTrainingSources.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridTrainingSources.ColumnHeadersHeight = 18;
            this.gridTrainingSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTrainingSources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.W,
            this.H,
            this.Aspect});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTrainingSources.DefaultCellStyle = dataGridViewCellStyle21;
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
            dataGridViewCellStyle16.Format = "#0";
            dataGridViewCellStyle16.NullValue = null;
            this.X.DefaultCellStyle = dataGridViewCellStyle16;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 26;
            // 
            // Y
            // 
            dataGridViewCellStyle17.Format = "#0";
            dataGridViewCellStyle17.NullValue = null;
            this.Y.DefaultCellStyle = dataGridViewCellStyle17;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 26;
            // 
            // W
            // 
            dataGridViewCellStyle18.Format = "#0";
            dataGridViewCellStyle18.NullValue = null;
            this.W.DefaultCellStyle = dataGridViewCellStyle18;
            this.W.HeaderText = "W";
            this.W.Name = "W";
            this.W.Width = 26;
            // 
            // H
            // 
            dataGridViewCellStyle19.Format = "#0";
            dataGridViewCellStyle19.NullValue = null;
            this.H.DefaultCellStyle = dataGridViewCellStyle19;
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.Width = 26;
            // 
            // Aspect
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Aspect.DefaultCellStyle = dataGridViewCellStyle20;
            this.Aspect.HeaderText = "AR";
            this.Aspect.Name = "Aspect";
            this.Aspect.ReadOnly = true;
            this.Aspect.Width = 26;
            // 
            // lblDatabase
            // 
            this.lblDatabase.ForeColor = System.Drawing.Color.White;
            this.lblDatabase.Location = new System.Drawing.Point(3, 560);
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
            this.pnlDatabase.Location = new System.Drawing.Point(3, 579);
            this.pnlDatabase.Name = "pnlDatabase";
            this.pnlDatabase.Size = new System.Drawing.Size(130, 55);
            this.pnlDatabase.TabIndex = 4;
            this.pnlDatabase.Visible = false;
            // 
            // btnSaveDatabase
            // 
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
            this.txtDatabase.Location = new System.Drawing.Point(6, 30);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(118, 20);
            this.txtDatabase.TabIndex = 19;
            // 
            // lblSettings
            // 
            this.lblSettings.ForeColor = System.Drawing.Color.White;
            this.lblSettings.Location = new System.Drawing.Point(3, 640);
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
            this.pnlSettings.Location = new System.Drawing.Point(3, 659);
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
            this.btnCollapseSidePanel.Location = new System.Drawing.Point(140, 801);
            this.btnCollapseSidePanel.Name = "btnCollapseSidePanel";
            this.btnCollapseSidePanel.Size = new System.Drawing.Size(19, 42);
            this.btnCollapseSidePanel.TabIndex = 3;
            this.btnCollapseSidePanel.Text = "<";
            this.btnCollapseSidePanel.UseVisualStyleBackColor = false;
            this.btnCollapseSidePanel.Click += new System.EventHandler(this.btnCollapseSidePanel_Click);
            // 
            // frmImageTaggerMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(222)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(990, 843);
            this.Controls.Add(this.btnCollapseSidePanel);
            this.Controls.Add(this.pnlLeft);
            this.DoubleBuffered = true;
            this.Name = "frmImageTaggerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Tagger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            this.panel1.ResumeLayout(false);
            this.pnlResizableTrainingBounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingSources)).EndInit();
            this.pnlDatabase.ResumeLayout(false);
            this.pnlDatabase.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.FlowLayoutPanel pnlLeftFlow;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnExitBatch;
        private System.Windows.Forms.Panel pnlResizableFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCollapseSidePanel;
        private System.Windows.Forms.Panel pnlBatch;
        private System.Windows.Forms.Label lblImageHeader;
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
    }
}

