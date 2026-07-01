using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TT_Edit.Classes;
using TT_Edit.Properties;

namespace TT_Edit.Forms
{
    public partial class BilingualInjectControl : UserControl
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int pendingFiles = 0;
        public static int percentageDone = 0;
        public static int percentagePending = 0;
        public static string combinedFilesPath = "";
        public static string vTTExportfolderPath = "";

        private List<VttParagraphToBilingual> allCombinedFiles = new List<VttParagraphToBilingual>();
        private System.Threading.CancellationTokenSource cts;

        public BilingualInjectControl()
        {
            InitializeComponent();
        }

        // Event Handler to Open Folder Browser for Combined files
        private void btnCombinedFilesBrowse_Click(object sender, EventArgs e)
        {
            if (combinedOFD.ShowDialog() == DialogResult.OK)
            {
                string[] allFiles = (from file in combinedOFD.FileNames where Path.GetExtension(file).ToLower() == ".txt" select file).ToArray();
                txtCombinedFilesPath.Text = String.Join(", ", allFiles);
                combinedFilesPath = txtCombinedFilesPath.Text;

                if (allFiles.Length == 0)
                {
                    ErrorMessageDialog.Text = "No combined files to reconstruct";
                    ErrorMessageDialog.Show();
                }

                loadFiles(allFiles);
            }
        }

        // Event Handler to opening Export Folder Browser
        private void btnExportFolderBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog { IsFolderPicker = true };

