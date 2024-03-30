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
using FontAwesome.Sharp;

namespace TT_Edit
{
    public partial class MainForm : Form
    {
        /************* Variables **************/
        IconButton prevousButton = null;



        //Constructor
        public MainForm()
        {
            InitializeComponent();
        }




        private void ICBConverter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
           var convcontrol = new TT_Edit.Forms.ConverterControl();
            convcontrol.ErrorMessageDialog.Parent = this;
            convcontrol.Dock = DockStyle.Fill;  
            ControlContainer.Controls.Add(convcontrol);
            ActivateButton((IconButton) sender);
        }

        private void ICBReverseConverter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var revconvcontrol = new TT_Edit.Forms.ReverseConverterControl();
            revconvcontrol.ErrorMessageDialog.Parent = this;
            revconvcontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(revconvcontrol);
            ActivateButton((IconButton)sender);
        }
        /******************** Functions ********************/

        public void makeStylesForActivate(IconButton sender)
        {
            sender.BackColor = Color.FromArgb( 87, 143, 254);
            sender.ForeColor = Color.White;
            sender.IconColor = Color.White;

        }

        public void makeStylesForDeActivate(IconButton sender)
        {
            sender.BackColor = Color.White;
            sender.ForeColor = Color.DimGray;
            sender.IconColor = Color.DimGray;

        }

        public void ActivateButton(IconButton sender)
        {
            if (prevousButton != null) makeStylesForDeActivate(prevousButton);
            makeStylesForActivate(sender);
            prevousButton = sender;

        }


    }

}
