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
    public partial class ReverseConverterControl : UserControl
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int pendingFiles = 0;
        public static int percentageDone = 0;
        public static int percentagePending = 0;
        public static string vTTfilesPath = "";
        public static string vTTExportfolderPath = "";

        private List<VTTFileReverser> allVTTFiles = new List<VTTFileReverser>();



        public ReverseConverterControl()
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
            if (VTTfolderDialog.ShowDialog() == DialogResult.OK)
            {
                // Settings selectted path to textboxes
                txtVTTExportFolderPath.Text = VTTfolderDialog.SelectedPath;
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
                        var newfile = new VTTFileReverser(file, filename);
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
        void refreshEverything(List<VTTFileReverser> loadToView = null)
        {
            updateStatus();
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            loadData(loadToView);
        }

        // Function to load data into datagridview
        void loadData(List<VTTFileReverser> loadToView = null)
        {
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            dgvFilesList.Rows.Clear();
            foreach (VTTFileReverser item in loadToView)
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
                List<VTTFileReverser> searchedvTTFiles = (from file in allVTTFiles where file.status == cmbStatusSearch.Text select file).ToList();
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
            List<VTTFileReverser> searchedvTTFiles = (from file in allVTTFiles where file.name.Contains(txtSearchBox.Text) select file).ToList();
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

        // Funtion for Adding line to Subtitle
        private void addToSubtitle(ref SubtitleItem subtitle, ref List<string> listOfLines, int maxLine)
        {


            StringBuilder currentLineBuilder = new StringBuilder(); // Initialize StringBuilder for building the line

            subtitle.Lines.Clear();
            currentLineBuilder = new StringBuilder();

            string[] wordsLines = listOfLines[0].Split(' '); // Split the line into words
            bool lineAddedLast = false;
            foreach (string word in wordsLines)
            {
            restartSecond:
                if (currentLineBuilder.Length + word.Length < 30)
                {
                    lineAddedLast = false;
                    // If adding the word won't exceed the max line length, add it to the current line
                    currentLineBuilder.Append(word).Append(' '); // Append word and space
                }
                else
                {
                    // If adding the word will exceed the max line length, start a new line
                    subtitle.Lines.Add(currentLineBuilder.ToString().Trim()); // Add current line to subtitle
                    currentLineBuilder.Clear(); // Clear the current line builder
                    lineAddedLast = true;
                    goto restartSecond;
                }
            }
            // If not added last line then readd 
            if (currentLineBuilder.Length > 0 && !lineAddedLast) { subtitle.Lines.Add(currentLineBuilder.ToString().Trim()); lineAddedLast = true; }

            // If line is more than 2 then add to last line
            if (currentLineBuilder.Length > 0 && lineAddedLast && subtitle.Lines.Count > 2)
            {
                for (int k = maxLine; k < subtitle.Lines.Count; k++)
                {

                    subtitle.Lines[1] += " " + subtitle.Lines[k];
                    subtitle.Lines.RemoveAt(k);
                }

            }


            listOfLines.RemoveAt(0);

        }
        // Event handler of background worker
        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            // Iterating through files which status are Pending
            foreach (VTTFileReverser item in from file in allVTTFiles where file.status == "Pending" select file)
            {
                // Setting current status Running and refreshing everything
                item.status = "Running";
                refreshEverything();

                List<string> listOfLines = null;

                int AddToNextTimeFrame = 1;
                for (int i = 0; i < item.AllSubTitleItems.Count-1; i++)
                {
                    SubtitleItem subtitle = item.AllSubTitleItems[i];
               
                    // First joining all lines into a string
                    string draftLines = string.Join(" ", subtitle.Lines.ToArray()).Trim();

                    
                    if (draftLines.Length != 0)
                    {
                        // Counter for next timeframe which are empty
                        AddToNextTimeFrame = 1;
                        for (int j = i + 1; j < item.AllSubTitleItems.Count; j++)
                        {
                            if (item.AllSubTitleItems[j].Lines.Count == 0 && j != item.AllSubTitleItems.Count -1)
                            {
                                AddToNextTimeFrame++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        // Dividing length by next time frame counter as max length
                        int perMaxLine = (int)(draftLines.Length / AddToNextTimeFrame);
                        StringBuilder currentLineBuilder = new StringBuilder(); // Initialize StringBuilder for building the line

                        listOfLines = new List<string>();
                        bool lineAddedLast = false;
                        foreach (string line in subtitle.Lines)
                        {
                            string[] words = line.Split(' '); // Split the line into words

                            foreach (string word in words)
                            {
                                restartFirst:
                                if (currentLineBuilder.Length + word.Length <= perMaxLine)
                                {
                                    lineAddedLast = false;
                                    // If adding the word won't exceed the max line length, add it to the current line
                                    currentLineBuilder.Append(word).Append(' '); // Append word and space
                                }
                                else
                                {
                                 
                                    // If adding the word will exceed the max line length, start a new line
                                    listOfLines.Add(currentLineBuilder.ToString().Trim()); // Add current line to subtitle
                                    currentLineBuilder.Clear(); // Clear the current line builder
                                    lineAddedLast = true;
                                    goto restartFirst;
                                }
                            }

                            // If not added last line then will add it to list
                            if (currentLineBuilder.Length > 0 && !lineAddedLast) {listOfLines.Add(currentLineBuilder.ToString().Trim()); lineAddedLast = true;}

                            // If lines are over counted next timeframe
                            if (currentLineBuilder.Length > 0 && lineAddedLast && AddToNextTimeFrame < listOfLines.Count)
                            {
                                for (int k = AddToNextTimeFrame; k < listOfLines.Count; k++)
                                    listOfLines[AddToNextTimeFrame - 1] += " " + listOfLines[k];
                            }

                        }

                        // Adding Lines to Subtitle
                        addToSubtitle(ref subtitle,ref listOfLines, AddToNextTimeFrame);



                    }
                    else
                    {

                        // Adding Lines to Subtitle
                        if (listOfLines != null)
                        addToSubtitle(ref subtitle, ref listOfLines, 2);
                    }
                }

                // Now exporting that subtitle 
                item.export();

                // Updating current item status to Completed and refreshing everything
                item.status = "Completed";
                refreshEverything();
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
