using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Assignment6
{
    partial class MainWindow
    {
        /// <summary>
        /// Property if shift is pressed, for multi-select
        /// </summary>
        bool ShiftPressed
        {
            get
            {
                return System.Windows.Input.Keyboard.IsKeyDown(Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(Key.RightShift);
            }
        }
        /// <summary>
        /// Reset colors of selected items
        /// </summary>
        private void ResetSelectedItems()
        {
            foreach (TreeViewItem item in selectedItems)
            {
                item.Background = Brushes.White;
                item.Foreground = Brushes.Black;
            }
        }
        /// <summary>
        /// Helper method to compare two values
        /// </summary>
        /// <param name="val1">First value to compare</param>
        /// <param name="val2">Second value to compare</param>
        /// <returns>Bool</returns>
        private bool IsAttributeEqual(object val1, object val2)
        {
            return val1.Equals(val2);
        }
        /// <summary>
        /// Helper method to check if filters are used
        /// </summary>
        /// <returns>Bool</returns>
        private bool NoFiltersAreSelected()
        {
            if (chkCreatedDate.IsChecked == false && chkModifiedDate.IsChecked == false && chkSize.IsChecked == false && chkFileType.IsChecked == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to get checksum of a file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Checksum of file</returns>
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
        
        /// <summary>
        /// Function to get duplicates and return a tuple with file information
        /// </summary>
        /// <param name="file">File to find duplicates for</param>
        /// <param name="fileId">File id to group duplicates</param>
        /// <param name="files">Files to compare with</param>
        /// <returns></returns>
        private List<(FileInfo FileInfo, string Checksum, int DuplicateId)> GetDuplicates(string file, int fileId, ref List<string> files, List<string> chosenAttributes)
        {
            List<(FileInfo FileInfo, string Checksum, int DuplicateId)> duplicates = new List<(FileInfo FileInfo, string Checksum, int DuplicateId)>();
            FileInfo fileInfo = new FileInfo(file);
            foreach (string fileToCompare in files.ToList())
            {
                FileInfo fileToCompareInfo = new FileInfo(fileToCompare);
                bool isDuplicate = false;
                // Loop over checkboxes and check if they are checked
                //var chkBoxes = LogicalTreeHelper.GetChildren(searchAttributes).OfType<CheckBox>();
                //foreach (CheckBox checkBox in chkBoxes)
                //{
                //    if (checkBox.IsChecked != true)
                //    {
                //        continue;
                //    }
                foreach(string attribute in chosenAttributes)
                {   
                    // Set to true to be able to break out on first false
                    isDuplicate = true;
                    isDuplicate = checkDuplicatesForChosenAttributes(attribute, fileInfo, fileToCompareInfo);
                    // If one check fails, break loop
                    if (isDuplicate == false)
                    {
                        break;
                    }
                }
                if (isDuplicate)
                {                    
                    (FileInfo FileInfo, string Checksum, int DuplicateId) fileTuple;
                    // Add file which is compared against first time
                    if (duplicates.Count == 0)
                    {
                        fileTuple = GetDuplicate(fileInfo, fileId);
                        duplicates.Add(fileTuple);
                    } 
                    fileTuple = GetDuplicate(fileToCompareInfo, fileId);
                    duplicates.Add(fileTuple);
                    // Remove the file from files so we don't compare the same files multiple times
                    files.Remove(fileToCompare);
                }

            }
            return duplicates;
        }
        private (FileInfo FileInfo, string Checksum, int DuplicateId) GetDuplicate(FileInfo file, int fileId)
        {
            string checkSum = GetChecksum(file.FullName);
            var fileTuple = (
                FileInfo: file,
                Checksum: checkSum,
                DuplicateId: fileId
            );
            return fileTuple;
        }

        private bool checkDuplicatesForChosenAttributes(string attribute, FileInfo fileInfo, FileInfo fileToCompareInfo)
        {
            bool isDuplicate = false;
            switch (attribute)
            {
                case "chkCreatedDate":
                    isDuplicate = IsAttributeEqual(fileInfo.CreationTimeUtc, fileToCompareInfo.CreationTimeUtc);
                    break;
                case "chkModifiedDate":
                    isDuplicate = IsAttributeEqual(fileInfo.LastWriteTimeUtc, fileToCompareInfo.LastWriteTime);
                    break;
                case "chkSize":
                    isDuplicate = IsAttributeEqual(fileInfo.Length.ToString(), fileToCompareInfo.Length.ToString());
                    break;
                case "chkFileType":
                    isDuplicate = IsAttributeEqual(fileInfo.Extension, fileToCompareInfo.Extension);
                    break;
            }            
            return isDuplicate;
        }
        /// <summary>
        /// Validation method for input
        /// </summary>
        /// <returns>Error string</returns>
        private string validateInput()
        {
            string validationString = string.Empty;
            if (selectedItems.Count() == 0)
            {
                validationString = "You have to select atleast one folder!\n";
            }
            if (NoFiltersAreSelected())
            {
                validationString += "You must choose a filter to compare with!";
            }
            return validationString;
        }
        /// <summary>
        /// Helper method to return all chosen directories, with subdirectories
        /// </summary>
        /// <returns>List of directories as strings</returns>
        private IEnumerable<string> getChosenDirectories(List<string> chosenDirectories, bool? includeSubdirectories)
        {
            //List<string> chosenDirectories = new List<string>();
            //foreach (TreeViewItem item in selectedItems)
            //{
            //    chosenDirectories.Add(item.Tag.ToString());                
            //}

            // If include sub-dirs then loop those too
            if (includeSubdirectories == true)
            {
                try
                {
                    var dirs = GetSubdirectories(chosenDirectories[0]).ToList();
                    for (var i = 0; i < dirs.Count; i++)
                    {
                        try
                        {
                            dirs.AddRange(GetSubdirectories(dirs[i]));
                        }
                        catch (System.UnauthorizedAccessException ex)
                        {
                            // We ignore if certain subfolders are not accessible
                            // Would add them to a log
                            continue;
                        }
                    }
                    chosenDirectories.AddRange(dirs);
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message, "Unauthorized access!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                
            }
            return chosenDirectories;
        }
        // Helper function to get subdirectories
        private List<string> GetSubdirectories(string dir)
        {
            return Directory.GetDirectories(dir).ToList();
        }
        // Helper function to get files in directory
        private List<string> GetFilesInDir(string folder)
        {
            return Directory.GetFiles(folder).ToList();
        }
        private string GetDirsText()
        {
            // String to be used when showing duplicates
            string dirsString = string.Empty;

            foreach (TreeViewItem item in selectedItems)
            {
                dirsString += $"{item.Tag.ToString()}, ";
            }
            return dirsString;
        }
        // Helper function to get content of checked checkboxes
        private string GetFilterText()
        {
            string retString = string.Empty;
            var chkBoxes = LogicalTreeHelper.GetChildren(searchAttributes).OfType<CheckBox>();
            foreach (CheckBox checkBox in chkBoxes)
            {
                if (checkBox.IsChecked != true)
                {
                    continue;
                }
                retString += $"{checkBox.Content}, ";                
            }
            return retString;
        }
    }

}
