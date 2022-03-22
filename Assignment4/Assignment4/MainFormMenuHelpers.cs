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
        /// Helper function for Menu
        /// </summary>
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            if (dataFile != null)
            {
                try
                {
                    animalManager.BinarySerialize(dataFile);
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MenuItemSaveAsBinary_Click(sender, e);
            }
        }
        private void MenuItemSaveAsBinary_Click(object sender, RoutedEventArgs e)
        {
            // Open FileDialog
            // Save AnimalList as binary
            var dialog = new SaveFileDialog();
            dialog.Filter = "BIN|*.bin|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    animalManager.BinarySerialize(dialog.FileName);
                    dataFile = dialog.FileName;
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
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
                    // TODO Move to own function
                    List<Animal> animals = animalManager.BinaryDeSerialize(dialog.FileName);
                    foreach (Animal animal in animals)
                    {
                        animalManager.Add(animal);
                        listOfAnimals.Add(animal);
                    }
                    lvAnimalList.Items.Refresh();
                    dataFile = dialog.FileName;
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
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
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
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
            animal = null;
            dataFile = null;
            listOfAnimals.Clear();
            animalManager.DeleteAll();
            foodManager.DeleteAll();
            // TODO
            // FoodAnimalDict Clear
            // If change has been done, ask to save
            InitializeGUI();
        }

        private void MenuItemOpenAsText_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "TXT|*.txt|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    List<Animal> animals = animalManager.TextFileDeSerialize(dialog.FileName);
                    foreach (Animal animal in animals)
                    {
                        animalManager.Add(animal);
                        listOfAnimals.Add(animal);
                    }
                    lvAnimalList.Items.Refresh();
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

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
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MenuItemOpenAsXml_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "XML|*.xml|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    // TODO Move to own function
                    List<Animal> animals = animalManager.XmlFileDeSerialize(dialog.FileName);
                    foreach (Animal animal in animals)
                    {
                        animalManager.Add(animal);
                        listOfAnimals.Add(animal);
                    }
                    lvAnimalList.Items.Refresh();
                    dataFile = dialog.FileName;
                }
                // TODO
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
