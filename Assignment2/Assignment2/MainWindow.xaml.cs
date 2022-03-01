/**
 * Lars Jensen 2022-02-27
 */

using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assignment2.Animals;
using Assignment2.Birds;
using Assignment2.Insects;
using Assignment2.Mammals;
using Assignment2.Reptiles;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Make this public to be able to bind from frontend
        //public AnimalManager animalManager = new AnimalManager();
        private AnimalManager animalManager = new AnimalManager();
        private MammalFactory myMammalFactory = new MammalFactory();
        private BirdFactory myBirdFactory = new BirdFactory();
        private ReptileFactory myReptileFactory = new ReptileFactory();
        private InsectFactory myInsectFactory = new InsectFactory();
        private Animal animal = null;
        private string sortColumn;
        private bool sortDescending = false;


        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Animal> listOfAnimals = new ObservableCollection<Animal>();
        public ObservableCollection<Animal> ListOfAnimals { 
            get {
                return listOfAnimals;
            } set {
                listOfAnimals = value;
                NotifyPropertyChanged();
            } 
        }
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            // To make it possible to bind ListOf
            DataContext = this;
            InitializeGUI();
        }

        // Function to initialize GUI
        private void InitializeGUI()
        {
            btnAdd.IsEnabled = false;
            // Fill Category Type
            lstCategoryType.ItemsSource = Enum.GetValues(typeof(AnimalCategoryEnum));
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
            // This should be done in a loop over all children of mainGrid, but chose this quick and dirty way
            txtName.Text = String.Empty;
            txtAge.Text = String.Empty;
            rdoUnknown.IsChecked = true;
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
        }


        // Function for category change event
        private void lstCategoryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get animals of selected type if not List all animals is checked
            if(chkListAllAnimals.IsChecked == true)
            {
                return;
            }
            Array items = null;
            switch (lstCategoryType.SelectedItem)
            {
                case AnimalCategoryEnum.Mammals:
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    items = myMammalFactory.GetAnimalObjects();
                    break;
                case AnimalCategoryEnum.Birds:
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Visible;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    items = myBirdFactory.GetAnimalObjects();
                    break;
                case AnimalCategoryEnum.Insects:
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Visible;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    items = myInsectFactory.GetAnimalObjects();
                    break;
                case AnimalCategoryEnum.Reptiles:
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Visible;
                    items = myReptileFactory.GetAnimalObjects();
                    break;
            }
            lstAnimalObject.ItemsSource = items;
        }
        // Function for Add button click
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields are used
            if (ValidateInput(lstCategoryType.SelectedItem, lstAnimalObject.SelectedItem))
            {
                if (AddAnimal())
                {
                    listOfAnimals.Add(animal);
                    InitializeGUI();
                    animal = null;
                }
            }
        }

        // Helper function to add animal
        private bool AddAnimal()
        {
            switch (lstCategoryType.SelectedItem)
            {
                case AnimalCategoryEnum.Mammals:
                    MammalTypes mammalType = (MammalTypes)Enum.Parse(typeof(MammalTypes), lstAnimalObject.SelectedItem.ToString());
                    try
                    {
                        GenderType gender = GetGender();
                        // Here I can use just parse since the value has been validated before                        
                        animal = myMammalFactory.CreateAnimal(mammalType, txtName.Text, int.Parse(txtAge.Text), gender, AnimalCategoryEnum.Mammals, txtDescription.Text, int.Parse(txtNumberOTeeth.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        // If not, catch the exception and show the message box.
                        MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    break;
                case AnimalCategoryEnum.Birds:
                    BirdTypes birdType = (BirdTypes)Enum.Parse(typeof(BirdTypes), lstAnimalObject.SelectedItem.ToString());
                    try
                    {
                        GenderType gender = GetGender();
                        // Here I can use just parse since the value has been validated before                        
                        animal = myBirdFactory.CreateAnimal(birdType, txtName.Text, int.Parse(txtAge.Text), gender, AnimalCategoryEnum.Birds, txtDescription.Text, int.Parse(txtAirSpeedVelocity.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        // If not, catch the exception and show the message box.
                        MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    break;
                case AnimalCategoryEnum.Insects:
                    InsectTypes insectType = (InsectTypes)Enum.Parse(typeof(InsectTypes), lstAnimalObject.SelectedItem.ToString());
                    try
                    {
                        GenderType gender = GetGender();
                        // Here I can use just parse since the value has been validated before                        
                        animal = myInsectFactory.CreateAnimal(insectType, txtName.Text, int.Parse(txtAge.Text), gender, AnimalCategoryEnum.Insects, txtDescription.Text, int.Parse(txtNumberOfWings.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        // If not, catch the exception and show the message box.
                        MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                    break;
                case AnimalCategoryEnum.Reptiles:
                    ReptileTypes reptileType = (ReptileTypes)Enum.Parse(typeof(ReptileTypes), lstAnimalObject.SelectedItem.ToString());
                    try
                    {
                        GenderType gender = GetGender();
                        // Here I can use just parse since the value has been validated before                        
                        animal = myReptileFactory.CreateAnimal(reptileType, txtName.Text, int.Parse(txtAge.Text), gender, AnimalCategoryEnum.Reptiles, txtDescription.Text, int.Parse(txtReptileLength.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        // If not, catch the exception and show the message box.
                        MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    break;
            }
            // Switch to set animal specific attributes
            switch (animal)
            {
                case Dog:
                    ((Dog)animal).Breed = txtDogBreed.Text;
                    break;
                case Cat:
                    ((Cat)animal).Indoor = chkIndoor.IsChecked.Value;
                    break;
                case Horse:
                    ((Horse)animal).StableBoxNumber = txtBoxNumber.Text;
                    break;
                case Elephant:
                    ((Elephant)animal).Location = txtLocation.Text;
                    break;
                case Bee:
                    ((Bee)animal).BeeHiveNumber = txtHiveNumber.Text;
                    break;
                case Butterfly:
                    ((Butterfly)animal).MainColor = txtButterflyColor.Text;
                    break;
                case Crocodile:
                    // Parse is fine here since I have validated the data already
                    ((Crocodile)animal).NumberOfFarmersEaten = int.Parse(txtCrodocile.Text);
                    break;
                case Snake:
                    ((Snake)animal).Venomous = chkVenomous.IsChecked.Value;
                    break;
                case Blackbird:
                    ((Blackbird)animal).IUCNCategorization = txtIUCNCategory.Text;
                    break;
                case Swallow:
                    ((Swallow)animal).Breed = txtBirdBreed.Text;
                    break;
            }
            return animalManager.Add(animal);
        }
        // Helper function for get Gender
        private GenderType GetGender()
        {
            var selectedRdo = GenderGrid.Children.OfType<RadioButton>().FirstOrDefault(x => (bool)x.IsChecked);
            switch (selectedRdo.Name)
            {
                case "rdoMale":
                    return GenderType.Male;
                case "rdoFemale":
                    return GenderType.Female;
                default:
                    return GenderType.Unknown;
            }


        }
        // Function to display attributes of recently added animal
        // Perhaps not a better solution than to have a ToString overload in each class but a solution I wanted to try
        private void DisplayAnimalInfo(int index)
        {
            Animal selectedAnimal = animalManager.GetAnimalAt(index);

            lblAnimalInfo.Content = selectedAnimal.GetExtraInfo();
            FoodSchedule foodSchedule = selectedAnimal.GetFoodSchedule();
            lblEaterType.Content = foodSchedule.EaterType;
            lbFoodSchedule.ItemsSource = foodSchedule.GetFoodListInfoStrings();
        }
        // Helper function to validate input. Not sure if having it in the view is best, but it is easier to have it here so we can provide user with good message        
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

            switch (animalCategory)
            {
                case AnimalCategoryEnum.Mammals:
                    if (string.IsNullOrEmpty(txtNumberOTeeth.Text))
                    {
                        MessageBox.Show("You must provide the number of teeth for the animal of type mammal!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch (animal)
                    {
                        case MammalTypes.Dog:
                            if (string.IsNullOrEmpty(txtDogBreed.Text))
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
                case AnimalCategoryEnum.Birds:
                    validInt = int.TryParse(txtAirSpeedVelocity.Text, out _);
                    if (string.IsNullOrEmpty(txtAirSpeedVelocity.Text) || !validInt)
                    {
                        MessageBox.Show("You must provide a proper value for air-speed velocity for the animal of type bird!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                case AnimalCategoryEnum.Insects:
                    validInt = int.TryParse(txtNumberOfWings.Text, out _);
                    if (string.IsNullOrEmpty(txtNumberOfWings.Text) || !validInt)
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
                case AnimalCategoryEnum.Reptiles:
                    validInt = int.TryParse(txtReptileLength.Text, out _);
                    if (string.IsNullOrEmpty(txtReptileLength.Text) || !validInt)
                    {
                        MessageBox.Show("You must provide the length for the animal of type reptile!", "Invalid input!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    switch (animal)
                    {
                        case ReptileTypes.Crocodile:
                            validInt = int.TryParse(txtCrodocile.Text, out _);
                            if (string.IsNullOrEmpty(txtCrodocile.Text) || !validInt)
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

        // Function to handle animal selection change.
        private void lstAnimalObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lstAnimalObject.SelectedItem)
            {
                case MammalTypes.Dog:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Mammals;
                    // I probably should move this to a helper function that loops through the stack panels in the containing grid
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackDog.Visibility = Visibility.Visible;
                    stackCat.Visibility = Visibility.Collapsed;
                    stackHorse.Visibility = Visibility.Collapsed;
                    stackElephant.Visibility = Visibility.Collapsed;
                    // Set default image per animal
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/dog.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Cat:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Mammals;
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackDog.Visibility = Visibility.Collapsed;
                    stackCat.Visibility = Visibility.Visible;
                    stackHorse.Visibility = Visibility.Collapsed;
                    stackElephant.Visibility = Visibility.Collapsed;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/cat.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Horse:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Mammals;
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackDog.Visibility = Visibility.Collapsed;
                    stackCat.Visibility = Visibility.Collapsed;
                    stackHorse.Visibility = Visibility.Visible;
                    stackElephant.Visibility = Visibility.Collapsed;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/horse.jpg", UriKind.Absolute));
                    break;
                case MammalTypes.Elephant:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Mammals;
                    grpMammalCategorySpec.Visibility = Visibility.Visible;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackDog.Visibility = Visibility.Collapsed;
                    stackCat.Visibility = Visibility.Collapsed;
                    stackHorse.Visibility = Visibility.Collapsed;
                    stackElephant.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/elephant.jpg", UriKind.Absolute));
                    break;
                case BirdTypes.Swallow:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Birds;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Visible;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackSwallow.Visibility = Visibility.Visible;
                    stackBlackbird.Visibility = Visibility.Collapsed;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/swallow.jpg", UriKind.Absolute));
                    break;
                case BirdTypes.Blackbird:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Birds;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Visible;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackSwallow.Visibility = Visibility.Collapsed;
                    stackBlackbird.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/blackbird.jpg", UriKind.Absolute));
                    break;
                case InsectTypes.Butterfly:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Insects;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Visible;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackButterfly.Visibility = Visibility.Visible;
                    stackBee.Visibility = Visibility.Collapsed;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/butterfly.jpg", UriKind.Absolute));
                    break;
                case InsectTypes.Bee:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Insects;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Visible;
                    grpReptileCategorySpec.Visibility = Visibility.Collapsed;
                    stackButterfly.Visibility = Visibility.Collapsed;
                    stackBee.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/bee.jpg", UriKind.Absolute));
                    break;
                case ReptileTypes.Crocodile:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Reptiles;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Visible;
                    stackCrocodile.Visibility = Visibility.Visible;
                    stackSnake.Visibility = Visibility.Collapsed;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/crocodile.jpg", UriKind.Absolute));
                    break;
                case ReptileTypes.Snake:
                    lstCategoryType.SelectedItem = AnimalCategoryEnum.Reptiles;
                    grpMammalCategorySpec.Visibility = Visibility.Collapsed;
                    grpBirdCategorySpec.Visibility = Visibility.Collapsed;
                    grpInsectCategorySpec.Visibility = Visibility.Collapsed;
                    grpReptileCategorySpec.Visibility = Visibility.Visible;
                    stackCrocodile.Visibility = Visibility.Collapsed;
                    stackSnake.Visibility = Visibility.Visible;
                    imgAnimal.Source = new BitmapImage(new Uri(@"pack://application:,,,/assets/snake.jpg", UriKind.Absolute));
                    break;
            }
            btnAdd.IsEnabled = true;
        }
        // Function which listens to click events. 
        private void ChkListAllAnimals_Click(object sender, RoutedEventArgs e)
        {
            lstAnimalObject.ItemsSource = null;
            lstAnimalObject.Items.Clear();
            // Checks if the click checked or un-checked the box.
            if ((bool)(sender as CheckBox).IsChecked)
            {
                lstCategoryType.IsEnabled = false;
                imgAnimal.Source = null;
                AddItemsToAnimalListbox(myMammalFactory.GetAnimalObjects());
                AddItemsToAnimalListbox(myBirdFactory.GetAnimalObjects());
                AddItemsToAnimalListbox(myInsectFactory.GetAnimalObjects());
                AddItemsToAnimalListbox(myReptileFactory.GetAnimalObjects());
            }
            else
            {
                lstCategoryType.SelectedItem = null;
                btnAdd.IsEnabled = true;
                lstCategoryType.IsEnabled = true;
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

        // Function to choose an image for your animal
        private void btnBrowseImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "BMP|*.bmp|JPG|*.jpg|PNG|*.png|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                imgAnimal.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
            }
        }
        
        // Function to clear all controls of input
        // Not used
        private void ClearControls()
        {
            foreach (Control ctl in mainGrid.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
                if (ctl.GetType() == typeof(RadioButton))
                    ((RadioButton)ctl).IsChecked = false;
            }
        }
        /// <summary>
        /// Function which are called upon selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvAnimalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvAnimalList.SelectedIndex;
            DisplayAnimalInfo(index);
        }
        /// <summary>
        /// Method for sorting upon click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvAnimalList_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            // If sorting is done on the same column, sort by descending                        
            if (sortDescending && sortColumn == column.Tag.ToString())
            {
                sortDescending = false;
            } else if (!sortDescending && sortColumn == column.Tag.ToString()) 
            {
                sortDescending = true;
            }
            else
            {
                sortDescending = false;
            }
            sortColumn = column.Tag.ToString();

            // Sort list of animals
            //animalManager.SortAnimalList(sortColumn, sortDescending);
            switch (sortColumn)
            {
                case "Age":
                    // Sort by age
                    animalManager.SortAnimalList(new SorterAge(), sortDescending);
                    break;
                case "ID":
                    // Sort by id
                    animalManager.SortAnimalList(new SorterId(), sortDescending);
                    break;
                case "Gender":
                    animalManager.SortAnimalList(new SorterGender(), sortDescending);
                    break;
                default:
                    
                    animalManager.SortAnimalList(new SorterName(), sortDescending);
                    break;
            }
            
            // Recreate ListOfAnimals from the newly sorted list
            ListOfAnimals = new ObservableCollection<Animal>();
            for (int i = 0; i < animalManager.Count(); i++)
            {
                ListOfAnimals.Add(animalManager.GetAnimalAt(i));
            }
        }
        /// <summary>
        /// Just a helper method to create animal objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAnimalsForTest_Click(object sender, RoutedEventArgs e)
        {            
            for (int i = 0; i < 3; i++)
            {
                AnimalCategoryEnum animalCat;
                Animal animal = null;
                if (i==0)
                {
                    MammalFactory mammalFactory = new MammalFactory();
                    animalCat = (AnimalCategoryEnum)i;
                    MammalTypes mammalType = MammalTypes.Dog;
                    // TODO TA bort
                    //string id = animalManager.GetNewId(animalCat);
                    GenderType gender = (GenderType)i;
                    animal = mammalFactory.CreateAnimal(mammalType, "Name" + i.ToString(), 14, gender, animalCat, "Description " + i.ToString(), 24);
                    ((Dog)animal).Breed = "Samojed";
                    animalManager.Add(animal);
                }
                if(i == 1)
                {
                    InsectFactory insectFactory = new InsectFactory();
                    animalCat = (AnimalCategoryEnum)i;
                    InsectTypes insectType = InsectTypes.Butterfly;
                    // TODO TA bort
                    //string id = animalManager.GetNewId(animalCat);
                    GenderType gender = (GenderType)i;
                    animal = insectFactory.CreateAnimal(insectType, "Name" + i.ToString(), 4, gender, animalCat, "Description " + i.ToString(), 2);
                    ((Butterfly)animal).MainColor = "Blue";
                    animalManager.Add(animal);
                }
                if (i == 2)
                {
                    ReptileFactory reptileFactory = new ReptileFactory();
                    animalCat = (AnimalCategoryEnum)i;
                    ReptileTypes reptileType = ReptileTypes.Crocodile;
                    // TODO TA bort
                    //string id = animalManager.GetNewId(animalCat);
                    GenderType gender = (GenderType)i;
                    animal = reptileFactory.CreateAnimal(reptileType, "Name" + i.ToString(), 10, gender, animalCat, "Description " + i.ToString(), 120);
                    ((Crocodile)animal).NumberOfFarmersEaten = 12;
                    animalManager.Add(animal);
                }
            }
            ListOfAnimals = new ObservableCollection<Animal>();
            for(int i = 0; i < animalManager.Count(); i++)
            {
                ListOfAnimals.Add(animalManager.GetAnimalAt(i));
            }
        }
    }
}
