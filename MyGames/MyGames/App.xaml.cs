using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MyGames.Views;
using MyGames.ViewModels;
using MyGames.Models;
using System.Data.Entity;


namespace MyGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //https://stackoverflow.com/questions/40461392/deploying-entity-framework-wpf-application
            base.OnStartup(e);
            // Initialize Database           
            MainWindow window = new MainWindow();
            // Create the ViewModel to which 
            // the main window binds. 
            MainViewModel viewModel = new MainViewModel();
            // When the ViewModel asks to be closed, 
            // close the window. 
            viewModel.RequestClose += delegate { window.Close(); };
            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree. 

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
