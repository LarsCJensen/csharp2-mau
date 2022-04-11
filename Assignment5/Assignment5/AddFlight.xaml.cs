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

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Window
    {
        public string FlightNo;

        List<string> _airlines = new List<string>() { "AA", "BA", "CZ", "KQ", "SK" };
        List<string> _changeRoute = new List<string> { "30 degrees", "45 degrees", "60 degrees", "90 degrees", "180 degrees" };

        public event EventHandler<TakeOff> StartFlight;
        public event EventHandler<ChangeRoute> ChangeRoute;
        public event EventHandler<LandPlane> LandPlane;
        public AddFlight(string flightNumber)
        {
            FlightNo = flightNumber;
            InitializeComponent();
            DataContext = this;
            this.Title = flightNumber;
            InitializeGUI();

        }
        public void InitializeGUI()
        {   
            cboChange.ItemsSource = _changeRoute;
            SetLogo();            
        }
        # region Helpers
        private void SetLogo()
        {
            string airlineCode = FlightNo.Substring(0, 2);
            try
            {
                if (_airlines.Contains(airlineCode)) 
                {
                    imgLogo.Source = new BitmapImage(new Uri($@"pack://application:,,,/Assets/{airlineCode.ToLower()}.png", UriKind.Absolute)); 

                }
                else
                {
                    imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/default.png", UriKind.Absolute));
                }
            }
            catch (Exception ex)
            {
                //TODO WRITE MESSAGE
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            TakeOff takeOff = new TakeOff(FlightNo, "Sent to runway");
            OnStart(takeOff);
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
            string status = (sender as ComboBox).SelectedItem.ToString();
            ChangeRoute changeRoute = new ChangeRoute(FlightNo, $"Now heading {status}");
            OnChangeRoute(changeRoute);
        }

        private void btnLand_Click(object sender, RoutedEventArgs e)
        {
            LandPlane landPlane= new LandPlane(FlightNo, "Landing");
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
