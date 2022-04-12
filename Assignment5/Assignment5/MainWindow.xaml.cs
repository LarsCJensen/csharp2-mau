using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<FlightInformation> flightInformation = new ObservableCollection<FlightInformation>();        
        public ObservableCollection<FlightInformation> FlightInformation
        {
            get
            {
                return flightInformation;
            }
            set
            {
                flightInformation = value;
                NotifyPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitializeGUI();
        }
        public void InitializeGUI() 
        { 
            // TODO What to do here
            // Clear listview

        }
        #region EventHandlers
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void btnSendAirplane_Click(object sender, RoutedEventArgs e)
        {
            if(txtFlight.Text.Length > 0)
            {
                AddFlight addFlightPage = new AddFlight(txtFlight.Text);

                addFlightPage.Show();
                addFlightPage.StartFlight += OnStartFlight;
                addFlightPage.ChangeRoute += OnChangeRoute;
                addFlightPage.LandPlane += OnLandPlane;
                addFlightPage.LandPlane += OnLandPlanePopup;
                txtFlight.Text = string.Empty;
            } else
            {
                MessageBox.Show("You must issue a flight number to start!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        /// <summary>
        /// Method to be fired upon on start flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartFlight(object sender, TakeOff e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);            
        }
        /// <summary>
        /// Method to be fired upon on change route 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeRoute(object sender, ChangeRoute e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);
        }
        /// <summary>
        /// Method to be fired upon Land event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLandPlane(object sender, LandPlane e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);
        }
        /// <summary>
        /// Method to be fired upon Land event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLandPlanePopup(object sender, LandPlane e)
        {
            SplashScreen splash = new SplashScreen(@"Assets/horray.png");
            splash.Show(true);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"Assets/much_rejoicing.wav";
            player.Play();
            Thread.Sleep(3000);
        }

        #endregion
    }
}
