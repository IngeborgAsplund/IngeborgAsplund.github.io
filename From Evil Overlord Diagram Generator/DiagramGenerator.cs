using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingAndDiagramUtility;
//By Ingeborg Asplund 2018
namespace EvilOverlordDiagram_Generator
{
    public partial class DiagramGenerator : Form
    {
        private DrawDiagram draws;
        private ParseInput controller;
        private Graphics g;      
        //variables to save when drawing out graphics again
        private string diagramtitle;
        private int noDivX;
        private int noDivY;
        private int intervalX;
        private int intervalY;
        public DiagramGenerator()
        {
            InitializeComponent();
            g = pan_Diagram.CreateGraphics();//now the graphics object are tied to the panel
            draws = new DrawDiagram(g);
            controller = new ParseInput();
            ClearUI();
            EnableSettings();
        }
        /// <summary>
        /// Enable the controls in the settings and disable ability to send in information about points
        /// </summary>
        private void EnableSettings()
        {
            txtDiagramTitle.Enabled = true;
            txtIntervalX.Enabled = true;
            txtIntervalY.Enabled = true;
            txtNodivX.Enabled = true;
            txtNodivY.Enabled = true;
            btnOk.Enabled = true;
            btnReset.Enabled = true;
            txtPointXCoord.Enabled = false;
            txtPointYcoord.Enabled = false;
            btnCreatePoint.Enabled = false;

        }
        /// <summary>
        /// disables the controls for the settings once a diagram has been created
        /// </summary>
        private void DisableSettings()
        {
            txtDiagramTitle.Enabled = false;
            txtIntervalX.Enabled = false;
            txtIntervalY.Enabled = false;
            txtNodivX.Enabled = false;
            txtNodivY.Enabled = false;
            btnOk.Enabled = false;
            btnReset.Enabled = false;
            txtPointXCoord.Enabled = true;
            txtPointYcoord.Enabled = true;
            btnCreatePoint.Enabled = true;
        }
        /// <summary>
        /// Clears the textboxes and other input tools 
        /// </summary>
        private void ClearUI()
        {
            txtDiagramTitle.Text = string.Empty;
            txtIntervalX.Text = string.Empty;
            txtIntervalY.Text = string.Empty;
            txtNodivX.Text= string.Empty;
            txtNodivY.Text = string.Empty;
            txtPointXCoord.Text = string.Empty;
            txtPointYcoord.Text = string.Empty;
        }
        /// <summary>
        /// Reads the input from the textboxes and checking the users input through the 
        /// </summary>
        private void ReadInput()
        {
            if (!string.IsNullOrEmpty(txtDiagramTitle.Text) && !string.IsNullOrEmpty(txtIntervalX.Text) && !string.IsNullOrEmpty(txtIntervalY.Text) && !string.IsNullOrEmpty(txtNodivX.Text) && !string.IsNullOrEmpty(txtNodivY.Text))
            {
                diagramtitle = txtDiagramTitle.Text;
                noDivX = controller.ParseStringToInt(txtNodivX.Text);
                noDivY = controller.ParseStringToInt(txtNodivY.Text);
                intervalX = controller.ParseStringToInt(txtIntervalX.Text);
                intervalY = controller.ParseStringToInt(txtIntervalY.Text);
                bool divisionsOk = controller.DivisonsInRange(noDivX, noDivY);
                bool intervalOk = controller.IntervalInRange(intervalX, intervalY);
                draws.MaxX = noDivX * intervalX;
                draws.MaxY = noDivY * intervalY;
                if (intervalOk && divisionsOk)
                {
                    draws.CreateNewDidagram(diagramtitle, noDivX, noDivY, intervalX, intervalY, pan_Diagram);               
                }
            }
        }
        /// <summary>
        /// create a new diagram using the referenced classes from utilities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ReadInput();
            ClearUI();
            DisableSettings();
        }
        /// <summary>
        /// This function resets the state of the settings if the user chooses to do so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDiagramTitle.Text = string.Empty;
            txtIntervalX.Text = string.Empty;
            txtIntervalY.Text = string.Empty;
            txtNodivX.Text = string.Empty;
            txtNodivY.Text = string.Empty;
        }
        /// <summary>
        /// create a point in the diagram using the appropriate functions in the utility classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePoint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPointXCoord.Text) && !string.IsNullOrEmpty(txtPointYcoord.Text))
            {
                int xValue = controller.ParseStringToInt(txtPointXCoord.Text);
                int yValue = controller.ParseStringToInt(txtPointYcoord.Text);
                bool withinBoundaries = controller.PointWithinDiagram(xValue, yValue,draws.MaxX,draws.MaxY, pan_Diagram);
                if (withinBoundaries)
                {
                    // add new points and update the list dependent on the sorting direction
                    draws.AddNewPoints(xValue,yValue,lstPoints,pan_Diagram,noDivX,noDivY,intervalX,intervalY,diagramtitle);
                    txtPointXCoord.Text = string.Empty;
                    txtPointYcoord.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// function for clearing the drawn diagram and reset the settings variables native to this script since they s
        /// should not be saved over to next drawing this function also unlocks the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {           
            diagramtitle = string.Empty;
            noDivX = 0;
            noDivY = 0;
            intervalX = 0;
            intervalY = 0;
            draws.ClearDiagram(lstPoints);
            EnableSettings();
        }
        /// <summary>
        /// Function for sorting the points in Xdirection(default sorting)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSortX_Click(object sender, EventArgs e)
        {
            draws.DirectionX = true;
            draws.SortInXDir(lstPoints, pan_Diagram, noDivX, noDivY, intervalX, intervalY, diagramtitle);
        }
        /// <summary>
        /// sorts the points after the y axis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSortAfterY_Click(object sender, EventArgs e)
        {
            draws.DirectionX = false;
            draws.SortInYDir(lstPoints, pan_Diagram, noDivX, noDivY, intervalX, intervalY, diagramtitle);
        }
        /// <summary>
        /// Exits the application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// This function opens an about box telling the user about how to use the applications functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHowToUse_Click(object sender, EventArgs e)
        {
            DialogResult result;
            UserManual howToUse = new UserManual();
            result = howToUse.ShowDialog();
        }

      
    }
}
