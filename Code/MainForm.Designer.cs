namespace TT_Edit
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.ControlContainer = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.ICBHelp = new FontAwesome.Sharp.IconButton();
            this.ICBVttToDoc = new FontAwesome.Sharp.IconButton();
            this.ICBDocToVTT = new FontAwesome.Sharp.IconButton();
            this.ICBSubOrgLangMerger = new FontAwesome.Sharp.IconButton();
            this.ICBPageTextDeFormatter = new FontAwesome.Sharp.IconButton();
            this.ICBPageTextFormatter = new FontAwesome.Sharp.IconButton();
            this.ICBAtRemover = new FontAwesome.Sharp.IconButton();
            this.ICBCommaChecker = new FontAwesome.Sharp.IconButton();
            this.ICBCPLcounter = new FontAwesome.Sharp.IconButton();
            this.ICBSpaceRemover = new FontAwesome.Sharp.IconButton();
            this.ICBTimeframeDivider = new FontAwesome.Sharp.IconButton();
            this.ICBTimeframe = new FontAwesome.Sharp.IconButton();
            this.ICBConverter = new FontAwesome.Sharp.IconButton();
            this.ICBAtInserter = new FontAwesome.Sharp.IconButton();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.versionLabel = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gunaDragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.guna2Panel2.Controls.Add(this.ControlContainer);
            this.guna2Panel2.Controls.Add(this.guna2Panel1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1425, 694);
            this.guna2Panel2.TabIndex = 1;
            // 
            // ControlContainer
            // 
            this.ControlContainer.BackColor = System.Drawing.Color.Transparent;
            this.ControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlContainer.FillColor = System.Drawing.Color.Transparent;
            this.ControlContainer.Location = new System.Drawing.Point(304, 0);
            this.ControlContainer.Margin = new System.Windows.Forms.Padding(10);
            this.ControlContainer.Name = "ControlContainer";
            this.ControlContainer.Padding = new System.Windows.Forms.Padding(10);
            this.ControlContainer.Size = new System.Drawing.Size(1121, 694);
            this.ControlContainer.TabIndex = 1;
            this.ControlContainer.Text = "guna2ContainerControl1";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2Panel1.ShadowDecoration.Depth = 5;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.guna2Panel1.Size = new System.Drawing.Size(304, 694);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.White;
            this.guna2Panel4.Controls.Add(this.guna2Panel3);
            this.guna2Panel4.Controls.Add(this.guna2ContainerControl1);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(304, 694);
            this.guna2Panel4.TabIndex = 1;
            this.guna2Panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel4_Paint);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.AutoScroll = true;
            this.guna2Panel3.Controls.Add(this.ICBHelp);
            this.guna2Panel3.Controls.Add(this.ICBVttToDoc);
            this.guna2Panel3.Controls.Add(this.ICBDocToVTT);
            this.guna2Panel3.Controls.Add(this.ICBSubOrgLangMerger);
            this.guna2Panel3.Controls.Add(this.ICBPageTextDeFormatter);
            this.guna2Panel3.Controls.Add(this.ICBPageTextFormatter);
            this.guna2Panel3.Controls.Add(this.ICBAtRemover);
            this.guna2Panel3.Controls.Add(this.ICBCommaChecker);
            this.guna2Panel3.Controls.Add(this.ICBCPLcounter);
            this.guna2Panel3.Controls.Add(this.ICBSpaceRemover);
            this.guna2Panel3.Controls.Add(this.ICBTimeframeDivider);
            this.guna2Panel3.Controls.Add(this.ICBTimeframe);
            this.guna2Panel3.Controls.Add(this.ICBConverter);
            this.guna2Panel3.Controls.Add(this.ICBAtInserter);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 103);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.guna2Panel3.Size = new System.Drawing.Size(304, 591);
            this.guna2Panel3.TabIndex = 1;
            // 
            // ICBHelp
            // 
            this.ICBHelp.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBHelp.FlatAppearance.BorderSize = 0;
            this.ICBHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBHelp.ForeColor = System.Drawing.Color.Red;
            this.ICBHelp.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            this.ICBHelp.IconColor = System.Drawing.Color.Red;
            this.ICBHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBHelp.IconSize = 20;
            this.ICBHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBHelp.Location = new System.Drawing.Point(0, 668);
            this.ICBHelp.Margin = new System.Windows.Forms.Padding(0);
            this.ICBHelp.Name = "ICBHelp";
            this.ICBHelp.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBHelp.Size = new System.Drawing.Size(287, 51);
            this.ICBHelp.TabIndex = 10;
            this.ICBHelp.Text = "Help";
            this.ICBHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBHelp.UseVisualStyleBackColor = true;
            this.ICBHelp.Click += new System.EventHandler(this.ICBHelp_Click);
            // 
            // ICBVttToDoc
            // 
            this.ICBVttToDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBVttToDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBVttToDoc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBVttToDoc.FlatAppearance.BorderSize = 0;
            this.ICBVttToDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBVttToDoc.ForeColor = System.Drawing.Color.DimGray;
            this.ICBVttToDoc.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.ICBVttToDoc.IconColor = System.Drawing.Color.Gray;
            this.ICBVttToDoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBVttToDoc.IconSize = 20;
            this.ICBVttToDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBVttToDoc.Location = new System.Drawing.Point(0, 617);
            this.ICBVttToDoc.Margin = new System.Windows.Forms.Padding(0);
            this.ICBVttToDoc.Name = "ICBVttToDoc";
            this.ICBVttToDoc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBVttToDoc.Size = new System.Drawing.Size(287, 51);
            this.ICBVttToDoc.TabIndex = 15;
            this.ICBVttToDoc.Text = "VTT to Docx";
            this.ICBVttToDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBVttToDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBVttToDoc.UseVisualStyleBackColor = true;
            this.ICBVttToDoc.Click += new System.EventHandler(this.ICBVttToDoc_Click);
            // 
            // ICBDocToVTT
            // 
            this.ICBDocToVTT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBDocToVTT.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBDocToVTT.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBDocToVTT.FlatAppearance.BorderSize = 0;
            this.ICBDocToVTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBDocToVTT.ForeColor = System.Drawing.Color.DimGray;
            this.ICBDocToVTT.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.ICBDocToVTT.IconColor = System.Drawing.Color.Gray;
            this.ICBDocToVTT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBDocToVTT.IconSize = 20;
            this.ICBDocToVTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBDocToVTT.Location = new System.Drawing.Point(0, 566);
            this.ICBDocToVTT.Margin = new System.Windows.Forms.Padding(0);
            this.ICBDocToVTT.Name = "ICBDocToVTT";
            this.ICBDocToVTT.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBDocToVTT.Size = new System.Drawing.Size(287, 51);
            this.ICBDocToVTT.TabIndex = 14;
            this.ICBDocToVTT.Text = "Docx To VTT";
            this.ICBDocToVTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBDocToVTT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBDocToVTT.UseVisualStyleBackColor = true;
            this.ICBDocToVTT.Click += new System.EventHandler(this.ICBDocToVTT_Click);
            // 
            // ICBSubOrgLangMerger
            // 
            this.ICBSubOrgLangMerger.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBSubOrgLangMerger.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBSubOrgLangMerger.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBSubOrgLangMerger.FlatAppearance.BorderSize = 0;
            this.ICBSubOrgLangMerger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBSubOrgLangMerger.ForeColor = System.Drawing.Color.DimGray;
            this.ICBSubOrgLangMerger.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.ICBSubOrgLangMerger.IconColor = System.Drawing.Color.Gray;
            this.ICBSubOrgLangMerger.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBSubOrgLangMerger.IconSize = 20;
            this.ICBSubOrgLangMerger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBSubOrgLangMerger.Location = new System.Drawing.Point(0, 515);
            this.ICBSubOrgLangMerger.Margin = new System.Windows.Forms.Padding(0);
            this.ICBSubOrgLangMerger.Name = "ICBSubOrgLangMerger";
            this.ICBSubOrgLangMerger.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBSubOrgLangMerger.Size = new System.Drawing.Size(287, 51);
            this.ICBSubOrgLangMerger.TabIndex = 13;
            this.ICBSubOrgLangMerger.Text = "SUB Org+Lang Merger";
            this.ICBSubOrgLangMerger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBSubOrgLangMerger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBSubOrgLangMerger.UseVisualStyleBackColor = true;
            this.ICBSubOrgLangMerger.Click += new System.EventHandler(this.ICBSubOrgLangMerger_Click);
            // 
            // ICBPageTextDeFormatter
            // 
            this.ICBPageTextDeFormatter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBPageTextDeFormatter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBPageTextDeFormatter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBPageTextDeFormatter.FlatAppearance.BorderSize = 0;
            this.ICBPageTextDeFormatter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBPageTextDeFormatter.ForeColor = System.Drawing.Color.DimGray;
            this.ICBPageTextDeFormatter.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.ICBPageTextDeFormatter.IconColor = System.Drawing.Color.Gray;
            this.ICBPageTextDeFormatter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBPageTextDeFormatter.IconSize = 20;
            this.ICBPageTextDeFormatter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBPageTextDeFormatter.Location = new System.Drawing.Point(0, 464);
            this.ICBPageTextDeFormatter.Margin = new System.Windows.Forms.Padding(0);
            this.ICBPageTextDeFormatter.Name = "ICBPageTextDeFormatter";
            this.ICBPageTextDeFormatter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBPageTextDeFormatter.Size = new System.Drawing.Size(287, 51);
            this.ICBPageTextDeFormatter.TabIndex = 12;
            this.ICBPageTextDeFormatter.Text = "Pagetext Deformat";
            this.ICBPageTextDeFormatter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBPageTextDeFormatter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBPageTextDeFormatter.UseVisualStyleBackColor = true;
            this.ICBPageTextDeFormatter.Click += new System.EventHandler(this.ICBPageTextDeFormatter_Click);
            // 
            // ICBPageTextFormatter
            // 
            this.ICBPageTextFormatter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBPageTextFormatter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBPageTextFormatter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBPageTextFormatter.FlatAppearance.BorderSize = 0;
            this.ICBPageTextFormatter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBPageTextFormatter.ForeColor = System.Drawing.Color.DimGray;
            this.ICBPageTextFormatter.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.ICBPageTextFormatter.IconColor = System.Drawing.Color.Gray;
            this.ICBPageTextFormatter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBPageTextFormatter.IconSize = 20;
            this.ICBPageTextFormatter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBPageTextFormatter.Location = new System.Drawing.Point(0, 413);
            this.ICBPageTextFormatter.Margin = new System.Windows.Forms.Padding(0);
            this.ICBPageTextFormatter.Name = "ICBPageTextFormatter";
            this.ICBPageTextFormatter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBPageTextFormatter.Size = new System.Drawing.Size(287, 51);
            this.ICBPageTextFormatter.TabIndex = 11;
            this.ICBPageTextFormatter.Text = "Pagetext format";
            this.ICBPageTextFormatter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBPageTextFormatter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBPageTextFormatter.UseVisualStyleBackColor = true;
            this.ICBPageTextFormatter.Click += new System.EventHandler(this.ICBPageTextFormatter_Click);
            // 
            // ICBAtRemover
            // 
            this.ICBAtRemover.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBAtRemover.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBAtRemover.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBAtRemover.FlatAppearance.BorderSize = 0;
            this.ICBAtRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBAtRemover.ForeColor = System.Drawing.Color.DimGray;
            this.ICBAtRemover.IconChar = FontAwesome.Sharp.IconChar.At;
            this.ICBAtRemover.IconColor = System.Drawing.Color.Gray;
            this.ICBAtRemover.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBAtRemover.IconSize = 20;
            this.ICBAtRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBAtRemover.Location = new System.Drawing.Point(0, 362);
            this.ICBAtRemover.Margin = new System.Windows.Forms.Padding(0);
            this.ICBAtRemover.Name = "ICBAtRemover";
            this.ICBAtRemover.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBAtRemover.Size = new System.Drawing.Size(287, 51);
            this.ICBAtRemover.TabIndex = 9;
            this.ICBAtRemover.Text = "Remover";
            this.ICBAtRemover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBAtRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBAtRemover.UseVisualStyleBackColor = true;
            this.ICBAtRemover.Click += new System.EventHandler(this.ICBAtRemover_Click);
            // 
            // ICBCommaChecker
            // 
            this.ICBCommaChecker.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBCommaChecker.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBCommaChecker.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBCommaChecker.FlatAppearance.BorderSize = 0;
            this.ICBCommaChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBCommaChecker.ForeColor = System.Drawing.Color.DimGray;
            this.ICBCommaChecker.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.ICBCommaChecker.IconColor = System.Drawing.Color.Gray;
            this.ICBCommaChecker.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBCommaChecker.IconSize = 20;
            this.ICBCommaChecker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBCommaChecker.Location = new System.Drawing.Point(0, 311);
            this.ICBCommaChecker.Margin = new System.Windows.Forms.Padding(0);
            this.ICBCommaChecker.Name = "ICBCommaChecker";
            this.ICBCommaChecker.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBCommaChecker.Size = new System.Drawing.Size(287, 51);
            this.ICBCommaChecker.TabIndex = 6;
            this.ICBCommaChecker.Text = "Comma Checker";
            this.ICBCommaChecker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBCommaChecker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBCommaChecker.UseVisualStyleBackColor = true;
            this.ICBCommaChecker.Click += new System.EventHandler(this.ICBCommaChecker_Click);
            // 
            // ICBCPLcounter
            // 
            this.ICBCPLcounter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBCPLcounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBCPLcounter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBCPLcounter.FlatAppearance.BorderSize = 0;
            this.ICBCPLcounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBCPLcounter.ForeColor = System.Drawing.Color.DimGray;
            this.ICBCPLcounter.IconChar = FontAwesome.Sharp.IconChar.SortNumericDown;
            this.ICBCPLcounter.IconColor = System.Drawing.Color.Gray;
            this.ICBCPLcounter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBCPLcounter.IconSize = 20;
            this.ICBCPLcounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBCPLcounter.Location = new System.Drawing.Point(0, 260);
            this.ICBCPLcounter.Margin = new System.Windows.Forms.Padding(0);
            this.ICBCPLcounter.Name = "ICBCPLcounter";
            this.ICBCPLcounter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBCPLcounter.Size = new System.Drawing.Size(287, 51);
            this.ICBCPLcounter.TabIndex = 5;
            this.ICBCPLcounter.Text = "CPL Counter";
            this.ICBCPLcounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBCPLcounter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBCPLcounter.UseVisualStyleBackColor = true;
            this.ICBCPLcounter.Click += new System.EventHandler(this.ICBCPLcounter_Click);
            // 
            // ICBSpaceRemover
            // 
            this.ICBSpaceRemover.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBSpaceRemover.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBSpaceRemover.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBSpaceRemover.FlatAppearance.BorderSize = 0;
            this.ICBSpaceRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBSpaceRemover.ForeColor = System.Drawing.Color.DimGray;
            this.ICBSpaceRemover.IconChar = FontAwesome.Sharp.IconChar.Outdent;
            this.ICBSpaceRemover.IconColor = System.Drawing.Color.Gray;
            this.ICBSpaceRemover.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBSpaceRemover.IconSize = 20;
            this.ICBSpaceRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBSpaceRemover.Location = new System.Drawing.Point(0, 209);
            this.ICBSpaceRemover.Margin = new System.Windows.Forms.Padding(0);
            this.ICBSpaceRemover.Name = "ICBSpaceRemover";
            this.ICBSpaceRemover.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBSpaceRemover.Size = new System.Drawing.Size(287, 51);
            this.ICBSpaceRemover.TabIndex = 4;
            this.ICBSpaceRemover.Text = "Space Eraser";
            this.ICBSpaceRemover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBSpaceRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBSpaceRemover.UseVisualStyleBackColor = true;
            this.ICBSpaceRemover.Click += new System.EventHandler(this.ICBSpaceRemover_Click);
            // 
            // ICBTimeframeDivider
            // 
            this.ICBTimeframeDivider.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBTimeframeDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBTimeframeDivider.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBTimeframeDivider.FlatAppearance.BorderSize = 0;
            this.ICBTimeframeDivider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBTimeframeDivider.ForeColor = System.Drawing.Color.DimGray;
            this.ICBTimeframeDivider.IconChar = FontAwesome.Sharp.IconChar.Divide;
            this.ICBTimeframeDivider.IconColor = System.Drawing.Color.Gray;
            this.ICBTimeframeDivider.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBTimeframeDivider.IconSize = 20;
            this.ICBTimeframeDivider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBTimeframeDivider.Location = new System.Drawing.Point(0, 158);
            this.ICBTimeframeDivider.Margin = new System.Windows.Forms.Padding(0);
            this.ICBTimeframeDivider.Name = "ICBTimeframeDivider";
            this.ICBTimeframeDivider.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBTimeframeDivider.Size = new System.Drawing.Size(287, 51);
            this.ICBTimeframeDivider.TabIndex = 7;
            this.ICBTimeframeDivider.Text = "TImeframe Divider";
            this.ICBTimeframeDivider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBTimeframeDivider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBTimeframeDivider.UseVisualStyleBackColor = true;
            this.ICBTimeframeDivider.Click += new System.EventHandler(this.ICBTimeframeDivider_Click);
            // 
            // ICBTimeframe
            // 
            this.ICBTimeframe.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBTimeframe.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBTimeframe.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBTimeframe.FlatAppearance.BorderSize = 0;
            this.ICBTimeframe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBTimeframe.ForeColor = System.Drawing.Color.DimGray;
            this.ICBTimeframe.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.ICBTimeframe.IconColor = System.Drawing.Color.Gray;
            this.ICBTimeframe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBTimeframe.IconSize = 20;
            this.ICBTimeframe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBTimeframe.Location = new System.Drawing.Point(0, 107);
            this.ICBTimeframe.Margin = new System.Windows.Forms.Padding(0);
            this.ICBTimeframe.Name = "ICBTimeframe";
            this.ICBTimeframe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBTimeframe.Size = new System.Drawing.Size(287, 51);
            this.ICBTimeframe.TabIndex = 3;
            this.ICBTimeframe.Text = "TImeframe Uniting";
            this.ICBTimeframe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBTimeframe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBTimeframe.UseVisualStyleBackColor = true;
            this.ICBTimeframe.Click += new System.EventHandler(this.ICBTimeframe_Click);
            // 
            // ICBConverter
            // 
            this.ICBConverter.BackColor = System.Drawing.Color.White;
            this.ICBConverter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBConverter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBConverter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBConverter.FlatAppearance.BorderSize = 0;
            this.ICBConverter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBConverter.ForeColor = System.Drawing.Color.DimGray;
            this.ICBConverter.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.ICBConverter.IconColor = System.Drawing.Color.Gray;
            this.ICBConverter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBConverter.IconSize = 20;
            this.ICBConverter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBConverter.Location = new System.Drawing.Point(0, 56);
            this.ICBConverter.Margin = new System.Windows.Forms.Padding(0);
            this.ICBConverter.Name = "ICBConverter";
            this.ICBConverter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBConverter.Size = new System.Drawing.Size(287, 51);
            this.ICBConverter.TabIndex = 1;
            this.ICBConverter.Text = "Converter";
            this.ICBConverter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBConverter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBConverter.UseVisualStyleBackColor = false;
            this.ICBConverter.Click += new System.EventHandler(this.ICBConverter_Click);
            // 
            // ICBAtInserter
            // 
            this.ICBAtInserter.Cursor = System.Windows.Forms.Cursors.Default;
            this.ICBAtInserter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ICBAtInserter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ICBAtInserter.FlatAppearance.BorderSize = 0;
            this.ICBAtInserter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ICBAtInserter.ForeColor = System.Drawing.Color.DimGray;
            this.ICBAtInserter.IconChar = FontAwesome.Sharp.IconChar.At;
            this.ICBAtInserter.IconColor = System.Drawing.Color.Gray;
            this.ICBAtInserter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ICBAtInserter.IconSize = 20;
            this.ICBAtInserter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBAtInserter.Location = new System.Drawing.Point(0, 5);
            this.ICBAtInserter.Margin = new System.Windows.Forms.Padding(0);
            this.ICBAtInserter.Name = "ICBAtInserter";
            this.ICBAtInserter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.ICBAtInserter.Size = new System.Drawing.Size(287, 51);
            this.ICBAtInserter.TabIndex = 8;
            this.ICBAtInserter.Text = "Inserter";
            this.ICBAtInserter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ICBAtInserter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ICBAtInserter.UseVisualStyleBackColor = true;
            this.ICBAtInserter.Click += new System.EventHandler(this.ICBAtInserter_Click);
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl1.Controls.Add(this.versionLabel);
            this.guna2ContainerControl1.Controls.Add(this.guna2PictureBox2);
            this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(304, 103);
            this.guna2ContainerControl1.TabIndex = 1;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            this.guna2ContainerControl1.UseTransparentBackground = true;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(90)))));
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(2, 75);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(79, 27);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "v1.1.4";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(90)))));
            this.guna2PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(90)))));
            this.guna2PictureBox2.Image = global::TT_Edit.Properties.Resources.icon;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(304, 103);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            // 
            // gunaDragControl
            // 
            this.gunaDragControl.DockIndicatorTransparencyValue = 0.6D;
            this.gunaDragControl.UseTransparentDrag = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 0;
            this.guna2Elipse1.TargetControl = this.versionLabel;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1425, 694);
            this.Controls.Add(this.guna2Panel2);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TT Edit";
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2ContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DragControl gunaDragControl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private FontAwesome.Sharp.IconButton ICBConverter;
        private Guna.UI2.WinForms.Guna2ContainerControl ControlContainer;
        private FontAwesome.Sharp.IconButton ICBTimeframe;
        private FontAwesome.Sharp.IconButton ICBSpaceRemover;
        private FontAwesome.Sharp.IconButton ICBCPLcounter;
        private FontAwesome.Sharp.IconButton ICBCommaChecker;
        private FontAwesome.Sharp.IconButton ICBTimeframeDivider;
        private FontAwesome.Sharp.IconButton ICBAtInserter;
        private FontAwesome.Sharp.IconButton ICBAtRemover;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label versionLabel;
        private FontAwesome.Sharp.IconButton ICBHelp;
        private FontAwesome.Sharp.IconButton ICBPageTextFormatter;
        private FontAwesome.Sharp.IconButton ICBPageTextDeFormatter;
        private FontAwesome.Sharp.IconButton ICBSubOrgLangMerger;
        private FontAwesome.Sharp.IconButton ICBDocToVTT;
        private FontAwesome.Sharp.IconButton ICBVttToDoc;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
    }
}

