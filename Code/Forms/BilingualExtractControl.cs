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
using SubtitlesParser.Parsers;
using SubtitlesParser;
using TT_Edit.Classes;
using TT_Edit.Properties;

namespace TT_Edit.Forms
{
    public partial class BilingualExtractControl : UserControl
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int pendingFiles = 0;
        public static int percentageDone = 0;
        public static int percentagePending = 0;
        public static string vTTfilesPath = "";
        public static string vTTExportfolderPath = "";

        private List<VttBilingualToParagraph> allVTTFiles = new List<VttBilingualToParagraph>();
        private System.Threading.CancellationTokenSource cts;

        public BilingualExtractControl()
        {
            InitializeComponent();
        }


        // Event Handler to Open Folder Browser for VTT files
        private void btnVTTFilesBrowse_Click(object sender, EventArgs e)
        {
            if (vttOFD.ShowDialog() == DialogResult.OK)
            {
                string[] allFiles = (from file in vttOFD.FileNames where Path.GetExtension(file).ToLower() == ".vtt" select file).ToArray();
                // Settings selectted path to textboxes
                txtVTTFilesPath.Text = String.Join(", ", allFiles);
                vTTfilesPath = txtVTTFilesPath.Text;

                if (allFiles.Length == 0)
                {
                    ErrorMessageDialog.Text = "No VTT files to convert";
                    ErrorMessageDialog.Show();
                }


                // Loading files
                loadFiles(allFiles);
            }
        }

        // Event Handler to opening Export Folder Browser for VTT files
        private void btnVTTExportFolderBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog { IsFolderPicker = true };

