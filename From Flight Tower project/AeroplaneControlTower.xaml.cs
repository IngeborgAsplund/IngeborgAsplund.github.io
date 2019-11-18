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
// by Ingeborg Asplund 2018
namespace AeroplaneControlTower
{
    /// <summary>
    /// In this class I handle all the behind the scenes operations needed for the application to work fully.
    /// </summary>
    public partial class ControlTower : Window
    {
        string flightName;// string used for reading the input in the textbox in the graphical user interface
        FlightControlTower control;//publisher 
        Flight fly;// subscriber, has this right now but will soon change
        List<Flight> flights;// list of flights this contains all added flights
        /// <summary>
        /// Constructor that initializes the component and initiates the two objects and their publisher/subsciber relationships
        /// and establishes their respective eventbased relationships
        /// </summary>
        public ControlTower()
        {
            InitializeComponent();
            control = new FlightControlTower();
            SetupGUI();
            flights = new List<Flight>();
            

        }
        /// <summary>
        /// This method sets up the GUI
        /// </summary>
        private void SetupGUI()
        {
            ___lstCurrentFlights_.Items.Clear();
            ___txtFligghtId_.Text = string.Empty;           
        }
       
       
        /// <summary>
        /// The below method handles the event for what happen when we are pressing the send to driveway button in the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendToDriveWay_Click(object sender, RoutedEventArgs e)
        {
            bool inputOk = ReadInput();
            if (inputOk)
            {
                flightName = ___txtFligghtId_.Text;
                FlightWindow myflightwindow = new FlightWindow(flightName);
                // below I start initiante  events associated with the flights. When I have asked I have got to hear that the method that handles the code in the event should
                // not be refered to through objects but for some reason visual studio can't find the methods associated with the events without any type of object oriented
                //directions. I would be greatful if I could get to know why.
                myflightwindow.FlightHasStarted += myflightwindow.flyer.OnFlightHasStarted;
                myflightwindow.FlightHasChangedRoute += myflightwindow.flyer.OnRouteHasChanged;
                myflightwindow.FlightWasLanded += myflightwindow.flyer.OnFlightWasLanded;
                myflightwindow.EffectStarted += myflightwindow.TookOff.OnEffectStarted;
                // below adds the information to the loglist
                ___lstCurrentFlights_.Items.Add(String.Format("{0,10}{1,20}{2,30}", flightName, "Sent to DriveWay", DateTime.Now.ToString()));
                myflightwindow.Show();
            }
            
        }
        /// <summary>
        /// Button functionalisty for selected index changed in the list of flights
        /// </summary>
        private void LstCurrentFlight_SelectedIndexChanged (object sender,RoutedEventArgs e)
        {
            if (___lstCurrentFlights_.SelectedIndex != -1)
                ___txtFligghtId_.Text = ___lstCurrentFlights_.SelectedItem.ToString();
            

        }
        /// <summary>
        /// function that reads and validates the input
        /// </summary>
        private bool ReadInput()
        {
            if (!String.IsNullOrEmpty(___txtFligghtId_.Text))
            {
                flightName = ___txtFligghtId_.Text;
                return true;
            }
            else return false;
        }
       
        /// <summary>
        /// Function that allow the program to see which flight is 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Flight FindAtIndex(int index)
        {
            if (index != -1)
            {
                return flights[index];
            }
            else return null;
        }
        
    }
}