            if (folderBrowser.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                txtExportFolderPath.Text = folderBrowser.FileName;
                vTTExportfolderPath = txtExportFolderPath.Text;
            }
        }

        /********************** Functions ******************/
        void loadFiles(string[] files)
        {
            if (txtCombinedFilesPath.Text != "")
            {
                allCombinedFiles.Clear();
                foreach (var file in files)
                {
                    string filename = Path.GetFileName(file);
                    var newfile = new VttParagraphToBilingual(file, filename);
                    allCombinedFiles.Add(newfile);
                }
            }
            updateStatus();
            loadData();

            // Automatically start conversion if export path is already set
            if (!string.IsNullOrEmpty(txtExportFolderPath.Text))
            {
                btnStart_Click(null, null);
            }
        }

        void updateStatus()
        {
            var allPending = from file in allCombinedFiles where file.status == "Pending" select file;
            var allCompleted = from file in allCombinedFiles where file.status == "Completed" select file;

            totalFiles = allCombinedFiles.Count();
            doneFiles = allCompleted.Count();
            pendingFiles = allPending.Count();

            if (totalFiles != 0)
            {
                percentageDone = (int)((float)doneFiles / totalFiles * 100);
                percentagePending = (int)((float)pendingFiles / totalFiles * 100);
            }
            else
            {
                percentageDone = 0;
                percentagePending = 0;
            }

            lblTotalFiles.Text = totalFiles.ToString();
            lblCompletedFiles.Text = doneFiles.ToString();
            lblPendingFiles.Text = pendingFiles.ToString();

            gcpCompletedFiles.Value = percentageDone;
            gcpPendingFiles.Value = percentagePending;
        }

        void updateDGV()
        {
            foreach (DataGridViewRow rowItem in dgvFilesList.Rows)
            {
                string statusText = rowItem.Cells["stStatus"].Value?.ToString() ?? "";

                if (statusText == "Pending") rowItem.Cells["stStatus"].Style.ForeColor = Color.Coral;
                if (statusText == "Completed") rowItem.Cells["stStatus"].Style.ForeColor = Color.Lime;
                if (statusText == "Running") rowItem.Cells["stStatus"].Style.ForeColor = Color.Blue;
                if (statusText == "Format Error") rowItem.Cells["stStatus"].Style.ForeColor = Color.Red;
            }
        }

        void refreshEverything(List<VttParagraphToBilingual> loadToView = null)
        {
            updateStatus();
            loadToView = loadToView == null ? allCombinedFiles : loadToView;
            loadData(loadToView);
        }

        void loadData(List<VttParagraphToBilingual> loadToView = null)
        {
            loadToView = loadToView == null ? allCombinedFiles : loadToView;
            dgvFilesList.Rows.Clear();
            foreach (VttParagraphToBilingual item in loadToView)
            {
                dgvFilesList.Rows.Add(new string[] { item.name, item.date_created.ToString("dd/MM/yyyy"), item.status });
            }
            updateDGV();
        }

        private void dgvFilesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell selectedCell = dgvFilesList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (selectedCell.ColumnIndex == dgvFilesList.Columns["stRemoveBTN"].Index)
                {
                    allCombinedFiles.RemoveAt(e.RowIndex);
                    refreshEverything();
                }
            }
        }

        private void cmbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusSearch.Text != "All")
            {
                List<VttParagraphToBilingual> searchedFiles = (from file in allCombinedFiles where file.status == cmbStatusSearch.Text select file).ToList();
                refreshEverything(searchedFiles);
            }
            else
            {
                refreshEverything();
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            List<VttParagraphToBilingual> searchedFiles = (from file in allCombinedFiles where file.name.Contains(txtSearchBox.Text) select file).ToList();
            refreshEverything(searchedFiles);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ErrorMessageDialog.Text = "";
            if (txtCombinedFilesPath.Text == "") ErrorMessageDialog.Text = "Please select Combined files";
            if (txtExportFolderPath.Text == "") ErrorMessageDialog.Text = "Please enter export folder Path";
            if (allCombinedFiles.Count == 0) ErrorMessageDialog.Text = "No files to reconstruct";

            if (ErrorMessageDialog.Text != "") { ErrorMessageDialog.Show(); return; }

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            cts = new System.Threading.CancellationTokenSource();
            // Using a safer approach than CheckForIllegalCrossThreadCalls = false
            backgroundWorkerConverter.RunWorkerAsync();
        }

        void updateItemStatusInGrid(VttParagraphToBilingual item)
        {
            foreach (DataGridViewRow row in dgvFilesList.Rows)
            {
                if (row.Cells["stTitle"].Value?.ToString() == item.name)
                {
                    row.Cells["stStatus"].Value = item.status;
                    break;
                }
            }
            updateDGV();
            updateStatus();
        }
        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var pendingFiles = allCombinedFiles.Where(f => f.status == "Pending").ToList();

                System.Threading.Tasks.Parallel.ForEach(pendingFiles, new System.Threading.Tasks.ParallelOptions 
                { 
                    CancellationToken = cts.Token, 
                    MaxDegreeOfParallelism = System.Environment.ProcessorCount 
                }, item => 
                {
                    try
                    {
                        item.status = "Running";
                        this.Invoke(new Action(() => updateItemStatusInGrid(item)));

                        item.export(vTTExportfolderPath);

                        item.status = "Completed";
                        this.Invoke(new Action(() => updateItemStatusInGrid(item)));
                    }
                    catch (Exception ex)
                    {
                        item.status = "Format Error";
                        this.Invoke(new Action(() => {
                            updateItemStatusInGrid(item);
                            System.Windows.Forms.MessageBox.Show($"Issue at : {item.name}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                });
            }
            catch (System.OperationCanceledException)
            {
                // Handle cancellation
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() => {
                    System.Windows.Forms.MessageBox.Show("General Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }

            this.Invoke(new Action(() => {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                cts?.Cancel();
                backgroundWorkerConverter.CancelAsync();
            }
            catch { }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnExportedFolderOpen_Click(object sender, EventArgs e)
        {
            if (txtExportFolderPath.Text.Trim() == "") return;
            System.Diagnostics.Process.Start(txtExportFolderPath.Text);
        }

        private void txtExportFolderPath_TextChanged(object sender, EventArgs e)
        {
            btnExportedFolderOpen.Enabled = !string.IsNullOrEmpty(txtExportFolderPath.Text);
        }

        private void ResetAllbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ResetPage();
        }

        private void SampleBTN_Click(object sender, EventArgs e)
        {
            var PreviewSample = new PreviewSampleFile(Properties.Resources.BilingualnjectSample, Resources.BilingualInjectOutput); PreviewSample.ShowDialog();

        }
    }
}
