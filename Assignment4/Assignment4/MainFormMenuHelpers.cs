using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Assignment4.Animals;
using Assignment4.Birds;
using Assignment4.Insects;
using Assignment4.Mammals;
using Assignment4.Reptiles;
using Assignment4.Helpers;

namespace Assignment4
{
    public partial class MainWindow
    {
        /// <summary>
        /// Helper functions for Menu
        /// </summary>
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            if (dataFile != null)
            {
                try
                {
                    animalManager.BinarySerialize(dataFile);
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MenuItemSaveAsBinary_Click(sender, e);
            }
        }
        private void MenuItemSaveAsBinary_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "BIN|*.bin|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    animalManager.BinarySerialize(dialog.FileName);
                    dataFile = dialog.FileName;
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuItemOpenAsBinary_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "BIN|*.bin|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    ClearGui();
                    List<Animal> animals = animalManager.BinaryDeSerialize(dialog.FileName);
                    foreach (Animal animal in animals)
                    {
                        animalManager.AddAnimal(animal);
                        listOfAnimals.Add(animal);
                    }
                    lvAnimalList.Items.Refresh();
                    dataFile = dialog.FileName;
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void MenuItemSaveAsText_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "TXT|*.txt|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    animalManager.TextFileSerialize(dialog.FileName);
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void MenuItemSaveAsTextProper_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "TXT|*.txt|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    animalManager.TextFileSerializeProper(dialog.FileName);
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Function called from menu to start a new datafile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            if(dataDirty)
            {
                MessageBoxResult result = MessageBox.Show("You have unsaved changes. Do you want to save now?", "You have unsaved changes!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MenuItemSave_Click(sender, e);
                }
            }
            ClearGui();
        }
        /// <summary>
        /// Function to open as text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenAsText_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "TXT|*.txt|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    ClearGui();
                    string[] animalInfo = animalManager.TextFileDeSerialize(dialog.FileName);
                    // Not yet implemented
                    //foreach (Animal animal in animals)
                    //{
                    //    animalManager.AddAnimal(animal);
                    //    listOfAnimals.Add(animal);
                    //}
                    //lvAnimalList.Items.Refresh();
                    // It only shows the first animalInfo in the saved text file
                    lblAnimalInfo.Content = animalInfo[0];
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void MenuItemOpenAsTextProper_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "TXT|*.txt|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    ClearGui();
                    List<Animal> animals = animalManager.TextFileDeSerializeProper(dialog.FileName);
                    foreach (Animal animal in animals)
                    {
                        animalManager.AddAnimal(animal);
                        listOfAnimals.Add(animal);
                    }
                    lvAnimalList.Items.Refresh();
                    dataDirty = false;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Function to save fooditems as xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSaveAsXml_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "XML|*.xml|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    foodManager.XmlFileSerialize(dialog.FileName);                    
                }                
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Function to open fooditems as xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenAsXml_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML|*.xml|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    // Should there be a posibility to reset the id counter upon new?
                    // It feels wrong as it is a internal counter
                    foodManager.DeleteAll();
                    List<FoodItem> items = foodManager.XmlFileDeSerialize(dialog.FileName);
                    foreach (FoodItem item in items)
                    {
                        foodManager.Add(item);
                        foodItems.Add(item);
                    }
                    lbFoodItems.Items.Refresh();
                    dataFile = dialog.FileName;
                }
                catch (SerializerException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Exit function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            if (dataDirty)
            {
                MessageBoxResult result = MessageBox.Show("You have unsaved changes. Do you want to save now?", "You have unsaved changes!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MenuItemSave_Click(sender, e);
                }
            }
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Helper function to clear everything upon new and open
        /// </summary>
        private void ClearGui()
        {
            animal = null;
            dataFile = null;
            listOfAnimals.Clear();
            animalManager.DeleteAll();            
            InitializeGUI();
        }
    }
}
