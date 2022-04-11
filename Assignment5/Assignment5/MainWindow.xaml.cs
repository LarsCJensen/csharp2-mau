using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            // What to do here
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
            AddFlight addFlightPage = new AddFlight(txtFlight.Text);

            addFlightPage.Show();
            addFlightPage.StartFlight += OnStartFlight;
            addFlightPage.ChangeRoute += OnChangeRoute;
            addFlightPage.LandPlane += OnLandPlane;
            // What to check for?
            //if (addFlightPage.ShowDialog() == true)
            //{
            //    // If Land is pressed??
            //} else
            //{

            //}
            //    foodManager.Add(addFoodWindow.FoodItem);
            //    foodItems = GetAllFoodItems();
            //    lbFoodItems.ItemsSource = foodItems;
            //    lbFoodItems.Items.Refresh();

            //}
            //else
            //{
            //    // Cancel was clicked
            //}
        }
        private void OnStartFlight(object sender, TakeOff e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);            
        }
        private void OnChangeRoute(object sender, ChangeRoute e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);
        }
        private void OnLandPlane(object sender, LandPlane e)
        {
            FlightInformation flightInfo = new FlightInformation(e.FlightNumber, e.FlightStatus, e.Timestamp);
            flightInformation.Add(flightInfo);
        }
        #endregion
    }
}
