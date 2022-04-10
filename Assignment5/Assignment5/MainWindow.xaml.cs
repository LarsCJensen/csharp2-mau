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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<FlightInformation> flightInformation = new List<FlightInformation>();
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

        private void btnSendAirplane_Click(object sender, RoutedEventArgs e)
        {
            AddFlight addFlightPage = new AddFlight(txtFlight.Text);

            // What to check for?
            if (addFlightPage.ShowDialog() == true)
            {
                // If Land is pressed??
            } else
            {

            }
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
    }
}
