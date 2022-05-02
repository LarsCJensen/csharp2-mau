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
using System.Windows.Shapes;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for DuplicateList.xaml
    /// </summary>
    public partial class DuplicateList : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<FileClass> duplicateFiles = new ObservableCollection<FileClass>();
        public ObservableCollection<FileClass> DuplicateFiles
        {
            get
            {
                return duplicateFiles;
            }
            set
            {
                duplicateFiles = value;
                // When new value is set, notify
                NotifyPropertyChanged();
            }
        }
        public DuplicateList()
        {
            InitializeComponent();
            InitializeGUI();
            DataContext = this;
        }
        private void InitializeGUI()
        {

        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
