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
            var timeframecontrol = new TT_Edit.Forms.TimeframeControl();
            timeframecontrol.ErrorMessageDialog.Parent = this;
            timeframecontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(timeframecontrol);
            ActivateButton((IconButton)sender);

        }

        private void ICBSpaceRemover_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var erasercontrol = new TT_Edit.Forms.SpaceEraserControl();
            erasercontrol.ErrorMessageDialog.Parent = this;
            erasercontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(erasercontrol);
            ActivateButton((IconButton)sender);

        }

        private void ICBCPLcounter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var cplcountercontrol = new TT_Edit.Forms.CplCounterControl();
            cplcountercontrol.ErrorMessageDialog.Parent = this;
            cplcountercontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(cplcountercontrol);
            ActivateButton((IconButton)sender);
        }

        private void ICBCommaChecker_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var commacheckercontrol = new TT_Edit.Forms.CommaCheckerControl();
            commacheckercontrol.ErrorMessageDialog.Parent = this;
            commacheckercontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(commacheckercontrol);
            ActivateButton((IconButton)sender);
        }

        private void ICBTimeframeDivider_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var timeframecontrol = new TT_Edit.Forms.TimeframeDividerControl();
            timeframecontrol.ErrorMessageDialog.Parent = this;
            timeframecontrol.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(timeframecontrol);
            ActivateButton((IconButton)sender);
        }

        private void ICBAtInserter_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var control = new TT_Edit.Forms.AtInserterControl();
            control.ErrorMessageDialog.Parent = this;
            control.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(control);
            ActivateButton((IconButton)sender);
        }

        private void ICBAtRemover_Click(object sender, EventArgs e)
        {
            ControlContainer.Controls.Clear();
            var control = new TT_Edit.Forms.AtRemoverControl();
            control.ErrorMessageDialog.Parent = this;
            control.Dock = DockStyle.Fill;
            ControlContainer.Controls.Add(control);
            ActivateButton((IconButton)sender);

        }
    }

}
