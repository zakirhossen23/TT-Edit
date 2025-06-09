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

namespace TT_Edit.Forms
{
    public partial class PreviewSampleFile : Form
    {
        string  textOfFile;
        string outputOfFile;
        string extension;
        public PreviewSampleFile( string fileText,string fileOutput,bool LrightToLeft = false, bool RrightToLeft = false)
        {
            this.textOfFile = fileText;
            this.outputOfFile = fileOutput;
            InitializeComponent();
            if (LrightToLeft) previewRichTB.RightToLeft = RightToLeft.Yes;
            else previewRichTB.RightToLeft = RightToLeft.No;
            if (RrightToLeft) outputRichTB.RightToLeft = RightToLeft.Yes;
            else outputRichTB.RightToLeft = RightToLeft.No;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void PreviewSampleFile_Load(object sender, EventArgs e)
        {
            previewRichTB.Text = textOfFile;
            outputRichTB.Text = outputOfFile;

        }
    }
}
