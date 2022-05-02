using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private object dummyNode = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }
        // TODO CLasses
        // File, Icon, Name, Path, DateCreated, DateModified
        // FileType (Enum), File, Folder, Drive
        private void InitializeGUI()
        {
            // Välj katalog via fileDialog
            // Kryssruta "Inkludera sub-folders"
            // Vilka attribute att jämföra med?

            AddLogicalDrives();            
        }
        /// <summary>
        /// Event for when folder is expanded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(FolderExpanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// Helper method to add logical drives to treeview
        /// </summary>
        private void AddLogicalDrives()
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                // Adding a dummyNode to make first expand work
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(FolderExpanded);
                fileTree.Items.Add(item);
            }
        }
        // TODO REMOVE
        public void foldersItem_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }
        // TODO REMOVE
        private void btnChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "BMP|*.bmp|JPG|*.jpg|PNG|*.png|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                //imgAnimal.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
            }
        }

        private void btnFindDuplicates_Click(object sender, RoutedEventArgs e)
        {
            string validationString = string.Empty;
            if (fileTree.SelectedItem == null)
            {
                
                validationString = "You have to select a folder!\n";                
            }
            if (NoFiltersAreSelected())
            {
                validationString = validationString + "You must choose a filter to compare with!";                                   
            }
            if(validationString != string.Empty)
            {
                // TODO buttons ERROR etc
                MessageBox.Show(validationString, "Validation error!");
                return;
            }
            List<string> directories = new List<string>() { ((TreeViewItem)fileTree.SelectedItem).Tag.ToString() };
            // If include sub-dirs then loop
            if (chkIncludeSubfolders.IsChecked == true)
            {
                // TODO recursive getdirs
                var dirs = GetSubdirectories(directories[0]).ToList(); 
                for(var i=0; i< dirs.Count; i++)
                {
                    dirs.AddRange(GetSubdirectories(dirs[i]));
                }
                directories.AddRange(dirs);                
            }
            List<string> files = new List<string>();
            foreach (string folder in directories)
            {
                files.AddRange(GetFilesInFolder(folder));
            }
            // TODO Compare tuples in A assignment

            List<FileInfo> duplicates = new List<FileInfo>();
            // For each file, check if it is similar to others
            foreach (string file in files)
            {
                List<string> filesCopy = new List<string>(files);
                // Remove file from list as not to compare to itself
                filesCopy.Remove(file);
                duplicates = GetDuplicates(file, filesCopy);                
            }
            
            List<FileInfo> cleanedList = duplicates.Distinct().ToList();            
            foreach (FileInfo duplicate in cleanedList)
            {
                string checkSum = GetChecksum(duplicate.FullName);

                // TODO Based on selected comparison,                 
                var fileTuple = (
                    Name: duplicate.Name,
                    Path: duplicate.DirectoryName,
                    DateCreated: duplicate.CreationTimeUtc,
                    DateModified: duplicate.LastWriteTimeUtc,
                    Size: duplicate.Length.ToString(),
                    Checksum: checkSum
                );
            }
        }
        private string GetChecksum(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private List<string> GetFilesInFolder(string folder)
        {
            return Directory.GetFiles(folder).ToList();
        }
        private List<string> GetSubdirectories(string dir)
        {
            return Directory.GetDirectories(dir).ToList();
        }   
        private List<FileInfo> GetDuplicates(string file, List<string> files)
        {
            // TODO Hur markera de filer som är lika?
            List<FileInfo> duplicates = new List<FileInfo>();
            FileInfo fileInfo = new FileInfo(file);
            bool isDuplicate = false;
            foreach(string fileToCompare in files)
            {
                FileInfo fileToCompareInfo = new FileInfo(fileToCompare);
                if (chkCreatedDate.IsChecked == true)
                {
                    isDuplicate = IsAttributeEqual(fileInfo.CreationTimeUtc, fileToCompareInfo.CreationTimeUtc);
                }
                if (chkModifiedDate.IsChecked == true)
                {
                    isDuplicate = IsAttributeEqual(fileInfo.LastWriteTimeUtc, fileToCompareInfo.LastWriteTime);
                }
                if (chkSize.IsChecked == true)
                {
                    isDuplicate = IsAttributeEqual(fileInfo.Length.ToString(), fileToCompareInfo.Length.ToString());
                }
                if (chkFileType.IsChecked == true)
                {
                    isDuplicate = IsAttributeEqual(fileInfo.Extension, fileToCompareInfo.Extension);
                }
                if(isDuplicate)
                {
                    duplicates.Add(fileInfo);
                }                    
            }
            return duplicates;
        }
        private bool IsAttributeEqual(object val1, object val2)
        {
            return val1 == val2;
        }
        private bool NoFiltersAreSelected()
        {
            if (chkCreatedDate.IsChecked == false && chkModifiedDate.IsChecked == false && chkSize.IsChecked == false && chkFileType.IsChecked == false)
            {
                return true;
            }
            return false;
        }
    }
    
}

