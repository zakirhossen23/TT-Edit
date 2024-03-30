using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TT_Edit
{
    public partial class MainForm : Form
    {
        /* ************** Variables ****************/
        public static int totalFiles = 0;
        public static int doneFiles = 0;
        public static int percentageDone = 0;




        public MainForm()
        {
            InitializeComponent();
        }

        private void btnVTTFolderBrowse_Click(object sender, EventArgs e)
        {
            if (VTTfolderDialog.ShowDialog() == DialogResult.OK)
            {
                txtVTTFolderPath.Text = VTTfolderDialog.SelectedPath;
               

            }
        }

        private void btnVTTExportFolderBrowse_Click(object sender, EventArgs e)
        {
            if (VTTfolderDialog.ShowDialog() == DialogResult.OK)
            {
                txtVTTExportFolderPath.Text = VTTfolderDialog.SelectedPath;
        
            }
        }

        private void txtVTTFolderPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["vttFolder"] = txtVTTFolderPath.Text;
            Properties.Settings.Default.Save();

        }

        private void txtVTTExportFolderPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["vttExportFolder"] = txtVTTFolderPath.Text;
            Properties.Settings.Default.Save();

        }
        // Event handler for Start button click
        private void btnConvertAndExport_Click(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;

        }


        /********************** Functions ******************/
        void updateStatus()
        {
            if (totalFiles == 0) return;

            percentageDone = (doneFiles / totalFiles) * 100;
            //statusProgress.Value = percentageDone;
            //lblDoneStatus.Text = $"{doneFiles}/{totalFiles}";
            //tslStatus.Text = $"Progress: {percentageDone}%";
        }


    }
}
