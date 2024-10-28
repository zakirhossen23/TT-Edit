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
        dynamic selectedControl = null;


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

        private void ICBTimeframe_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.TimeframeControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);

        }

        private void ICBSpaceRemover_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.SpaceEraserControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);

        }

        private void ICBCPLcounter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.CplCounterControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }

        private void ICBCommaChecker_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.CommaCheckerControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }

        private void ICBTimeframeDivider_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.TimeframeDividerControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }

        private void ICBAtInserter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.AtInserterControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }

        private void ICBAtRemover_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.AtRemoverControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);

        }

        private void ICBHelp_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.HelpControl();
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }
        public void ResetPage()
        {
            ControlContainer.Controls.Clear();

            selectedControl.Dispose();
            selectedControl = Activator.CreateInstance(selectedControl.GetType());
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);

        }
        private void ICBPageTextFormatter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.PageTextFormatControl();
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);
        }
  
        private void ICBPageTextDeFormatter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            selectedControl = new TT_Edit.Forms.PageTextDeFormatControl();

            selectedControl.Parent = this;
            selectedControl.ErrorMessageDialog.Parent = this;
            selectedControl.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(selectedControl);
            ActivateButton((IconButton)sender);

        }

    }

}
