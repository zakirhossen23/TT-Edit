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
using System.Text.RegularExpressions;
using TT_Edit.Properties;
using JiebaNet.Segmenter;
using System.Collections;
using System.Diagnostics;
using MeCab;

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

        private void btnVTTFilesBrowse_Click(object sender, EventArgs e)
        {
            if (this.vttOFD.ShowDialog() != DialogResult.OK)
                return;
            string[] array = ((IEnumerable<string>)this.vttOFD.FileNames).Where<string>((Func<string, bool>)(file => Path.GetExtension(file) == ".vtt")).ToArray<string>();
            this.txtVTTFilesPath.Text = string.Join(", ", array);
            ReverseConverterControl.vTTfilesPath = this.txtVTTFilesPath.Text;
            if (array.Length == 0)
            {
                this.ErrorMessageDialog.Text = "No VTT files to convert";
                int num = (int)this.ErrorMessageDialog.Show();
            }
            this.loadFiles(array);
        }

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

        private void loadFiles(string[] files)
        {
            if (this.txtVTTFilesPath.Text != "")
            {
                this.allVTTFiles.Clear();
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string str = Path.GetExtension(fileName).Trim();
                    if (fileName.Contains(".ja.vtt"))
                        this.allVTTFiles.Add(new VTTFileReverser(file, fileName, "ja"));
                    else if (fileName.Contains(".cn.vtt"))
                        this.allVTTFiles.Add(new VTTFileReverser(file, fileName, "cn"));
                    else if (str == ".vtt")
                        this.allVTTFiles.Add(new VTTFileReverser(file, fileName));
                }
            }
            this.updateStatus();
            this.loadData();
        }

        private void updateStatus()
        {
            IEnumerable<VTTFileReverser> source1 = this.allVTTFiles.Where<VTTFileReverser>((Func<VTTFileReverser, bool>)(file => file.status == "Pending"));
            IEnumerable<VTTFileReverser> source2 = this.allVTTFiles.Where<VTTFileReverser>((Func<VTTFileReverser, bool>)(file => file.status == "Completed"));
            ReverseConverterControl.totalFiles = this.allVTTFiles.Count<VTTFileReverser>();
            ReverseConverterControl.doneFiles = source2.Count<VTTFileReverser>();
            ReverseConverterControl.pendingFiles = source1.Count<VTTFileReverser>();
            if (ReverseConverterControl.totalFiles != 0)
            {
                ReverseConverterControl.percentageDone = ReverseConverterControl.doneFiles / ReverseConverterControl.totalFiles * 100;
                ReverseConverterControl.percentagePending = ReverseConverterControl.pendingFiles / ReverseConverterControl.totalFiles * 100;
            }
            else
            {
                ReverseConverterControl.percentageDone = 0;
                ReverseConverterControl.percentagePending = 0;
            }
            this.lblTotalFiles.Text = ReverseConverterControl.totalFiles.ToString();
            this.lblCompletedFiles.Text = ReverseConverterControl.doneFiles.ToString();
            this.lblPendingFiles.Text = ReverseConverterControl.pendingFiles.ToString();
            this.gcpCompletedFiles.Value = ReverseConverterControl.percentageDone;
            this.gcpPendingFiles.Value = ReverseConverterControl.percentagePending;
        }

        private void updateDGV()
        {
            foreach (DataGridViewRow row in (IEnumerable)this.dgvFilesList.Rows)
            {
                string str = row.Cells["stStatus"].Value.ToString();
                if (str == "Pending")
                    row.Cells["stStatus"].Style.ForeColor = Color.Coral;
                if (str == "Completed")
                    row.Cells["stStatus"].Style.ForeColor = Color.Lime;
                if (str == "Running")
                    row.Cells["stStatus"].Style.ForeColor = Color.Blue;
            }
        }

        private void refreshEverything(List<VTTFileReverser> loadToView = null)
        {
            this.updateStatus();
            loadToView = loadToView == null ? this.allVTTFiles : loadToView;
            this.loadData(loadToView);
        }

        private void loadData(List<VTTFileReverser> loadToView = null)
        {
            loadToView = loadToView == null ? this.allVTTFiles : loadToView;
            this.dgvFilesList.Rows.Clear();
            foreach (VTTFileReverser vttFileReverser in loadToView)
                this.dgvFilesList.Rows.Add((object[])new string[4]
                {
          vttFileReverser.name,
          vttFileReverser.lines.ToString(),
          vttFileReverser.date_created.ToString("dd/MM/yyyy"),
          vttFileReverser.status
                });
            this.updateDGV();
        }

        private void dgvFilesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || this.dgvFilesList.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex != this.dgvFilesList.Columns["stRemoveBTN"].Index)
                return;
            this.allVTTFiles.RemoveAt(e.RowIndex);
            this.refreshEverything();
        }

        private void cmbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStatusSearch.Text != "All")
                this.refreshEverything(this.allVTTFiles.Where<VTTFileReverser>((Func<VTTFileReverser, bool>)(file => file.status == this.cmbStatusSearch.Text)).ToList<VTTFileReverser>());
            else
                this.refreshEverything();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            this.refreshEverything(this.allVTTFiles.Where<VTTFileReverser>((Func<VTTFileReverser, bool>)(file => file.name.Contains(this.txtSearchBox.Text))).ToList<VTTFileReverser>());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.ErrorMessageDialog.Text = "";
            if (this.txtVTTFilesPath.Text == "")
                this.ErrorMessageDialog.Text = "Please select VTT folder Files";
            if (this.txtVTTExportFolderPath.Text == "")
                this.ErrorMessageDialog.Text = "Please enter VTT export folder Path";
            if (this.allVTTFiles.Count == 0)
                this.ErrorMessageDialog.Text = "No VTT files to convert";
            if (this.ErrorMessageDialog.Text != "")
            {
                int num = (int)this.ErrorMessageDialog.Show();
            }
            else
            {
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                Control.CheckForIllegalCrossThreadCalls = false;
                this.backgroundWorkerConverter.RunWorkerAsync();
            }
        }

        private void addToSubtitle(
          ref SubtitleItem subtitle,
          ref List<string> listOfLines,
          int maxLine)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            subtitle.Lines.Clear();
            StringBuilder stringBuilder2 = new StringBuilder();
            string[] strArray = listOfLines[0].Split(' ');
            bool flag = false;
            foreach (string str in strArray)
            {
                while (stringBuilder2.Length + str.Length >= 30)
                {
                    subtitle.Lines.Add(stringBuilder2.ToString().Trim());
                    stringBuilder2.Clear();
                }
                flag = false;
                stringBuilder2.Append(str).Append(' ');
            }
            if (stringBuilder2.Length > 0 && !flag)
            {
                subtitle.Lines.Add(stringBuilder2.ToString().Trim());
                flag = true;
            }
            if (stringBuilder2.Length > 0 & flag && subtitle.Lines.Count > 2)
            {
                for (int index = maxLine; index < subtitle.Lines.Count; ++index)
                {
                    List<string> lines = subtitle.Lines;
                    lines[1] = lines[1] + " " + subtitle.Lines[index];
                    subtitle.Lines.RemoveAt(index);
                }
            }
            listOfLines.RemoveAt(0);
        }

        private void backgroundWorkerConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (VTTFileReverser vttFileReverser in this.allVTTFiles.Where<VTTFileReverser>((Func<VTTFileReverser, bool>)(file => file.status == "Pending")))
            {
                vttFileReverser.status = "Running";
                this.refreshEverything();
                List<string> listOfLines = (List<string>)null;
                for (int index1 = 0; index1 < vttFileReverser.AllSubTitleItems.Count - 1; ++index1)
                {
                    SubtitleItem allSubTitleItem = vttFileReverser.AllSubTitleItems[index1];
                    string str1 = string.Join(" ", allSubTitleItem.Lines.ToArray()).Trim();
                    if (str1.Length != 0)
                    {
                        int maxLine = 1;
                        for (int index2 = index1 + 1; index2 < vttFileReverser.AllSubTitleItems.Count && vttFileReverser.AllSubTitleItems[index2].Lines.Count == 0 && index2 != vttFileReverser.AllSubTitleItems.Count - 1; ++index2)
                            ++maxLine;
                        int num = str1.Length / maxLine;
                        StringBuilder stringBuilder = new StringBuilder();
                        listOfLines = new List<string>();
                        bool flag = false;
                        foreach (string line in allSubTitleItem.Lines)
                        {
                            string[] strArray1 = new string[0];
                            string[] strArray2;
                            if (vttFileReverser.lang == "ja")
                                strArray2 = MeCabTagger.Create().ParseToNodes(str1).Where<MeCabNode>((Func<MeCabNode, bool>)(node => node.Stat != MeCabNodeStat.Bos && node.Stat != MeCabNodeStat.Eos)).Select<MeCabNode, string>((Func<MeCabNode, string>)(node => node.Surface)).ToArray<string>();
                            else if (vttFileReverser.lang == "cn")
                                strArray2 = new JiebaSegmenter().Cut(str1).ToArray<string>();
                            else
                                strArray2 = str1.Split(' ');
                            foreach (string str2 in strArray2)
                            {
                                while (stringBuilder.Length + str2.Length > num)
                                {
                                    listOfLines.Add(stringBuilder.ToString().Trim());
                                    stringBuilder.Clear();
                                }
                                flag = false;
                                if (vttFileReverser.lang != "ja")
                                   stringBuilder.Append(str2).Append(' ');
                                else stringBuilder.Append(str2);
                            }
                            if (stringBuilder.Length > 0 && !flag)
                            {
                                listOfLines.Add(stringBuilder.ToString().Trim());
                                flag = true;
                            }
                            if (stringBuilder.Length > 0 & flag && maxLine < listOfLines.Count)
                            {
                                for (int index3 = maxLine; index3 < listOfLines.Count; ++index3)
                                {
                                    List<string> stringList = listOfLines;
                                    int index4 = maxLine - 1;
                                    stringList[index4] = stringList[index4] + " " + listOfLines[index3];
                                }
                            }
                        }
                        this.addToSubtitle(ref allSubTitleItem, ref listOfLines, maxLine);
                    }
                    else if (listOfLines != null)
                        this.addToSubtitle(ref allSubTitleItem, ref listOfLines, 2);
                }
                vttFileReverser.export();
                vttFileReverser.status = "Completed";
                this.refreshEverything();
            }
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorkerConverter.CancelAsync();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }

        private void btnExportedFolderOpen_Click(object sender, EventArgs e)
        {
            if (this.txtVTTExportFolderPath.Text.Trim() == "")
                return;
            Process.Start(this.txtVTTExportFolderPath.Text);
        }

        private void txtVTTExportFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (this.txtVTTExportFolderPath.Text != "")
                this.btnExportedFolderOpen.Enabled = true;
            else
                this.btnExportedFolderOpen.Enabled = false;
        }

        private void ResetAllbtn_Click(object sender, EventArgs e)
        {
            ((MainForm)this.ParentForm).ResetPage();
        }

        private void SampleBTN_Click(object sender, EventArgs e)
        {

            var PreviewSample = new PreviewSampleFile(Properties.Resources.ReverseConverterSample, Resources.ReverseConverterOutput); PreviewSample.ShowDialog();
        }
    }
}
