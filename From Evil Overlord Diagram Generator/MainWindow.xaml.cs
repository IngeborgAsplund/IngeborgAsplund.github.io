using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DrawingAndDiagramUtility;

namespace EvilOverlordsDiagramGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParseInput input;
        DrawDiagram diagram;
        
        public MainWindow()
        {
            InitializeComponent();
            input = new ParseInput();
            diagram = new DrawDiagram();
            UnFreezeSettings();
            
        }       
        /// <summary>
        /// Reads the values entered by the users in the settings window, call a method that draws the right amount of divisions
        /// and add the text where it should be.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateDiagram_Click(object sender, RoutedEventArgs e)
        {
            int divX = input.ParseStringToInt(txtdivisionX.Text);
            int divY = input.ParseStringToInt(txtdivisionY.Text);
            int scaleX = input.ParseStringToInt(txtintervalX.Text);
            int scaleY = input.ParseStringToInt(txtIntervalY.Text);
            string diagramtitle = txtTitle.Text.Trim();
            bool inputsWork = input.SettingsNotNegative(divX, divY, scaleX, scaleY);
            if (inputsWork&&!string.IsNullOrEmpty(diagramtitle))
            {

                //call functions from Drawdiagram and WriteText to build the diagram so that it works
                diagram.CreateNewDidagram(diagramtitle, divX, divY, scaleX, scaleY, can_diagram);
                ClearSettings();
                FreezeSettings();
                
            }
            else
            {
                MessageBox.Show("Invalid Input settings must be given in whole numbers who are not allowed to be negative, title are also not allowed to be empty", "Error");
            }
        }
        /// <summary>
        /// Reset the values entered in the settings window in case the user are not sasisfied with wath is entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSettings_Click(object sender, RoutedEventArgs e)
        {
            ClearSettings();
        }
        /// <summary>
        /// Buttonfunction for adding a point to the diagram, reads a point and calls class+method that redraws the current diagram considering it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            double xloc = input.ParseStringToDouble(txtXcoord.Text);
            double yloc = input.ParseStringToDouble(txtYcoord.Text);
            diagram.AddNewPoints(xloc,yloc,can_diagram,lstPoints);
            txtXcoord.Text = string.Empty;
            txtYcoord.Text = string.Empty;
        }
        /// <summary>
        /// Handles event for when the application is shut down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Handles event for when the user want to change how data is displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortDataInXdir_Click(object sender, RoutedEventArgs e)
        {
            diagram.SortInXDir(can_diagram, lstPoints);
        }
        /// <summary>
        /// Handles the event of when a user want to change the data sorting to run along the y axis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortDataInYDir_Click(object sender, RoutedEventArgs e)
        {
            diagram.SortInYDir(can_diagram, lstPoints);
        }
        /// <summary>
        /// Function that clears the diagram and reenable the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearDiagram_Click(object sender, RoutedEventArgs e)
        {
            UnFreezeSettings();
        }
        /// <summary>
        /// Clears the Ui for settings 
        /// </summary>
        private void ClearSettings()
        {
            txtdivisionX.Text = string.Empty;
            txtdivisionY.Text = string.Empty;
            txtintervalX.Text = string.Empty;
            txtIntervalY.Text = string.Empty;
            txtTitle.Text = string.Empty;           

        }
        /// <summary>
        /// Disables the settings controls when a new diagram is createed.
        /// </summary>
        private void FreezeSettings()
        {
            btn_DiagramOk.IsEnabled = false;
            btnCancelDiagram.IsEnabled = false;
            txtTitle.IsEnabled = false;
            txtIntervalY.IsEnabled = false;
            txtintervalX.IsEnabled = false;
            txtdivisionY.IsEnabled = false;
            txtXcoord.IsEnabled = true;
            txtYcoord.IsEnabled = true;
            btnAddPoint.IsEnabled = true;
        }
        /// <summary>
        /// Enable settings and freeze the diagram editing ui.
        /// </summary>
        private void UnFreezeSettings()
        {
            btn_DiagramOk.IsEnabled = true;
            btnCancelDiagram.IsEnabled = true;
            txtTitle.IsEnabled = true;
            txtIntervalY.IsEnabled = true;
            txtintervalX.IsEnabled = true;
            txtdivisionY.IsEnabled = true;
            txtXcoord.IsEnabled = false;
            txtYcoord.IsEnabled = false;
            btnAddPoint.IsEnabled = false;
        }
        /// <summary>
        /// clear point input after each time the user inputs point
        /// </summary>
        private void ClearInputWindows()
        {
            txtXcoord.Text = string.Empty;
            txtYcoord.Text = string.Empty;
        }

        
    }
}
