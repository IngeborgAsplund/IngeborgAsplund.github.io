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
using System.Windows.Shapes;
// By Ingeborg Asplund
namespace AeroplaneControlTower
{
    /// <summary>
    /// Behind the scenes logic for the flight window
    /// </summary>
    public partial class FlightWindow : Window
    {
        private Flight flight;
        private PlaneTookOffEffect pt;
        public FlightWindow(string id)
        {
            InitializeComponent();
            flight = new Flight(id);// create a new flight based on id
            pt = new PlaneTookOffEffect();           
            SetUpGui();
        }
        /// <summary>
        /// proerty for flightobject
        /// </summary>
        public Flight flyer
        {
            get { return flight; }
        }
        public PlaneTookOffEffect TookOff
        {
            get { return pt; }
        }
        /// <summary>
        /// this function is used to set up the gui
        /// </summary>
        ///         
        //events set up behind the scenes of flightwindow these are then called by the buttonpress functions below
        public  event EventHandler<TakeOffEventArgs> FlightHasStarted;
        public event EventHandler<ChangeRouteEventArgs> FlightHasChangedRoute;
        public  event EventHandler<LandEventArgs> FlightWasLanded;
        public event EventHandler<StartEffectEvetArgs> EffectStarted;
        private void SetUpGui()
        {
            // set up the comboboxes to contain the information in the enums Routes and Destinations respectively
            ___cmbChangeRoute_.ItemsSource = Enum.GetNames(typeof(Routes));// adds the names for the routes
            ___cmbChangeRoute_.SelectedIndex = (int)Routes.Default; // set the heading to default
            ___cmbChangeRoute_.IsEditable = false;// you cannot edit this via the textbox feature
            ___cmbChangeRoute_.IsEnabled = false;// starts out disabled
            ___cmbDestination_.ItemsSource = Enum.GetNames(typeof(Destinations));// add the names for the destinations
            ___cmbDestination_.SelectedIndex = (int)Destinations.Egypt;// set destination to egypt
            ___cmbDestination_.IsEditable = false;
            ___btnLand_.IsEnabled = false;// you cant land unless you started first
            flight.SetImage();
            ___imgFlightPicture_.Source = flight.DestImage;

        }
        /// <summary>
        /// This method starts the flight 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartFlight_Click(object sender, RoutedEventArgs e)
        {
            if (FlightHasStarted != null)
            {
                FlightHasStarted(this, new TakeOffEventArgs() { flightId = flight.FlightIdentity});
                ___cmbDestination_.IsEnabled = false;// this are disabled at start
                ___cmbChangeRoute_.IsEnabled = true; // this can only be adjusted while flying
                ___btnLand_.IsEnabled = true;// now you can land
                ___btnStartFlight_.IsEnabled = false;// but not restart
                //start prenumeration on evet 
                if (EffectStarted != null)
                    EffectStarted(this, new StartEffectEvetArgs() {current = this});
            }
           
        } 
        /// <summary>
        /// This method lands the plane(and closes the window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLandPlane_Click(object sender, RoutedEventArgs e)
        {
            if (FlightWasLanded != null)
            {
                FlightWasLanded(this, new LandEventArgs() { flightId = flight.FlightIdentity });
                Close();
            }
            
        }
        /// <summary>
        /// This is fired whenever the combobox for routes are changed and calls a method that updates the route accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbChangeRoute_SelectionChange(object sender, RoutedEventArgs e)
        {
            //if cmbChangeRoute.selected index is not negative
            if (___cmbChangeRoute_.SelectedIndex!=-1)
            {
                // read the selected index
                flight.Heading = (Routes)___cmbChangeRoute_.SelectedIndex;
                // start the event
                if (FlightHasChangedRoute != null)
                    FlightHasChangedRoute(this, new ChangeRouteEventArgs() { flightId = flight.FlightIdentity, myRoute = flight.Heading });
            }
           
        }
        /// <summary>
        /// Whenever the the destination is changed(cannot be done while flying) this are updated alonside the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDestinations_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (___cmbDestination_.SelectedIndex != -1)
            {
                // read combobox
                flight.Destination = (Destinations)___cmbDestination_.SelectedIndex;
                flight.SetImage();

                //update destination picture
                ___imgFlightPicture_.Source = flight.DestImage;
            }
        }
    }
}
