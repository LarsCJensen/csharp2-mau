using System;
using System.Windows;
using System.Collections.ObjectModel;
using Assignment4.Animals;
using Assignment4.Birds;
using Assignment4.Insects;
using Assignment4.Mammals;
using Assignment4.Reptiles;

namespace Assignment4
{
    public partial class MainWindow
    {
        /// <summary>
        /// Helper function to SetGUI
        /// </summary>
        private void SetGui()
        {
            if (animal == null)
            {
                lstCategoryType.SelectedItem = null;
                grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                stackDog.Visibility = Visibility.Collapsed;
                stackCat.Visibility = Visibility.Collapsed;
                stackHorse.Visibility = Visibility.Collapsed;
                stackElephant.Visibility = Visibility.Collapsed;
                stackCrocodile.Visibility = Visibility.Collapsed;
                stackSnake.Visibility = Visibility.Collapsed;
                stackButterfly.Visibility = Visibility.Collapsed;
                stackBee.Visibility = Visibility.Collapsed;
                stackSwallow.Visibility = Visibility.Collapsed;
                stackBlackbird.Visibility = Visibility.Collapsed;
                txtName.Text = String.Empty;
                txtAge.Text = String.Empty;
                rdoUnknown.IsChecked = true;
                cboEaterType.SelectedIndex = -1;
                txtDescription.Text = String.Empty;
                lstAnimalObject.ItemsSource = null;
                lstAnimalObject.Items.Clear();
                imgAnimal.Source = null;
                txtNumberOTeeth.Text = String.Empty;
                txtDogBreed.Text = String.Empty;
                chkIndoor.IsChecked = false;
                txtBoxNumber.Text = String.Empty;
                txtLocation.Text = String.Empty;
                txtAirSpeedVelocity.Text = String.Empty;
                txtBirdBreed.Text = String.Empty;
                txtIUCNCategory.Text = String.Empty;
                txtNumberOfWings.Text = String.Empty;
                txtButterflyColor.Text = String.Empty;
                txtHiveNumber.Text = String.Empty;
                txtReptileLength.Text = String.Empty;
                chkVenomous.IsChecked = false;
                txtCrodocile.Text = String.Empty;
                chkListAllAnimals.IsChecked = false;
                lstCategoryType.IsEnabled = true;
                lblAnimalInfo.Content = "";
                lbFoodSchedule.ItemsSource = null;
                lbFoodSchedule.Items.Clear();
                lbFoodItems.SelectedItems.Clear();
            }
            else
            {
                lstCategoryType.SelectedItem = animal.Category;
                lstAnimalObject.SelectedItem = animal.GetType().Name;
                txtName.Text = animal.Name;
                txtAge.Text = animal.Age.ToString();
                SetGender();
                cboEaterType.SelectedItem = animal.EaterType;
                txtDescription.Text = animal.Description;
                SetAnimalAttributesControls();
                SetFoodItemsSelection();
            }
        }
        /// <summary>
        /// Helper function to set controls from animal
        /// </summary>
        private void SetAnimalAttributesControls()
        {
            switch (animal)
            {
                case Dog:
                    txtNumberOTeeth.Text = ((Mammal)animal).NumberOfTeeth.ToString();
                    txtDogBreed.Text = ((Dog)animal).Breed;
                    break;
                case Cat:
                    txtNumberOTeeth.Text = ((Mammal)animal).NumberOfTeeth.ToString();
                    chkIndoor.IsChecked = ((Cat)animal).Indoor;
                    break;
                case Horse:
                    txtNumberOTeeth.Text = ((Mammal)animal).NumberOfTeeth.ToString();
                    txtBoxNumber.Text = ((Horse)animal).StableBoxNumber;
                    break;
                case Elephant:
                    txtNumberOTeeth.Text = ((Mammal)animal).NumberOfTeeth.ToString();
                    txtLocation.Text = ((Elephant)animal).Location;
                    break;
                case Bee:
                    txtNumberOfWings.Text = ((Insect)animal).NumberOfWings.ToString();
                    txtHiveNumber.Text = ((Bee)animal).BeeHiveNumber;
                    break;
                case Butterfly:
                    txtNumberOfWings.Text = ((Insect)animal).NumberOfWings.ToString();
                    txtButterflyColor.Text = ((Butterfly)animal).MainColor;
                    break;
                case Crocodile:
                    txtReptileLength.Text = ((Reptile)animal).Length.ToString();
                    // Parse is fine here since I have validated the data already
                    txtCrodocile.Text = ((Crocodile)animal).NumberOfFarmersEaten.ToString();
                    break;
                case Snake:
                    txtReptileLength.Text = ((Reptile)animal).Length.ToString();
                    chkVenomous.IsChecked = ((Snake)animal).Venomous;
                    break;
                case Blackbird:
                    txtAirSpeedVelocity.Text = ((Bird)animal).AirSpeedVelocity.ToString();
                    txtIUCNCategory.Text = ((Blackbird)animal).IUCNCategorization;
                    break;
                case Swallow:
                    txtAirSpeedVelocity.Text = ((Bird)animal).AirSpeedVelocity.ToString();
                    txtBirdBreed.Text = ((Swallow)animal).Breed;
                    break;
            }
        }
        /// <summary>
        /// When edit, set chosen food items
        /// </summary>
        private void SetFoodItemsSelection()
        {
            foreach (int itemId in animalManager.GetFoodSchedule(animal.Id))
            {
                for (int i = 0; i < lbFoodItems.Items.Count; i++)
                {
                    FoodItem foodItem = (FoodItem)lbFoodItems.Items.GetItemAt(i);
                    if (foodItem.Id == itemId)
                    {
                        lbFoodItems.SelectedItems.Add(foodItem);
                    }
                }
            }
        }
        /// <summary>
        /// Update list that is bound to GUI
        /// </summary>
        private void RecreateAnimalList()
        {
            ListOfAnimals = new ObservableCollection<Animal>();
            for (int i = 0; i < animalManager.Count; i++)
            {
                ListOfAnimals.Add(animalManager.GetAt(i));
            }
        }
        /// <summary>
        /// Set control for gender
        /// </summary>        
        private void SetGender()
        {
            switch (animal.Gender)
            {
                case GenderType.Female:
                    rdoFemale.IsChecked = true;
                    break;
                case GenderType.Male:
                    rdoMale.IsChecked = true;
                    break;
                default:
                    rdoUnknown.IsChecked = true;
                    break;
            }
        }
        // Helper function to add enum items to listbox
        private void AddItemsToAnimalListbox(Array items)
        {
            foreach (var item in items)
            {
                lstAnimalObject.Items.Add(item);
            }
        }
    }
}
