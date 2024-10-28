namespace TT_Edit.Forms
{
    partial class PageTextFormatControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GunaContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExportedFolderOpen = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnStop = new Guna.UI2.WinForms.Guna2Button();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.txtDocxExportFolderPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDocxFilesPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ContainerControl7 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ContainerControl8 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.gcpPendingFiles = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lblPendingFiles = new System.Windows.Forms.Label();
            this.guna2ContainerControl9 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2ContainerControl4 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ContainerControl5 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.gcpCompletedFiles = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lblCompletedFiles = new System.Windows.Forms.Label();
            this.guna2ContainerControl6 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDocxFolderPath = new System.Windows.Forms.Label();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.guna2ContainerControl3 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatusSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDocxFilesBrowse = new System.Windows.Forms.Button();
            this.lblDocxExportFolderPath = new System.Windows.Forms.Label();
            this.btnDocxExportFolderBrowse = new System.Windows.Forms.Button();
            this.guna2ContainerControl10 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.dgvFilesList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.stTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stTotalLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stRemoveBTN = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DocxfolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorkerConverter = new System.ComponentModel.BackgroundWorker();
            this.ErrorMessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.docxOFD = new System.Windows.Forms.OpenFileDialog();
            this.ResetAllbtn = new Guna.UI2.WinForms.Guna2Button();
            this.GunaContainer.SuspendLayout();
            this.guna2ContainerControl7.SuspendLayout();
            this.guna2ContainerControl8.SuspendLayout();
            this.guna2ContainerControl9.SuspendLayout();
            this.guna2ContainerControl4.SuspendLayout();
            this.guna2ContainerControl5.SuspendLayout();
            this.guna2ContainerControl6.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            this.guna2ContainerControl2.SuspendLayout();
            this.guna2ContainerControl3.SuspendLayout();
            this.guna2ContainerControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesList)).BeginInit();
            this.SuspendLayout();
            // 
            // GunaContainer
            // 
            this.GunaContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.GunaContainer.Controls.Add(this.ResetAllbtn);
            this.GunaContainer.Controls.Add(this.btnExportedFolderOpen);
            this.GunaContainer.Controls.Add(this.guna2Separator1);
            this.GunaContainer.Controls.Add(this.guna2Separator3);
            this.GunaContainer.Controls.Add(this.btnStop);
            this.GunaContainer.Controls.Add(this.btnStart);
            this.GunaContainer.Controls.Add(this.txtDocxExportFolderPath);
            this.GunaContainer.Controls.Add(this.txtDocxFilesPath);
            this.GunaContainer.Controls.Add(this.label9);
            this.GunaContainer.Controls.Add(this.guna2Separator2);
            this.GunaContainer.Controls.Add(this.guna2ContainerControl7);
            this.GunaContainer.Controls.Add(this.guna2ContainerControl4);
            this.GunaContainer.Controls.Add(this.lblDocxFolderPath);
            this.GunaContainer.Controls.Add(this.guna2ContainerControl1);
            this.GunaContainer.Controls.Add(this.cmbStatusSearch);
            this.GunaContainer.Controls.Add(this.txtSearchBox);
            this.GunaContainer.Controls.Add(this.btnDocxFilesBrowse);
            this.GunaContainer.Controls.Add(this.lblDocxExportFolderPath);
            this.GunaContainer.Controls.Add(this.btnDocxExportFolderBrowse);
            this.GunaContainer.Controls.Add(this.guna2ContainerControl10);
            this.GunaContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GunaContainer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.GunaContainer.Location = new System.Drawing.Point(0, 0);
            this.GunaContainer.Name = "GunaContainer";
            this.GunaContainer.Size = new System.Drawing.Size(1340, 749);
            this.GunaContainer.TabIndex = 2;
            // 
            // btnExportedFolderOpen
            // 
            this.btnExportedFolderOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportedFolderOpen.Animated = true;
            this.btnExportedFolderOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnExportedFolderOpen.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnExportedFolderOpen.BorderRadius = 5;
            this.btnExportedFolderOpen.BorderThickness = 1;
            this.btnExportedFolderOpen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportedFolderOpen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportedFolderOpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportedFolderOpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportedFolderOpen.Enabled = false;
            this.btnExportedFolderOpen.FillColor = System.Drawing.Color.Transparent;
            this.btnExportedFolderOpen.Font = new System.Drawing.Font("Arial", 12F);
            this.btnExportedFolderOpen.ForeColor = System.Drawing.Color.Black;
            this.btnExportedFolderOpen.Location = new System.Drawing.Point(1044, 125);
            this.btnExportedFolderOpen.Name = "btnExportedFolderOpen";
            this.btnExportedFolderOpen.Size = new System.Drawing.Size(260, 39);
            this.btnExportedFolderOpen.TabIndex = 27;
            this.btnExportedFolderOpen.Text = "Open Exported Folder";
            this.btnExportedFolderOpen.Click += new System.EventHandler(this.btnExportedFolderOpen_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.Location = new System.Drawing.Point(3, 461);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1335, 13);
            this.guna2Separator1.TabIndex = 24;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator3.Location = new System.Drawing.Point(1, 184);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(1336, 13);
            this.guna2Separator3.TabIndex = 23;
            // 
            // btnStop
            // 
            this.btnStop.Animated = true;
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnStop.BorderRadius = 5;
            this.btnStop.BorderThickness = 1;
            this.btnStop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStop.Enabled = false;
            this.btnStop.FillColor = System.Drawing.Color.Transparent;
            this.btnStop.Font = new System.Drawing.Font("Arial", 12F);
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Location = new System.Drawing.Point(218, 125);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(160, 39);
            this.btnStop.TabIndex = 22;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Animated = true;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnStart.BorderRadius = 5;
            this.btnStart.BorderThickness = 1;
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.Transparent;
            this.btnStart.Font = new System.Drawing.Font("Arial", 12F);
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(42, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 39);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtDocxExportFolderPath
            // 
            this.txtDocxExportFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocxExportFolderPath.BorderRadius = 8;
            this.txtDocxExportFolderPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocxExportFolderPath.DefaultText = "";
            this.txtDocxExportFolderPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDocxExportFolderPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDocxExportFolderPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDocxExportFolderPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDocxExportFolderPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDocxExportFolderPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocxExportFolderPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDocxExportFolderPath.Location = new System.Drawing.Point(233, 67);
            this.txtDocxExportFolderPath.Name = "txtDocxExportFolderPath";
            this.txtDocxExportFolderPath.PasswordChar = '\0';
            this.txtDocxExportFolderPath.PlaceholderText = "";
            this.txtDocxExportFolderPath.SelectedText = "";
            this.txtDocxExportFolderPath.Size = new System.Drawing.Size(958, 36);
            this.txtDocxExportFolderPath.TabIndex = 20;
            this.txtDocxExportFolderPath.TextChanged += new System.EventHandler(this.txtDocxExportFolderPath_TextChanged);
            // 
            // txtDocxFilesPath
            // 
            this.txtDocxFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocxFilesPath.BorderRadius = 8;
            this.txtDocxFilesPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocxFilesPath.DefaultText = "";
            this.txtDocxFilesPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDocxFilesPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDocxFilesPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDocxFilesPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDocxFilesPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDocxFilesPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocxFilesPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDocxFilesPath.Location = new System.Drawing.Point(233, 25);
            this.txtDocxFilesPath.Name = "txtDocxFilesPath";
            this.txtDocxFilesPath.PasswordChar = '\0';
            this.txtDocxFilesPath.PlaceholderText = "";
            this.txtDocxFilesPath.SelectedText = "";
            this.txtDocxFilesPath.Size = new System.Drawing.Size(958, 36);
            this.txtDocxFilesPath.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(37, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Overview";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.Location = new System.Drawing.Point(2, 391);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1336, 13);
            this.guna2Separator2.TabIndex = 18;
            // 
            // guna2ContainerControl7
            // 
            this.guna2ContainerControl7.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl7.BorderRadius = 10;
            this.guna2ContainerControl7.Controls.Add(this.guna2ContainerControl8);
            this.guna2ContainerControl7.Controls.Add(this.guna2ContainerControl9);
            this.guna2ContainerControl7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.guna2ContainerControl7.Location = new System.Drawing.Point(619, 258);
            this.guna2ContainerControl7.Name = "guna2ContainerControl7";
            this.guna2ContainerControl7.Padding = new System.Windows.Forms.Padding(5);
            this.guna2ContainerControl7.ShadowDecoration.BorderRadius = 15;
            this.guna2ContainerControl7.ShadowDecoration.Depth = 3;
            this.guna2ContainerControl7.ShadowDecoration.Enabled = true;
            this.guna2ContainerControl7.Size = new System.Drawing.Size(244, 110);
            this.guna2ContainerControl7.TabIndex = 17;
            this.guna2ContainerControl7.Text = "guna2ContainerControl7";
            // 
            // guna2ContainerControl8
            // 
            this.guna2ContainerControl8.BorderRadius = 5;
            this.guna2ContainerControl8.Controls.Add(this.gcpPendingFiles);
            this.guna2ContainerControl8.Controls.Add(this.lblPendingFiles);
            this.guna2ContainerControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ContainerControl8.Location = new System.Drawing.Point(5, 46);
            this.guna2ContainerControl8.Name = "guna2ContainerControl8";
            this.guna2ContainerControl8.Size = new System.Drawing.Size(234, 59);
            this.guna2ContainerControl8.TabIndex = 1;
            this.guna2ContainerControl8.Text = "guna2ContainerControl8";
            // 
            // gcpPendingFiles
            // 
            this.gcpPendingFiles.BackColor = System.Drawing.Color.Transparent;
            this.gcpPendingFiles.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.gcpPendingFiles.FillThickness = 4;
            this.gcpPendingFiles.Font = new System.Drawing.Font("Arial", 10F);
            this.gcpPendingFiles.ForeColor = System.Drawing.Color.Black;
            this.gcpPendingFiles.Location = new System.Drawing.Point(181, 3);
            this.gcpPendingFiles.Minimum = 0;
            this.gcpPendingFiles.Name = "gcpPendingFiles";
            this.gcpPendingFiles.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.gcpPendingFiles.ProgressColor = System.Drawing.Color.Coral;
            this.gcpPendingFiles.ProgressColor2 = System.Drawing.Color.Coral;
            this.gcpPendingFiles.ProgressThickness = 4;
            this.gcpPendingFiles.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gcpPendingFiles.ShowText = true;
            this.gcpPendingFiles.Size = new System.Drawing.Size(50, 50);
            this.gcpPendingFiles.TabIndex = 2;
            this.gcpPendingFiles.Text = "guna2CircleProgressBar2";
            // 
            // lblPendingFiles
            // 
            this.lblPendingFiles.AutoSize = true;
            this.lblPendingFiles.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingFiles.Location = new System.Drawing.Point(9, 10);
            this.lblPendingFiles.Name = "lblPendingFiles";
            this.lblPendingFiles.Size = new System.Drawing.Size(36, 39);
            this.lblPendingFiles.TabIndex = 0;
            this.lblPendingFiles.Text = "0";
            // 
            // guna2ContainerControl9
            // 
            this.guna2ContainerControl9.Controls.Add(this.label8);
            this.guna2ContainerControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl9.FillColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl9.Location = new System.Drawing.Point(5, 5);
            this.guna2ContainerControl9.Name = "guna2ContainerControl9";
            this.guna2ContainerControl9.Size = new System.Drawing.Size(234, 41);
            this.guna2ContainerControl9.TabIndex = 2;
            this.guna2ContainerControl9.Text = "guna2ContainerControl9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Pending Files";
            // 
            // guna2ContainerControl4
            // 
            this.guna2ContainerControl4.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl4.BorderRadius = 10;
            this.guna2ContainerControl4.Controls.Add(this.guna2ContainerControl5);
            this.guna2ContainerControl4.Controls.Add(this.guna2ContainerControl6);
            this.guna2ContainerControl4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.guna2ContainerControl4.Location = new System.Drawing.Point(330, 258);
            this.guna2ContainerControl4.Name = "guna2ContainerControl4";
            this.guna2ContainerControl4.Padding = new System.Windows.Forms.Padding(5);
            this.guna2ContainerControl4.ShadowDecoration.BorderRadius = 15;
            this.guna2ContainerControl4.ShadowDecoration.Depth = 3;
            this.guna2ContainerControl4.ShadowDecoration.Enabled = true;
            this.guna2ContainerControl4.Size = new System.Drawing.Size(244, 110);
            this.guna2ContainerControl4.TabIndex = 16;
            this.guna2ContainerControl4.Text = "guna2ContainerControl4";
            // 
            // guna2ContainerControl5
            // 
            this.guna2ContainerControl5.BorderRadius = 5;
            this.guna2ContainerControl5.Controls.Add(this.gcpCompletedFiles);
            this.guna2ContainerControl5.Controls.Add(this.lblCompletedFiles);
            this.guna2ContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ContainerControl5.Location = new System.Drawing.Point(5, 46);
            this.guna2ContainerControl5.Name = "guna2ContainerControl5";
            this.guna2ContainerControl5.Size = new System.Drawing.Size(234, 59);
            this.guna2ContainerControl5.TabIndex = 1;
            this.guna2ContainerControl5.Text = "guna2ContainerControl5";
            // 
            // gcpCompletedFiles
            // 
            this.gcpCompletedFiles.BackColor = System.Drawing.Color.Transparent;
            this.gcpCompletedFiles.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.gcpCompletedFiles.FillThickness = 4;
            this.gcpCompletedFiles.Font = new System.Drawing.Font("Arial", 10F);
            this.gcpCompletedFiles.ForeColor = System.Drawing.Color.Black;
            this.gcpCompletedFiles.Location = new System.Drawing.Point(169, 3);
            this.gcpCompletedFiles.Minimum = 0;
            this.gcpCompletedFiles.Name = "gcpCompletedFiles";
            this.gcpCompletedFiles.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.gcpCompletedFiles.ProgressColor = System.Drawing.Color.Blue;
            this.gcpCompletedFiles.ProgressThickness = 4;
            this.gcpCompletedFiles.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gcpCompletedFiles.ShowText = true;
            this.gcpCompletedFiles.Size = new System.Drawing.Size(50, 50);
            this.gcpCompletedFiles.TabIndex = 1;
            this.gcpCompletedFiles.Text = "guna2CircleProgressBar1";
            // 
            // lblCompletedFiles
            // 
            this.lblCompletedFiles.AutoSize = true;
            this.lblCompletedFiles.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedFiles.Location = new System.Drawing.Point(9, 10);
            this.lblCompletedFiles.Name = "lblCompletedFiles";
            this.lblCompletedFiles.Size = new System.Drawing.Size(36, 39);
            this.lblCompletedFiles.TabIndex = 0;
            this.lblCompletedFiles.Text = "0";
            // 
            // guna2ContainerControl6
            // 
            this.guna2ContainerControl6.Controls.Add(this.label6);
            this.guna2ContainerControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl6.FillColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl6.Location = new System.Drawing.Point(5, 5);
            this.guna2ContainerControl6.Name = "guna2ContainerControl6";
            this.guna2ContainerControl6.Size = new System.Drawing.Size(234, 41);
            this.guna2ContainerControl6.TabIndex = 2;
            this.guna2ContainerControl6.Text = "guna2ContainerControl6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Completed Files";
            // 
            // lblDocxFolderPath
            // 
            this.lblDocxFolderPath.AutoSize = true;
            this.lblDocxFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.lblDocxFolderPath.Location = new System.Drawing.Point(39, 34);
            this.lblDocxFolderPath.Name = "lblDocxFolderPath";
            this.lblDocxFolderPath.Size = new System.Drawing.Size(82, 18);
            this.lblDocxFolderPath.TabIndex = 1;
            this.lblDocxFolderPath.Text = "Docx Files";
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl1.BorderRadius = 10;
            this.guna2ContainerControl1.Controls.Add(this.guna2ContainerControl2);
            this.guna2ContainerControl1.Controls.Add(this.guna2ContainerControl3);
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.guna2ContainerControl1.Location = new System.Drawing.Point(42, 258);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Padding = new System.Windows.Forms.Padding(5);
            this.guna2ContainerControl1.ShadowDecoration.BorderRadius = 15;
            this.guna2ContainerControl1.ShadowDecoration.Depth = 3;
            this.guna2ContainerControl1.ShadowDecoration.Enabled = true;
            this.guna2ContainerControl1.Size = new System.Drawing.Size(244, 110);
            this.guna2ContainerControl1.TabIndex = 15;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.BorderRadius = 5;
            this.guna2ContainerControl2.Controls.Add(this.lblTotalFiles);
            this.guna2ContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ContainerControl2.Location = new System.Drawing.Point(5, 46);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(234, 59);
            this.guna2ContainerControl2.TabIndex = 1;
            this.guna2ContainerControl2.Text = "guna2ContainerControl2";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFiles.Location = new System.Drawing.Point(9, 10);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(36, 39);
            this.lblTotalFiles.TabIndex = 0;
            this.lblTotalFiles.Text = "0";
            // 
            // guna2ContainerControl3
            // 
            this.guna2ContainerControl3.Controls.Add(this.label3);
            this.guna2ContainerControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl3.Location = new System.Drawing.Point(5, 5);
            this.guna2ContainerControl3.Name = "guna2ContainerControl3";
            this.guna2ContainerControl3.Size = new System.Drawing.Size(234, 41);
            this.guna2ContainerControl3.TabIndex = 2;
            this.guna2ContainerControl3.Text = "guna2ContainerControl3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Files";
            // 
            // cmbStatusSearch
            // 
            this.cmbStatusSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatusSearch.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatusSearch.BorderRadius = 10;
            this.cmbStatusSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatusSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatusSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbStatusSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatusSearch.ItemHeight = 30;
            this.cmbStatusSearch.Items.AddRange(new object[] {
            "All",
            "Completed",
            "Running",
            "Pending"});
            this.cmbStatusSearch.Location = new System.Drawing.Point(1091, 410);
            this.cmbStatusSearch.Name = "cmbStatusSearch";
            this.cmbStatusSearch.Size = new System.Drawing.Size(213, 36);
            this.cmbStatusSearch.StartIndex = 0;
            this.cmbStatusSearch.TabIndex = 13;
            this.cmbStatusSearch.TextOffset = new System.Drawing.Point(5, 0);
            this.cmbStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cmbStatusSearch_SelectedIndexChanged);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BorderColor = System.Drawing.Color.LightGray;
            this.txtSearchBox.BorderRadius = 10;
            this.txtSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBox.DefaultText = "";
            this.txtSearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBox.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBox.IconLeft = global::TT_Edit.Properties.Resources.searchicon;
            this.txtSearchBox.IconLeftOffset = new System.Drawing.Point(8, 0);
            this.txtSearchBox.Location = new System.Drawing.Point(42, 410);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PasswordChar = '\0';
            this.txtSearchBox.PlaceholderText = "Search here...";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(422, 36);
            this.txtSearchBox.TabIndex = 12;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // btnDocxFilesBrowse
            // 
            this.btnDocxFilesBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocxFilesBrowse.Location = new System.Drawing.Point(1197, 25);
            this.btnDocxFilesBrowse.Name = "btnDocxFilesBrowse";
            this.btnDocxFilesBrowse.Size = new System.Drawing.Size(108, 36);
            this.btnDocxFilesBrowse.TabIndex = 2;
            this.btnDocxFilesBrowse.Text = "Browse";
            this.btnDocxFilesBrowse.UseVisualStyleBackColor = true;
            this.btnDocxFilesBrowse.Click += new System.EventHandler(this.btnDocxFilesBrowse_Click);
            // 
            // lblDocxExportFolderPath
            // 
            this.lblDocxExportFolderPath.AutoSize = true;
            this.lblDocxExportFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.lblDocxExportFolderPath.Location = new System.Drawing.Point(39, 76);
            this.lblDocxExportFolderPath.Name = "lblDocxExportFolderPath";
            this.lblDocxExportFolderPath.Size = new System.Drawing.Size(178, 18);
            this.lblDocxExportFolderPath.TabIndex = 4;
            this.lblDocxExportFolderPath.Text = "Docx Export Folder Path";
            // 
            // btnDocxExportFolderBrowse
            // 
            this.btnDocxExportFolderBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocxExportFolderBrowse.Location = new System.Drawing.Point(1197, 67);
            this.btnDocxExportFolderBrowse.Name = "btnDocxExportFolderBrowse";
            this.btnDocxExportFolderBrowse.Size = new System.Drawing.Size(108, 36);
            this.btnDocxExportFolderBrowse.TabIndex = 5;
            this.btnDocxExportFolderBrowse.Text = "Browse";
            this.btnDocxExportFolderBrowse.UseVisualStyleBackColor = true;
            this.btnDocxExportFolderBrowse.Click += new System.EventHandler(this.btnDocxExportFolderBrowse_Click);
            // 
            // guna2ContainerControl10
            // 
            this.guna2ContainerControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ContainerControl10.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2ContainerControl10.BorderThickness = 1;
            this.guna2ContainerControl10.Controls.Add(this.dgvFilesList);
            this.guna2ContainerControl10.Location = new System.Drawing.Point(42, 480);
            this.guna2ContainerControl10.Name = "guna2ContainerControl10";
            this.guna2ContainerControl10.Padding = new System.Windows.Forms.Padding(1);
            this.guna2ContainerControl10.Size = new System.Drawing.Size(1262, 257);
            this.guna2ContainerControl10.TabIndex = 26;
            this.guna2ContainerControl10.Text = "guna2ContainerControl10";
            // 
            // dgvFilesList
            // 
            this.dgvFilesList.AllowUserToAddRows = false;
            this.dgvFilesList.AllowUserToDeleteRows = false;
            this.dgvFilesList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFilesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilesList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvFilesList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilesList.ColumnHeadersHeight = 40;
            this.dgvFilesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stTitle,
            this.stTotalLines,
            this.stDateCreated,
            this.stStatus,
            this.stRemoveBTN});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilesList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilesList.GridColor = System.Drawing.Color.LightGray;
            this.dgvFilesList.Location = new System.Drawing.Point(1, 1);
            this.dgvFilesList.MultiSelect = false;
            this.dgvFilesList.Name = "dgvFilesList";
            this.dgvFilesList.ReadOnly = true;
            this.dgvFilesList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFilesList.RowHeadersVisible = false;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.dgvFilesList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFilesList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.dgvFilesList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFilesList.RowTemplate.DividerHeight = 1;
            this.dgvFilesList.RowTemplate.Height = 60;
            this.dgvFilesList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFilesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFilesList.Size = new System.Drawing.Size(1260, 255);
            this.dgvFilesList.TabIndex = 25;
            this.dgvFilesList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFilesList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvFilesList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFilesList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgvFilesList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFilesList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFilesList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvFilesList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFilesList.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvFilesList.ThemeStyle.ReadOnly = true;
            this.dgvFilesList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvFilesList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFilesList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFilesList.ThemeStyle.RowsStyle.Height = 60;
            this.dgvFilesList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvFilesList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFilesList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesList_CellContentClick);
            // 
            // stTitle
            // 
            this.stTitle.FillWeight = 93.27411F;
            this.stTitle.HeaderText = "File Title";
            this.stTitle.Name = "stTitle";
            this.stTitle.ReadOnly = true;
            // 
            // stTotalLines
            // 
            this.stTotalLines.FillWeight = 93.27411F;
            this.stTotalLines.HeaderText = "Total Lines";
            this.stTotalLines.Name = "stTotalLines";
            this.stTotalLines.ReadOnly = true;
            // 
            // stDateCreated
            // 
            this.stDateCreated.FillWeight = 93.27411F;
            this.stDateCreated.HeaderText = "Date Created";
            this.stDateCreated.Name = "stDateCreated";
            this.stDateCreated.ReadOnly = true;
            // 
            // stStatus
            // 
            this.stStatus.FillWeight = 93.27411F;
            this.stStatus.HeaderText = "Status";
            this.stStatus.Name = "stStatus";
            this.stStatus.ReadOnly = true;
            // 
            // stRemoveBTN
            // 
            this.stRemoveBTN.ActiveLinkColor = System.Drawing.Color.Blue;
            this.stRemoveBTN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.stRemoveBTN.DefaultCellStyle = dataGridViewCellStyle3;
            this.stRemoveBTN.FillWeight = 126.9036F;
            this.stRemoveBTN.HeaderText = "Action";
            this.stRemoveBTN.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.stRemoveBTN.LinkColor = System.Drawing.Color.Red;
            this.stRemoveBTN.Name = "stRemoveBTN";
            this.stRemoveBTN.ReadOnly = true;
            this.stRemoveBTN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stRemoveBTN.Text = "Remove";
            this.stRemoveBTN.ToolTipText = "Remove";
            this.stRemoveBTN.TrackVisitedState = false;
            this.stRemoveBTN.UseColumnTextForLinkValue = true;
            this.stRemoveBTN.Width = 56;
            // 
            // backgroundWorkerConverter
            // 
            this.backgroundWorkerConverter.WorkerReportsProgress = true;
            this.backgroundWorkerConverter.WorkerSupportsCancellation = true;
            this.backgroundWorkerConverter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerConverter_DoWork);
            // 
            // ErrorMessageDialog
            // 
            this.ErrorMessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.ErrorMessageDialog.Caption = "TT Edit";
            this.ErrorMessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.ErrorMessageDialog.Parent = null;
            this.ErrorMessageDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.ErrorMessageDialog.Text = null;
            // 
            // docxOFD
            // 
            this.docxOFD.DefaultExt = "docx";
            this.docxOFD.FileName = "Word file";
            this.docxOFD.Filter = "Docx Files|*.docx|Doc Files|*.doc|All Files|*.*";
            this.docxOFD.Multiselect = true;
            this.docxOFD.SupportMultiDottedExtensions = true;
            this.docxOFD.Title = "Select word files";
            // 
            // ResetAllbtn
            // 
            this.ResetAllbtn.Animated = true;
            this.ResetAllbtn.BackColor = System.Drawing.Color.Transparent;
            this.ResetAllbtn.BorderColor = System.Drawing.Color.Gainsboro;
            this.ResetAllbtn.BorderRadius = 5;
            this.ResetAllbtn.BorderThickness = 1;
            this.ResetAllbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetAllbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetAllbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetAllbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetAllbtn.FillColor = System.Drawing.Color.Transparent;
            this.ResetAllbtn.Font = new System.Drawing.Font("Arial", 12F);
            this.ResetAllbtn.ForeColor = System.Drawing.Color.Black;
            this.ResetAllbtn.Location = new System.Drawing.Point(394, 125);
            this.ResetAllbtn.Name = "ResetAllbtn";
            this.ResetAllbtn.Size = new System.Drawing.Size(160, 39);
            this.ResetAllbtn.TabIndex = 29;
            this.ResetAllbtn.Text = "Reset All";
            this.ResetAllbtn.Click += new System.EventHandler(this.ResetAllbtn_Click);
            // 
            // PageTextFormatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GunaContainer);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PageTextFormatControl";
            this.Size = new System.Drawing.Size(1340, 749);
            this.GunaContainer.ResumeLayout(false);
            this.GunaContainer.PerformLayout();
            this.guna2ContainerControl7.ResumeLayout(false);
            this.guna2ContainerControl8.ResumeLayout(false);
            this.guna2ContainerControl8.PerformLayout();
            this.guna2ContainerControl9.ResumeLayout(false);
            this.guna2ContainerControl9.PerformLayout();
            this.guna2ContainerControl4.ResumeLayout(false);
            this.guna2ContainerControl5.ResumeLayout(false);
            this.guna2ContainerControl5.PerformLayout();
            this.guna2ContainerControl6.ResumeLayout(false);
            this.guna2ContainerControl6.PerformLayout();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            this.guna2ContainerControl3.ResumeLayout(false);
            this.guna2ContainerControl3.PerformLayout();
            this.guna2ContainerControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel GunaContainer;
        private Guna.UI2.WinForms.Guna2Button btnExportedFolderOpen;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Button btnStop;
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private Guna.UI2.WinForms.Guna2TextBox txtDocxExportFolderPath;
        private Guna.UI2.WinForms.Guna2TextBox txtDocxFilesPath;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl7;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl8;
        private Guna.UI2.WinForms.Guna2CircleProgressBar gcpPendingFiles;
        private System.Windows.Forms.Label lblPendingFiles;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl9;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl4;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl5;
        private Guna.UI2.WinForms.Guna2CircleProgressBar gcpCompletedFiles;
        private System.Windows.Forms.Label lblCompletedFiles;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDocxFolderPath;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private System.Windows.Forms.Label lblTotalFiles;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatusSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private System.Windows.Forms.Button btnDocxFilesBrowse;
        private System.Windows.Forms.Label lblDocxExportFolderPath;
        private System.Windows.Forms.Button btnDocxExportFolderBrowse;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl10;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFilesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn stTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn stTotalLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn stDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn stStatus;
        private System.Windows.Forms.DataGridViewLinkColumn stRemoveBTN;
        private System.Windows.Forms.FolderBrowserDialog DocxfolderDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerConverter;
        private System.Windows.Forms.OpenFileDialog docxOFD;
        public Guna.UI2.WinForms.Guna2MessageDialog ErrorMessageDialog;
        private Guna.UI2.WinForms.Guna2Button ResetAllbtn;
    }
}
