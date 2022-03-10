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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateInput())
            {
                lbIngredients.Items.Add(txtIngredient.Text);
                txtIngredient.Text = String.Empty;
            } 
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtIngredient.Text))
            {
                MessageBox.Show("You must provide an ingredient for the food schedule!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // TODO How to check for if Edit
            if(lbIngredients.SelectedIndex >= 0)
            {
                txtIngredient.Text = foodItem.Ingredients.GetAt(lbIngredients.SelectedIndex);
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbIngredients.SelectedIndex >= 0)
            {
                lbIngredients.Items.RemoveAt(lbIngredients.SelectedIndex);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

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
