/***
 * Lars Jensen 2022-05-08
 */
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        List<TreeViewItem> selectedItems = new List<TreeViewItem>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {            
            AddLogicalDrives();            
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
                // TODO
                catch (Exception) { }
            }
        }
        private void btnFindDuplicates_Click(object sender, RoutedEventArgs e)
        {            
            string validationString = validateInput();            
            if(validationString != string.Empty)
            {
                MessageBox.Show(validationString, "Validation error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get all directories, with sub directories if needed
            List<string> chosenDirectories = new List<string>(getChosenDirectories());

            // Get all files in chosen directories
            List<string> files = new List<string>();
            foreach (string dir in chosenDirectories)
            {
                files.AddRange(GetFilesInDir(dir));
            }

            List<(FileInfo FileInfo, string Checksum, int DuplicateId)> duplicates = new List<(FileInfo FileInfo, string Checksum, int DuplicateId)>();
            // Remove files which are marked as duplicates
            // For each file, check if it is duplicate(s)
            int i = 0;
            //TODO REMOVE
            List<string> filesCopy = new List<string>(files);
            foreach (string file in files)
            {
                // Remove file from list as not to compare to itself
                filesCopy.Remove(file);
                // TODO REMOVE
                if (file == "C:\\Temp\\duplicates\\Text till CV.docx")
                {
                    Console.WriteLine("Test");
                }
                duplicates.AddRange(GetDuplicates(file, i, ref filesCopy));
                i++;
            }

            List<FileClass> duplicateFiles = new List<FileClass>();
            foreach (var duplicate in duplicates)
            {                
                FileClass file = new FileClass(duplicate);
                duplicateFiles.Add(file);
            }

            string dirsString = GetDirsText();
            // Text to be shown regarding selected folders and filters
            string filtersText = $"Folder(s): {dirsString.Remove(dirsString.Length -2, 2)}\n";
            string chkBoxText = GetFilterText();
            filtersText += $"Filter(s): {chkBoxText.Remove(chkBoxText.Length -2, 2)}";
            DuplicateList duplicateList = new DuplicateList(duplicateFiles, filtersText);
            duplicateList.Show();            
        }
        
        private void fileTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if((TreeViewItem)fileTree.SelectedItem == null)
            {
                return;
            }

            //fileTree.SelectedItem.IsSelected = false;
            TreeViewItem selectedItem = (TreeViewItem)fileTree.SelectedItem;            
            selectedItem.Background = Brushes.Blue;
            selectedItem.Foreground = Brushes.White;

            if (!ShiftPressed)
            {
                ResetSelectedItems();
                selectedItems = new List<TreeViewItem> { (TreeViewItem)fileTree.SelectedItem };
                //chosenDirectories = new List<string> { ((TreeViewItem)fileTree.SelectedItem).Tag.ToString() };

            } else
            {
                selectedItems.Add((TreeViewItem)fileTree.SelectedItem);
                //chosenDirectories.Add(((TreeViewItem)fileTree.SelectedItem).Tag.ToString());
            }
            selectedItem.IsSelected = false;
        }
        
    }
    
}

