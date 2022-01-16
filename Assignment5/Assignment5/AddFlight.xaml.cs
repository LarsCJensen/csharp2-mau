using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Window
    {
        public string FlightNo;


        List<string> _airlineCodes = new List<string>() { "AA", "BA", "CZ", "KQ", "SK", "AF" };
        List<string> _changeRoutes = new List<string> { "30 degrees", "45 degrees", "60 degrees", "90 degrees", "180 degrees" };

        /// <summary>
        /// Event handlers
        /// </summary>
        public event EventHandler<TakeOff> StartFlight;
        public event EventHandler<ChangeRoute> ChangeRoute;
        public event EventHandler<LandPlane> LandPlane;
        /// <summary>
        /// Constructor to Add a flight
        /// </summary>
        /// <param name="flightNumber">Flight number to add</param>
        public AddFlight(string flightNumber)
        {
            FlightNo = flightNumber;
            InitializeComponent();
            DataContext = this;
            InitializeGUI();

        }
        public void InitializeGUI()
        {
            // Set flight number for title
            this.Title = FlightNo;
            cboChange.ItemsSource = _changeRoutes;
            // Set logo of airline, if exists
            SetLogo();            
        }
        # region Helpers
        private void SetLogo()
        {
            string airlineCode = FlightNo.Substring(0, 2);
            try
            {
                if (_airlineCodes.Contains(airlineCode.ToUpper())) 
                {
                    // If user adds arilne with airline code use asset with airline code name
                    // PS Try to use airline code AF
                    imgLogo.Source = new BitmapImage(new Uri($@"pack://application:,,,/Assets/{airlineCode.ToLower()}.png", UriKind.Absolute)); 
                }
                else
                {
                    // Use default image
                    imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/default.png", UriKind.Absolute));
                }
            }
            catch (IOException)
            {
                string message =  $"No image for the airline {airlineCode.ToUpper()} exists. Please add it to Assets! Using default for now.";
                MessageBox.Show(message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                // Use default image
                imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/default.png", UriKind.Absolute));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region EventHandlers
        /// <summary>
        /// Event for clicking start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            TakeOff takeOff = new TakeOff(FlightNo);            
            OnStart(takeOff);
            // Disable/Enable buttons
            btnStart.IsEnabled = false;
            cboChange.IsEnabled = true;
            btnLand.IsEnabled = true;
        }
        /// <summary>
        /// Event for changing route
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string route = (sender as ComboBox).SelectedItem.ToString();
            ChangeRoute changeRoute = new ChangeRoute(FlightNo, route);
            OnChangeRoute(changeRoute);
        }
        /// <summary>
        /// Event for Landing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLand_Click(object sender, RoutedEventArgs e)
        {
            LandPlane landPlane= new LandPlane(FlightNo);
            OnLandPlane(landPlane);
            // Close window
            this.Close();
        }
        /// <summary>
        /// Event handler for OnStart
        /// </summary>
        /// <param name="e"></param>
        private void OnStart(TakeOff e)
        {
            if(StartFlight != null)
            {
                StartFlight(this, e);
            }
        }
        public void OnChangeRoute(ChangeRoute e)
        {
            if (ChangeRoute != null)
            {
                ChangeRoute(this, e);
            }
        }
        public void OnLandPlane(LandPlane e)
        {
            if (LandPlane != null)
            {
                LandPlane(this, e);
            }
        }
        #endregion
    }
}
