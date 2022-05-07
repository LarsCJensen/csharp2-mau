using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
        private string filterText;
        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                NotifyPropertyChanged();
            }
        }  
        public DuplicateList(List<FileClass> duplicates, string filters)
        {
            InitializeComponent();
            DataContext = this;
            duplicateFiles = new ObservableCollection<FileClass>(duplicates);
            InitializeGUI(filters);

        }
        private void InitializeGUI(string filters)
        {
            
            filterText = "Duplicates found using filters:\n\n"; 
            filterText += filters;
        }
        /// <summary>
        /// Method to notify bound property changed
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<FileClass> filesToDelete = new List<FileClass>();
            foreach(FileClass file in lstDuplicateFiles.SelectedItems)
            {
                filesToDelete.Add(file);            
            }
            if(filesToDelete.Count == 0)
            {
                MessageBox.Show("You need to choose which files to delete!", "No files chosen!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete the selected files?", "Are you sure?",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // TODO Return which files that could not be deleted
                string errors = DeleteChosenFiles(filesToDelete);
                if (errors != string.Empty)
                {
                    MessageBox.Show(errors, "All files could not be deleted!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("All files have been deleted!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Chceck if files are chosen
            // Validate that deletions are ok?            
            // Delete
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (duplicateFiles.Count == 0)
            {
                // TODO Improve?
                MessageBox.Show("No duplicates found in the chosen folder(s)!", "No duplicates found!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            SetBackgroundColor();
        }
        private void SetBackgroundColor()
        {
            //lstDuplicateFiles
            int previousDuplicateId = 0;
            foreach (var item in lstDuplicateFiles.Items)
            {
                previousDuplicateId = 0;
                //    var file = DuplicateFilesList.ItemContainerGenerator.ItemFromContainer(item) as FileClass;
                //    if (file.DuplicateId == previousDuplicateId) 
                //    { 
                //    }
                //    item.Background = Brushes.AliceBlue;
                //}
                //for (int i = 0; i < DuplicateFilesList.Items.Count; i++)
                //{

                //    previousDuplicateId = ((FileClass)DuplicateFilesList.Items[i]).DuplicateId;
                //    ((ListViewItem)DuplicateFilesList.Items[i]).Background = new SolidColorBrush(RandomColorGenerator.generateRandomColor());

            }
        }
        private string DeleteChosenFiles(List<FileClass> filesToDelete)
        {
            string errorMsg = string.Empty;
            foreach (FileClass file in filesToDelete)
            {
                try
                {
                    file.Delete();
                }
                catch (FileNotFoundException ex)
                {
                    errorMsg += $"Could not delete: {file.Name}. File not found!\n";
                    // Continue deletion of other files
                    continue;
                }
                catch (Exception ex)
                {
                    errorMsg += $"Exception occured {ex.StackTrace}";
                }
            }
            return errorMsg;

        }
    }
}
