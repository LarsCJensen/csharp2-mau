using MyGames.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace MyGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            //View.MainWindow window = new View.MainWindow();
            //// Create the ViewModel to which 
            //// the main window binds. 
            //var viewModel = new MainViewModel();
            //// When the ViewModel asks to be closed, 
            //// close the window. 
            //viewModel.RequestClose += delegate { window.Close(); };
            //// Allow all controls in the window to 
            //// bind to the ViewModel by setting the 
            //// DataContext, which propagates down 
            //// the element tree. 
            
            //window.DataContext = viewModel;
            //window.Show();
        }
    }
}
