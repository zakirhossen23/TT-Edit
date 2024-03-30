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
namespace TT_Edit
{
    public partial class MainForm : Form
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int pendingFiles = 0;
        public static int percentageDone = 0;
        public static int percentagePending = 0;
        public static string vTTfolderPath = "";
        public static string vTTExportfolderPath = "";

        private List<VTTFile> allVTTFiles = new List<VTTFile>();



        public MainForm()
        {
            InitializeComponent();
        }

        private void btnVTTFolderBrowse_Click(object sender, EventArgs e)
        {
            if (VTTfolderDialog.ShowDialog() == DialogResult.OK)
            {
                txtVTTFolderPath.Text = VTTfolderDialog.SelectedPath;
                vTTfolderPath = txtVTTFolderPath.Text;
                loadFiles();
            }
        }

        private void btnVTTExportFolderBrowse_Click(object sender, EventArgs e)
        {
            if (VTTfolderDialog.ShowDialog() == DialogResult.OK)
            {
                txtVTTExportFolderPath.Text = VTTfolderDialog.SelectedPath;
                vTTExportfolderPath = txtVTTExportFolderPath.Text;
            }
        }

        private void txtVTTFolderPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["vttFolder"] = txtVTTFolderPath.Text;
            Properties.Settings.Default.Save();

        }

        private void txtVTTExportFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (txtVTTExportFolderPath.Text.Trim() != "") { btnExportedFolderOpen.Enabled = true; } else { btnExportedFolderOpen.Enabled = false; }

            Properties.Settings.Default["vttExportFolder"] = txtVTTFolderPath.Text;
            Properties.Settings.Default.Save();

        }
        // Event handler for Start button click
        private void btnConvertAndExport_Click(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;

        }


        /********************** Functions ******************/
        void loadFiles()
        {
            if (txtVTTFolderPath.Text != "")
            {
                var files = from file in Directory.EnumerateFiles(txtVTTFolderPath.Text) select file;
                foreach (var file in files)
                {
                    string filename = Path.GetFileName(file);
                    var newfile = new VTTFile(file, filename);
                    allVTTFiles.Add(newfile);

                }
            }
            updateStatus();
            loadData();
        }
        void updateStatus()
        {
            var allPending = from file in allVTTFiles where file.status == "Pending" select file;
            var allCompleted = from file in allVTTFiles where file.status == "Completed" select file;

            totalFiles = allVTTFiles.Count();
            doneFiles = allCompleted.Count();
            pendingFiles = allPending.Count();


            if (totalFiles != 0)
            {
                percentageDone = (doneFiles / totalFiles) * 100;
                percentagePending = (pendingFiles / totalFiles) * 100;
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
                string statusText = rowItem.Cells["stStatus"].Value.ToString();

                if (statusText == "Pending") rowItem.Cells["stStatus"].Style.ForeColor = Color.Coral;
                if (statusText == "Completed") rowItem.Cells["stStatus"].Style.ForeColor = Color.Lime;
                if (statusText == "Running") rowItem.Cells["stStatus"].Style.ForeColor = Color.Blue;



            }
        }

        void refreshEverything(List<VTTFile> loadToView = null)
        {
            updateStatus();
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            loadData(loadToView);
        }
        void loadData(List<VTTFile> loadToView = null)
        {
            loadToView = loadToView == null ? allVTTFiles : loadToView;
            dgvFilesList.Rows.Clear();
            foreach (VTTFile item in loadToView)
            {

                dgvFilesList.Rows.Add(new string[] { item.name, item.lines.ToString(), item.date_created.ToString("dd/MM/yyyy"), item.status });

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
                    allVTTFiles.RemoveAt(e.RowIndex);
                    refreshEverything();
                }
            }
        }

        private void cmbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusSearch.Text != "All")
            {
                List<VTTFile> searchedvTTFiles = (from file in allVTTFiles where file.status == cmbStatusSearch.Text select file).ToList();
                refreshEverything(searchedvTTFiles);
            }
            else
            {
                refreshEverything();
            }

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            List<VTTFile> searchedvTTFiles = (from file in allVTTFiles where file.name.Contains(txtSearchBox.Text) select file).ToList();
            refreshEverything(searchedvTTFiles);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ErrorMessageDialog.Text = "";
            if (txtVTTFolderPath.Text == "") ErrorMessageDialog.Text = "Please enter VTT folder Path";             
            
            if (txtVTTExportFolderPath.Text == "") ErrorMessageDialog.Text = "Please enter VTT export folder Path";

            if (allVTTFiles.Count == 0) ErrorMessageDialog.Text = "No files to convert";

            if (ErrorMessageDialog.Text != "") { ErrorMessageDialog.Show(); return; }

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            CheckForIllegalCrossThreadCalls = false;
            backgroundWorkerConverter.RunWorkerAsync();

        }

        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (VTTFile item in from file in allVTTFiles where file.status=="Pending" select file)
            {
                item.status = "Running";
                refreshEverything();

                SubtitleItem firstSubTitle = null;
                bool isNewSub = true;
                foreach (SubtitleItem subtitle in item.AllSubTitleItems)
                {
                    string draftLines = string.Join(" ", subtitle.Lines.ToArray());
                    if (isNewSub)
                    {
                        firstSubTitle = subtitle;
                    }
                    else
                    {
                        firstSubTitle.Lines.AddRange(subtitle.Lines);
                       
                        subtitle.Lines.Clear();

                    }
                    if (! draftLines.Contains("."))
                    {
                        isNewSub = false;
                    }
                    else
                    {
                        isNewSub = true;
                    }
                }
                item.export();
                item.status = "Completed";
                refreshEverything();
            }
            btnStart.Enabled = true;
            btnStop.Enabled = false;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerConverter.CancelAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;

            }

        }

        private void btnExportedFolderOpen_Click(object sender, EventArgs e)
        {
            if (txtVTTExportFolderPath.Text.Trim() == "") return;
            System.Diagnostics.Process.Start(txtVTTExportFolderPath.Text);

        }

    }

    internal class VTTFile
    {
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> AllSubTitleItems;
        public VTTFile(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }
        public string export_path()
        {
            return MainForm.vTTExportfolderPath + "\\" + name;
        }
        public void export()
        {
            WriteToVttFile(AllSubTitleItems,export_path(),Encoding.UTF8);   

        }

      

        public void WriteToVttFile(List<SubtitleItem> subtitleItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                writer.WriteLine("WEBVTT\n");
                foreach (SubtitleItem item in subtitleItems)
                {

                    writer.WriteLine($"{FormatTimecode(item.StartTime)} --> {FormatTimecode(item.EndTime)}");
                    string draftLines = string.Join(" ", item.Lines.ToArray()).Trim();
                    writer.WriteLine(draftLines);
                    writer.WriteLine(); // Add an empty line between subtitle items
                }
            }
        }
        private string FormatTimecode(int milliseconds)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(milliseconds);
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000}";
        }

        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            var newParser = new Classess.VttParser();
            using (var fileStream = File.OpenRead(path))
            {
                var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8);
                AllSubTitleItems = newParsed.ToList();
            }
            lines = AllSubTitleItems.Count;



        }

    }
}