            if (folderBrowser.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                // Settings selectted path to textboxes
                txtVTTExportFolderPath.Text = folderBrowser.FileName;
                vTTExportfolderPath = txtVTTExportFolderPath.Text;
            }
        }


        /********************** Functions ******************/
        // Function to load vtt files
        void loadFiles(string[] files)
        {
            if (txtVTTFilesPath.Text != "")
            {
                //Clear previous VTT files
                allVTTFiles.Clear();

                // Iterate all the files                 
                foreach (var file in files)
                {
                    // Adding those file into allVTTFiles List as VTTFile class
                    string filename = Path.GetFileName(file);
                    string fileExt = Path.GetExtension(filename).Trim().ToLower();

                    // Load only vtt files
                    if (fileExt == ".vtt")
                    {
                        var newfile = new VttBilingualToParagraph(file, filename);
                        allVTTFiles.Add(newfile);

                    }

                }

            }

            // Refreshing status and Loading Datagridview
            updateStatus();
            loadData();
        }

        // Function to Update All the Status
        void updateStatus()
        {

            // Getting All the Pending and Completed files
            var allPending = from file in allVTTFiles where file.status == "Pending" select file;
            var allCompleted = from file in allVTTFiles where file.status == "Completed" select file;

            // Storing those files count
            totalFiles = allVTTFiles.Count();
            doneFiles = allCompleted.Count();
            pendingFiles = allPending.Count();


            // If totalFiles are greater than zero then it willl calculate progressbar
            if (totalFiles != 0)
            {
                percentageDone = (doneFiles / totalFiles) * 100;
                percentagePending = (pendingFiles / totalFiles) * 100;
            }
            else
            {
                // else will show 0%
                percentageDone = 0;
                percentagePending = 0;
            }

            // Showing those counts into Labels
            lblTotalFiles.Text = totalFiles.ToString();
            lblCompletedFiles.Text = doneFiles.ToString();
            lblPendingFiles.Text = pendingFiles.ToString();

            // Showing those percentage into progressbar
            gcpCompletedFiles.Value = percentageDone;
            gcpPendingFiles.Value = percentagePending;


        }

        // Function to Update Datagridview
        void updateDGV()
        {
            // Iterating all the rows and making style for Pending, Completed and Running Cells
            foreach (DataGridViewRow rowItem in dgvFilesList.Rows)
            {
                string statusText = rowItem.Cells["stStatus"].Value.ToString();

                if (statusText == "Pending") rowItem.Cells["stStatus"].Style.ForeColor = Color.Coral;
                if (statusText == "Completed") rowItem.Cells["stStatus"].Style.ForeColor = Color.Lime;
                if (statusText == "Running") rowItem.Cells["stStatus"].Style.ForeColor = Color.Blue;
                if (statusText == "Format Error") rowItem.Cells["stStatus"].Style.ForeColor = Color.Red;



            }
        }

        // Function to refresh Everything using files list or AllFileList
        void refreshEverything(List<VttBilingualToParagraph> loadToView = null)
        {
            updateStatus();
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            loadData(loadToView);
        }

        // Function to load data into datagridview
        void loadData(List<VttBilingualToParagraph> loadToView = null)
        {
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            dgvFilesList.Rows.Clear();
            foreach (VttBilingualToParagraph item in loadToView)
            {
                // Adding name, lines count, date created, status into datagridview
                dgvFilesList.Rows.Add(new string[] { item.name, item.lines.ToString(), item.date_created.ToString("dd/MM/yyyy"), item.status });

            }
            // Updating Status Cell color
            updateDGV();

        }

        // Handle to remove files in Datagridview
        private void dgvFilesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                // Checking if it is Remove Button Column or not
                DataGridViewCell selectedCell = dgvFilesList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (selectedCell.ColumnIndex == dgvFilesList.Columns["stRemoveBTN"].Index)
                {
                    // Removing that file and refreshing everything
                    allVTTFiles.RemoveAt(e.RowIndex);
                    refreshEverything();
                }
            }
        }

        // Event Handler to search Status in datagridview
        private void cmbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusSearch.Text != "All")
            {
                List<VttBilingualToParagraph> searchedvTTFiles = (from file in allVTTFiles where file.status == cmbStatusSearch.Text select file).ToList();
                refreshEverything(searchedvTTFiles);
            }
            else
            {
                refreshEverything();
            }

        }

        // Event Handler for search box to search in Datagridview
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            List<VttBilingualToParagraph> searchedvTTFiles = (from file in allVTTFiles where file.name.Contains(txtSearchBox.Text) select file).ToList();
            refreshEverything(searchedvTTFiles);
        }

        // Event Handler for Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Validating if all the fields are filled
            ErrorMessageDialog.Text = "";
            if (txtVTTFilesPath.Text == "") ErrorMessageDialog.Text = "Please select VTT folder Files";

            if (txtVTTExportFolderPath.Text == "") ErrorMessageDialog.Text = "Please enter VTT export folder Path";

            if (allVTTFiles.Count == 0) ErrorMessageDialog.Text = "No VTT files to convert";

            if (ErrorMessageDialog.Text != "") { ErrorMessageDialog.Show(); return; }

            // Disabling Start Button and Enabling Stop Button
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            cts = new System.Threading.CancellationTokenSource();
            // Runing the work
            backgroundWorkerConverter.RunWorkerAsync();
        }

        void updateItemStatusInGrid(VttBilingualToParagraph item)
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

        // Event handler of background worker
        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var pendingFiles = allVTTFiles.Where(f => f.status == "Pending").ToList();

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

                        // Export the three output files
                        item.export();

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

        // Event Handler to Stop
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

        // Event Handler to Open Exported Path

        private void btnExportedFolderOpen_Click(object sender, EventArgs e)
        {
            if (txtVTTExportFolderPath.Text.Trim() == "") return;
            System.Diagnostics.Process.Start(txtVTTExportFolderPath.Text);

        }

        private void txtVTTExportFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (txtVTTExportFolderPath.Text != "")
            {
                btnExportedFolderOpen.Enabled = true;
            }
            else
            {

                btnExportedFolderOpen.Enabled = false;
            }

        }

        private void ResetAllbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ResetPage();
        }

        private void SampleBTN_Click(object sender, EventArgs e)
        {

            var PreviewSample = new PreviewSampleFile(Properties.Resources.BilingualExtractSample, Resources.BilingualExtractOutput); PreviewSample.ShowDialog();
        }
    }
}
