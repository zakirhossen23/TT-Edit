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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtVTTFolderPath = new System.Windows.Forms.TextBox();
            this.lblVTTFolderPath = new System.Windows.Forms.Label();
            this.btnVTTFolderBrowse = new System.Windows.Forms.Button();
            this.btnVTTExportFolderBrowse = new System.Windows.Forms.Button();
            this.lblVTTExportFolderPath = new System.Windows.Forms.Label();
            this.txtVTTExportFolderPath = new System.Windows.Forms.TextBox();
            this.btnConvertAndExport = new System.Windows.Forms.Button();
            this.statusProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VTTfolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtVTTFolderPath
            // 
            this.txtVTTFolderPath.Location = new System.Drawing.Point(117, 95);
            this.txtVTTFolderPath.Name = "txtVTTFolderPath";
            this.txtVTTFolderPath.Size = new System.Drawing.Size(430, 26);
            this.txtVTTFolderPath.TabIndex = 0;
            this.txtVTTFolderPath.TextChanged += new System.EventHandler(this.txtVTTFolderPath_TextChanged);
            // 
            // lblVTTFolderPath
            // 
            this.lblVTTFolderPath.AutoSize = true;
            this.lblVTTFolderPath.Location = new System.Drawing.Point(22, 98);
            this.lblVTTFolderPath.Name = "lblVTTFolderPath";
            this.lblVTTFolderPath.Size = new System.Drawing.Size(89, 18);
            this.lblVTTFolderPath.TabIndex = 1;
            this.lblVTTFolderPath.Text = "Folder Path";
            // 
            // btnVTTFolderBrowse
            // 
            this.btnVTTFolderBrowse.Location = new System.Drawing.Point(554, 90);
            this.btnVTTFolderBrowse.Name = "btnVTTFolderBrowse";
            this.btnVTTFolderBrowse.Size = new System.Drawing.Size(93, 34);
            this.btnVTTFolderBrowse.TabIndex = 2;
            this.btnVTTFolderBrowse.Text = "Browse";
            this.btnVTTFolderBrowse.UseVisualStyleBackColor = true;
            this.btnVTTFolderBrowse.Click += new System.EventHandler(this.btnVTTFolderBrowse_Click);
            // 
            // btnVTTExportFolderBrowse
            // 
            this.btnVTTExportFolderBrowse.Location = new System.Drawing.Point(554, 130);
            this.btnVTTExportFolderBrowse.Name = "btnVTTExportFolderBrowse";
            this.btnVTTExportFolderBrowse.Size = new System.Drawing.Size(93, 34);
            this.btnVTTExportFolderBrowse.TabIndex = 5;
            this.btnVTTExportFolderBrowse.Text = "Browse";
            this.btnVTTExportFolderBrowse.UseVisualStyleBackColor = true;
            this.btnVTTExportFolderBrowse.Click += new System.EventHandler(this.btnVTTExportFolderBrowse_Click);
            // 
            // lblVTTExportFolderPath
            // 
            this.lblVTTExportFolderPath.AutoSize = true;
            this.lblVTTExportFolderPath.Location = new System.Drawing.Point(22, 138);
            this.lblVTTExportFolderPath.Name = "lblVTTExportFolderPath";
            this.lblVTTExportFolderPath.Size = new System.Drawing.Size(138, 18);
            this.lblVTTExportFolderPath.TabIndex = 4;
            this.lblVTTExportFolderPath.Text = "Export Folder Path";
            // 
            // txtVTTExportFolderPath
            // 
            this.txtVTTExportFolderPath.Location = new System.Drawing.Point(166, 135);
            this.txtVTTExportFolderPath.Name = "txtVTTExportFolderPath";
            this.txtVTTExportFolderPath.Size = new System.Drawing.Size(381, 26);
            this.txtVTTExportFolderPath.TabIndex = 3;
            this.txtVTTExportFolderPath.TextChanged += new System.EventHandler(this.txtVTTExportFolderPath_TextChanged);
            // 
            // btnConvertAndExport
            // 
            this.btnConvertAndExport.Location = new System.Drawing.Point(25, 247);
            this.btnConvertAndExport.Name = "btnConvertAndExport";
            this.btnConvertAndExport.Size = new System.Drawing.Size(622, 53);
            this.btnConvertAndExport.TabIndex = 6;
            this.btnConvertAndExport.Text = "Convert and Export";
            this.btnConvertAndExport.UseVisualStyleBackColor = true;
            this.btnConvertAndExport.Click += new System.EventHandler(this.btnConvertAndExport_Click);
            // 
            // statusProgress
            // 
            this.statusProgress.Location = new System.Drawing.Point(25, 213);
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(622, 5);
            this.statusProgress.TabIndex = 7;
            this.statusProgress.Value = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "TT Edit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 330);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusProgress);
            this.Controls.Add(this.btnConvertAndExport);
            this.Controls.Add(this.btnVTTExportFolderBrowse);
            this.Controls.Add(this.lblVTTExportFolderPath);
            this.Controls.Add(this.txtVTTExportFolderPath);
            this.Controls.Add(this.btnVTTFolderBrowse);
            this.Controls.Add(this.lblVTTFolderPath);
            this.Controls.Add(this.txtVTTFolderPath);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TT Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVTTFolderPath;
        private System.Windows.Forms.Label lblVTTFolderPath;
        private System.Windows.Forms.Button btnVTTFolderBrowse;
        private System.Windows.Forms.Button btnVTTExportFolderBrowse;
        private System.Windows.Forms.Label lblVTTExportFolderPath;
        private System.Windows.Forms.TextBox txtVTTExportFolderPath;
        private System.Windows.Forms.Button btnConvertAndExport;
        private System.Windows.Forms.ProgressBar statusProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog VTTfolderDialog;
    }
}

