/*
 * 2022-04-13 Lars Jensen
 */
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
        /// <summary>
        /// Observable collection of FlightInformation to populate listview with
        /// </summary>
        public ObservableCollection<FlightInformation> FlightInformation
        {
            get
            {
                return flightInformation;
            }
            set
            {
                flightInformation = value;
                // When new value is set, notify
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
            // Nothing really to do here
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
        /// <summary>
        /// Event method for Add flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAirplane_Click(object sender, RoutedEventArgs e)
        {
            if(txtFlight.Text.Length > 0)
            {
                AddFlight addFlightPage = new AddFlight(txtFlight.Text);

                addFlightPage.Show();
                // Bind events to methods
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
            // Create instance of FlightInformation with information from event
            // Checks to make sure properties exist on event might be a good idea
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
            // Create instance of FlightInformation with information from event
            // Checks to make sure properties exist on event might be a good idea
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
            // Create instance of FlightInformation with information from event
            // Checks to make sure properties exist on event might be a good idea
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
            // Show splash with image from one of my favorite movies
            SplashScreen splash = new SplashScreen(@"Assets/horray.png");
            splash.Show(true);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"Assets/much_rejoicing.wav";
            // Play sound from the scene of one of my favorite movies
            player.Play();
            // Wait three seconds and then close splash
            Thread.Sleep(3000);
        }

        #endregion
    }
}
