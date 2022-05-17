using MyGames.Model;
using System.Data.Entity;
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

namespace MyGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }
        private void Test()
        {
            //using (var db = new MyGamesContext())
            //{                
            //    var game = new Game { Title = "test" };
            //    db.Games.Add(game);
            //    db.SaveChanges();

            //    // Display all Blogs from the database
            //    var query = from b in db.Games
            //                orderby b.Title
            //                select b;

            //    foreach (var item in query)
            //    {
            //        MessageBox.Show(item.Title);
            //    }
            //}
        }
    }
}
