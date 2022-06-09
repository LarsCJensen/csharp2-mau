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
            // Set database initializer
            Database.SetInitializer(new MyGamesInitializer());
            //https://stackoverflow.com/questions/40461392/deploying-entity-framework-wpf-application
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
