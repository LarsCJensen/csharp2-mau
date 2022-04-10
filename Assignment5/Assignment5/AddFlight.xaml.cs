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
        public string flightNo;
        List<string> _airlines = new List<string>() { "AA", "BA", "CZ", "KQ", "SK" };
        
        public event EventHandler<FlightInformation> StartFlight;
        public event EventHandler<FlightInformation> ChangeRoute;
        public event EventHandler<FlightInformation> LandPlane;
        public AddFlight(string flightNumber)
        {
            flightNo = flightNumber;
            InitializeComponent();
            DataContext = this;
            this.Title = flightNumber;
            InitializeGUI();

        }
        public void InitializeGUI()
        {
            SetLogo();            
        }
        # region Helpers
        private void SetLogo()
        {
            string airlineCode = flightNo.Substring(2);
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
            
            // TODO REMOVE
            //switch (airlineCode)
            //{                
            //    case "AA":
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/aa.png", UriKind.Absolute));
            //        break;
            //    case "BA":
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/ba.png", UriKind.Absolute));
            //        break;
            //    case "CZ":
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/cz.png", UriKind.Absolute));
            //        break;
            //    case "KQ":
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/kq.png", UriKind.Absolute));
            //        break;
            //    case "SK":
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/sk.png", UriKind.Absolute));
            //        break;
            //    default:
            //        imgLogo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/default.png", UriKind.Absolute));
            //        break;
            //}
        }
        #endregion
        #region EventHandlers
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            FlightInformation flightInfo = new FlightInformation(flightNo, "Started");
            OnStart(flightInfo);
        }
        public void OnStart(FlightInformation e)
        {

        }
        public void OnChangeRoute(FlightInformation e)
        {

        }
        public void OnStartLand(FlightInformation e)
        {

        }
        #endregion

    }
}
