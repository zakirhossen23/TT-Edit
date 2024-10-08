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

namespace TT_Edit.Forms
{
    public partial class AtRemoverControl : UserControl
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int pendingFiles = 0;
        public static int percentageDone = 0;
        public static int percentagePending = 0;
        public static string vTTfilesPath = "";
        public static string vTTExportfolderPath = "";

        private List<VttFIleAtRemover> allVTTFiles = new List<VttFIleAtRemover>();



        public AtRemoverControl()
        {
            InitializeComponent();
        }


        // Event Handler to Open Folder Browser for VTT files
        private void btnVTTFilesBrowse_Click(object sender, EventArgs e)
        {
            if (vttOFD.ShowDialog() == DialogResult.OK)
            {
                string[] allFiles = (from file in vttOFD.FileNames where Path.GetExtension(file) == ".vtt" select file).ToArray();
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
                    string fileExt = Path.GetExtension(filename).Trim();

                    // Load only vtt files
                    if (fileExt == ".vtt")
                    {
                        var newfile = new VttFIleAtRemover(file, filename);
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



            }
        }

        // Function to refresh Everything using files list or AllFileList
        void refreshEverything(List<VttFIleAtRemover> loadToView = null)
        {
            updateStatus();
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            loadData(loadToView);
        }

        // Function to load data into datagridview
        void loadData(List<VttFIleAtRemover> loadToView = null)
        {
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            dgvFilesList.Rows.Clear();
            foreach (VttFIleAtRemover item in loadToView)
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
                List<VttFIleAtRemover> searchedvTTFiles = (from file in allVTTFiles where file.status == cmbStatusSearch.Text select file).ToList();
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
            List<VttFIleAtRemover> searchedvTTFiles = (from file in allVTTFiles where file.name.Contains(txtSearchBox.Text) select file).ToList();
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

            // Disabling Satart Button and Enabling Stop Button
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            // Runing the work
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorkerConverter.RunWorkerAsync();

        }


        int lastIndex = 0;
        VttFIleAtRemover lastitem;
        // Event handler of background worker
        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Iterating through files which status are Pending
                foreach (VttFIleAtRemover item in from file in allVTTFiles where file.status == "Pending" select file)
                {
                    // Setting current status Running and refreshing everything
                    item.status = "Running";
                    refreshEverything();

                    for (int i = 0; i < item.AllSubTitleItems.Count; i++)
                    {
                        lastIndex = i;
                        lastitem = item;
                        SubtitleItem subtitle = item.AllSubTitleItems[i];
                        if (subtitle.Lines.Count == 1 && subtitle.Lines[0].Trim() == "@")
                        {
                            subtitle.Lines[0] = "";
                        }

                        item.AllSubTitleItems[i] = subtitle;


                    }

                    // Now exporting that subtitle 
                    item.export();

                    // Updating current item status to Completed and refreshing everything
                    item.status = "Completed";
                    refreshEverything();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Issue at timeframe : " + VttFIleAtRemover.GetFormattedStartEnd(lastitem.AllSubTitleItems[lastIndex]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // When everything is finished then will disable Stop button and enable Start Buttton.
            btnStart.Enabled = true;
            btnStop.Enabled = false;

        }

        // Event Handler to Stop
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Force Cancel BackgrounWorker and skip if found any error
            try
            {
                backgroundWorkerConverter.CancelAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {

                // Then Enable Start button and Disable Stop Button
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



    }
}
