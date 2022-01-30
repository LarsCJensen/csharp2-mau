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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment1.Classes.Mammal;
using Assignment1.Enums;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MammalFactory myMammalFactory = new MammalFactory();
        //private InsectFactory insectFactory = new InsectFactory();
        private Animal animal = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();           
        }

        private void InitializeGUI()
        {
            // Fill Category Type
            btnAdd.IsEnabled = false;
            lstCategoryType.ItemsSource = Enum.GetValues(typeof(AnimalCategoryEnum));
        }

        private void lstCategoryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get animals of selected type
            // Either calling some MammalFactory.GetMammalObjects() after a switch or same below
            Array items = null;
            switch (lstCategoryType.SelectedItem)
            {
                case AnimalCategoryEnum.Mammal:
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    items = myMammalFactory.GetAnimalObjects();
                    break;
            }
            lstAnimalObject.ItemsSource = items;            
        }
        // Functiont for Add button click
        private void btnAdd_Click(object sender, RoutedEventArgs e)        {
            
            // Check if all fields are used
            if(ValidateInput(lstCategoryType.SelectedItem, lstAnimalObject.SelectedItem))
            {
                // TODO Is below correct spot to do it? Test without
                // Reset animal
                AddAnimal();
                // TODO Display result of anímal
                DisplayAnimal();
            }            
        }

        private void AddAnimal()
        {
            switch (lstCategoryType.SelectedItem)
            {
                case AnimalCategoryEnum.Mammal:
                    MammalTypes mammalType = (MammalTypes)Enum.Parse(typeof(MammalTypes), lstAnimalObject.SelectedItem.ToString());
                    try
                    {
                        GenderType gender = getGender();
                        // Here I can use just parse since the value has been validated before                        
                        animal = myMammalFactory.CreateAnimal(mammalType, txtName.Text, int.Parse(txtAge.Text), gender, txtDescription.Text, int.Parse(txtNumberOTeeth.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        // If not, catch the exception and show the message box.
                        MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    break;
            }
            switch (animal)
            {
                case Cat:
                    // Set cat specific values
                    break;
            }
        }
        private GenderType getGender()
        {
            var test = GenderGrid.Children.OfType<RadioButton>().FirstOrDefault(x => (bool)x.IsChecked);
            return GenderType.Male;
        }
        // Function to display attributes of recently added animal
        private void DisplayAnimal()
        {
            // Add all attributes to list
        }
        // Helper function to validate input.        
        private bool ValidateInput(object animalCategory, object animal)
        {
            // Validate common attributes
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must provide a name for the animal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            // I don't need the number, just want to know if it is valid
            bool validInt = int.TryParse(txtAge.Text, out _);
            if (string.IsNullOrEmpty(txtAge.Text) || !validInt)
            {
                MessageBox.Show("You must provide an valid age for the animal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("You must provide a description for the animal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
            // Check if no radiobuttons are checked
            if (!GenderGrid.Children.OfType<RadioButton>().Any(x => (bool)x.IsChecked))
            {
                MessageBox.Show("You must choose a gender for your animal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            switch(animalCategory)
            {
                case AnimalCategoryEnum.Mammal:
                    if (string.IsNullOrEmpty(txtNumberOTeeth.Text))
                    {
                        MessageBox.Show("You must provide the number of teeth for the animal of type mammal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch(animal)
                    {
                        case MammalTypes.Dog:
                            if (string.IsNullOrEmpty(txtBreed.Text))
                            {
                                MessageBox.Show("You must provide the breed for dogs!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                        case MammalTypes.Cat:
                            //Since it is a checkbox, no need to validate
                            break;
                        case MammalTypes.Horse:
                            if (string.IsNullOrEmpty(txtBoxNumber.Text))
                            {
                                MessageBox.Show("You must provide the box number for horses!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                        case MammalTypes.Elephant:
                            if (string.IsNullOrEmpty(txtLocation.Text))
                            {
                                MessageBox.Show("You must provide the location for elephants!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                    }
                    break;
                case AnimalCategoryEnum.Bird:
                    if (string.IsNullOrEmpty(txtAirSpeedVelocity.Text))
                    {
                        MessageBox.Show("You must provide the air-speed velocity for the animal of type bird!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch (animal)
                    {
                        case BirdTypes.Swallow:
                            if (string.IsNullOrEmpty(txtBirdBreed.Text))
                            {
                                MessageBox.Show("You must provide the breed for swallows!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                        case BirdTypes.Blackbird:
                            if (string.IsNullOrEmpty(txtIUCNCategory.Text))
                            {
                                MessageBox.Show("You must provide the IUCN Categorization for blackbirds!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                    }
                    break;
                case AnimalCategoryEnum.Insect:
                    if (string.IsNullOrEmpty(txtNumberOfWings.Text))
                    {
                        MessageBox.Show("You must provide the number of wings for the animal of type insect!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch (animal)
                    {
                        case InsectTypes.Butterfly:
                            if (string.IsNullOrEmpty(txtButterflyColor.Text))
                            {
                                MessageBox.Show("You must provide the main color for butterflies!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                        case InsectTypes.Bee:
                            if (string.IsNullOrEmpty(txtHiveNumber.Text))
                            {
                                MessageBox.Show("You must provide the hive number for bee's!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                    }
                    break;
                case AnimalCategoryEnum.Reptile:
                    if (string.IsNullOrEmpty(txtReptileLength.Text))
                    {
                        MessageBox.Show("You must provide the length for the animal of type reptile!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch (animal)
                    {
                        case ReptileTypes.Crocodile:
                            if (string.IsNullOrEmpty(txtCrodocile.Text))
                            {
                                MessageBox.Show("You must provide the number of killed farmers for crocodiles!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            break;
                        case ReptileTypes.Snake:
                            // Since it is a checkbox it does not need to be validated
                            break;
                    }
                    break;
            }        
            return true;

        }

        private void lstAnimalObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lstAnimalObject.SelectedItem)
            {
                case MammalTypes.Dog:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/dog.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Cat:
                    stackCat.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/cat.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Horse:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/horse.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Elephant:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/elephant.jpg", UriKind.Absolute));
                    break;
                case BirdTypes.Swallow:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/swallow.jpg", UriKind.Absolute));
                    break;
                case BirdTypes.Blackbird:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/blackbird.jpg", UriKind.Absolute));
                    break;
                case InsectTypes.Butterfly:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/butterfly.jpg", UriKind.Absolute));
                    break;
                case InsectTypes.Bee:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/bee.jpg", UriKind.Absolute));
                    break;
                case ReptileTypes.Crocodile:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/dog.jpg", UriKind.Absolute));
                    break;
                case ReptileTypes.Snake:
                    stackDog.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/dog.jpg", UriKind.Absolute));
                    break;
            }
            // Switch case to show correct images
            btnAdd.IsEnabled = true;
            // Show animal image
            
        }

        private void chkListAllAnimals_Checked(object sender, RoutedEventArgs e)
        {
            // List all animals through Animal.List_AllAnimals?


            // Gray categories
            //Unchecked = everything back to normal
        }


    }
}
