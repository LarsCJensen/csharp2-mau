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
using System.Windows.Shapes;
using Assignment3.Animals;

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        private FoodItem foodItem;
        public FoodItem FoodItem
        {
            get
            {
                return foodItem;
            }            
        }
        
        public AddFood()
        {            
            InitializeComponent();
            foodItem = new FoodItem();
            InitializeGUI();
        }
        // Function to initialize GUI
        private void InitializeGUI()
        {
            txtName.Text = String.Empty;
            txtIngredient.Text = String.Empty;            
        }
        /// <summary>
        /// Add ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateInput())
            {
                lbIngredients.Items.Add(txtIngredient.Text);
                txtIngredient.Text = String.Empty;
            } 
        }
        /// <summary>
        /// Validate input
        /// </summary>
        /// <returns>bool</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtIngredient.Text))
            {
                MessageBox.Show("You must provide an ingredient for the food schedule!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Edit ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an ingredient to edit!", "Choose ingredient!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((sender as Button).Content.ToString() == "Edit")
            {
                btnAdd.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = false;
                btnEdit.Content = "Save";
                txtIngredient.Text = lbIngredients.Items.GetItemAt(lbIngredients.SelectedIndex).ToString();
            } else
            {
                lbIngredients.Items[lbIngredients.SelectedIndex] = txtIngredient.Text;
                btnAdd.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = true;
                btnEdit.Content = "Edit";
                txtIngredient.Text = "";
            }
            
        }
        /// <summary>
        /// Delete ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbIngredients.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an ingredient to delete!", "Choose ingredient!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (lbIngredients.SelectedIndex >= 0)
            {
                lbIngredients.Items.RemoveAt(lbIngredients.SelectedIndex);
            }
        }
        /// <summary>
        /// Cancel adding food items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        /// <summary>
        /// Save food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foodItem.Name = txtName.Text;
            foreach (string item in lbIngredients.Items)
            {
                foodItem.Ingredients.Add(item);
            }
            this.DialogResult = true;
        }
    }    
}
