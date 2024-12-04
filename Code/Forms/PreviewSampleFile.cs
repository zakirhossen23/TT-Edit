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
        public PreviewSampleFile( string fileText,string fileOutput)
        {
            this.textOfFile = fileText;
            this.outputOfFile = fileOutput;
            InitializeComponent();
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
