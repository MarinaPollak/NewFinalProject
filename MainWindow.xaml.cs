using NewFinalProject.Classes;
using System.Media;
using System.Timers;  //tutor Thomas Maggraff https://github.com/gurrenm3
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

/* 
[CityBuilder] 
[C# WPF Game] 
[Marina Pollak]
[05/09/2022] 
tutor Thomas Maggraff https://github.com/gurrenm3
*/



namespace NewFinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public City city; //declare  a class City
        public Player player; //declare a class Player
        public Building currentBuilding; // declare the current building the player selected.
        private int currentBuildingType; //declaring for index of a buildingtypes
        public Timer giveMoneyTimer;

        public MainWindow()
        {
            InitializeComponent();
            purchaseBuildingsGrid.Visibility = Visibility.Collapsed;

            city = new City(); //instantiate
            player = new Player(); //instantiate
            UpdateCash();
            UpdateScore();
            SetCurrentBuildingType(0); //Set current building type to 0
            // on this line

            ///tutor Thomas Maggraff https://github.com/gurrenm3
            giveMoneyTimer = new Timer(6_000);
            giveMoneyTimer.Elapsed += GiveMoneyTimer_Elapsed;
            giveMoneyTimer.Start();
        }

        public void GreetingWindowUpdate()
        {

            if (player.score.currentAmount >= 500 && player.score.currentAmount <= 600)
            {
                purchaseBuildingsGrid.Visibility = Visibility.Collapsed;
                GreetText.Visibility = Visibility.Visible;
                GreetText.Text = $"Congartulations! Your score is went up too {player.score.currentAmount}!";
            }
            else if (player.score.currentAmount >= 600 && player.score.currentAmount <= 1000)
            {
                purchaseBuildingsGrid.Visibility = Visibility.Visible;
                GreetText.Visibility = Visibility.Collapsed;
            }
            else if (player.score.currentAmount >= 1000 && player.score.currentAmount <= 1100)
            {
                purchaseBuildingsGrid.Visibility = Visibility.Collapsed;
                GreetText.Visibility = Visibility.Visible;
                GreetText.Text = $"You make a good progress! Your score is went up too {player.score.currentAmount}!";
            }
            else if (player.score.currentAmount >= 2000 && player.score.currentAmount <= 2100)
            {
                purchaseBuildingsGrid.Visibility = Visibility.Collapsed;
                GreetText.Visibility = Visibility.Visible;
                GreetText.Text = $"Your city is almost build! Your score is went up too {player.score.currentAmount}!";
            }

        }


        //tutor Thomas Maggraff https://github.com/gurrenm3
        private void GiveMoneyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int cashToAdd = player.score.GetCurrentAmount() * 10;
            player.cash.Add(cashToAdd);
        }



        private void UpdateCash()
        {
            moneyTxt.Text = $"${player.cash.GetCurrentAmount()}";
        }

        private void UpdateScore()
        {
            scoreTxt.Text = $"{player.score.GetCurrentAmount()} points";
        }

        private void SetCurrentBuildingType(int index)
        {
            currentBuildingType = index;
            if (currentBuildingType < 0)
            {
                currentBuildingType = city.buildingTypes.Count - 1;
            }
            if (currentBuildingType >= city.buildingTypes.Count)
            {
                currentBuildingType = 0;
            }

            buildingTypeTxt.Text = city.buildingTypes[currentBuildingType];

            buildMenuLstBx.Items.Clear();
            if (currentBuildingType == 0)
            {
                foreach (var item in city.transportationTypes)
                {
                    buildMenuLstBx.Items.Add(item);
                }
            }
            else if (currentBuildingType == 1)
            {
                foreach (var item in city.restaurantTypes)
                {
                    buildMenuLstBx.Items.Add(item);
                }
            }
            else if (currentBuildingType == 2)
            {
                foreach (var item in city.entertainmentTypes)
                {
                    buildMenuLstBx.Items.Add(item);
                }
            }

            // show first building
            buildMenuLstBx.SelectedIndex = 0;
        }

        private void toggleBuildMenueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (purchaseBuildingsGrid.Visibility == Visibility.Visible)
            {
                purchaseBuildingsGrid.Visibility = Visibility.Collapsed;
                toggleBuildMenueBtn.Content = "Show Build Menu";
            }
            else
            {
                purchaseBuildingsGrid.Visibility = Visibility.Visible;
                toggleBuildMenueBtn.Content = "Hide Build Menu";
            }
        }

        private void previousBuildingTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            SetCurrentBuildingType(currentBuildingType - 1);
        }

        private void nextBuildingTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            SetCurrentBuildingType(currentBuildingType + 1);
        }

        //======Purchase button event========//
        private void buyBuildingBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            if (currentBuilding == null)
            {
                MessageBox.Show("You need to select a building before you can purchase it");
            }
            else if (player.cash.CanPurchase(currentBuilding.Cost))
            {
                player.PurchaseBuilding(currentBuilding);

                string buildingName = buildMenuLstBx.SelectedItem.ToString();

                Image image = new Image();
                image.Source = new BitmapImage(new System.Uri($"Pictures\\{buildingName}.png", System.UriKind.Relative));

                if (currentBuilding.BuildingType == "Transportation")
                {
                    transportationImages.Children.Add(image);
                }
                if (currentBuilding.BuildingType == "Restaurant")
                {
                    resturantImages.Children.Add(image);
                }
                if (currentBuilding.BuildingType == "Entertainment")
                {
                    entertainmentImages.Children.Add(image);
                }

                UpdateCash();
                UpdateScore();
                GreetingWindowUpdate();
            }
            else
            {
                MessageBox.Show("You cant afford this");
            }
        }



        private void buildMenuLstBx_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (buildMenuLstBx.SelectedItem != null)
            {
                string buildingName = buildMenuLstBx.SelectedItem.ToString();
                buildingImage.Source = new BitmapImage(new System.Uri($"Pictures\\{buildingName}.png", System.UriKind.Relative));

                currentBuilding = new Building(); //declare a current Building

                if (currentBuildingType == 0)
                {
                    foreach (var item in city.transportations)
                    {
                        if (item.Name == buildingName)
                        {
                            currentBuilding = item;
                        }
                    }
                }
                if (currentBuildingType == 1)
                {
                    foreach (var item in city.restaurants)
                    {
                        if (item.Name == buildingName)
                        {
                            currentBuilding = item;
                        }
                    }
                }
                if (currentBuildingType == 2)
                {
                    foreach (var item in city.entertainments)
                    {
                        if (item.Name == buildingName)
                        {
                            currentBuilding = item;
                        }
                    }
                }

                buildingCostTxt.Text = $"${currentBuilding.Cost}";
                buildingScoreTxt.Text = $"{currentBuilding.Score} points";
            }
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateCash();
        }

        private void buyBuildingBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            buyBuildingBtn.Width += 10;
            buyBuildingBtn.Margin = new Thickness(20, 0, 20, 0);
        }

        private void buyBuildingBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            buyBuildingBtn.Width -= 10;
            buyBuildingBtn.Margin = new Thickness(25, 0, 25, 0);
        }

        private void previousBuildingTypeBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            previousBuildingTypeBtn.Width += 10;
            buyBuildingBtn.Margin = new Thickness(15, 0, 25, 0);
        }

        private void previousBuildingTypeBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            previousBuildingTypeBtn.Width -= 10;
            buyBuildingBtn.Margin = new Thickness(25, 0, 25, 0);
        }

        private void nextBuildingTypeBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            nextBuildingTypeBtn.Width += 10;
            buyBuildingBtn.Margin = new Thickness(25, 0, 15, 0);
        }

        private void nextBuildingTypeBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            nextBuildingTypeBtn.Width -= 10;
            buyBuildingBtn.Margin = new Thickness(25, 0, 25, 0);
        }

        //Advanced Feature for Timer issue
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        //tutor Thomas Maggraff https://github.com/gurrenm3
        private void PlayClickSound()
        {
            SoundPlayer player = new SoundPlayer("Sound\\Click.wav");
            player.Load();
            player.Play();
        }

        private void PlayerInputSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //publish the name of the palyer into the HUD
            playerNameTxt.Text = InputBox.Text;

            //hide the setup canvas
            Canvas.Visibility = Visibility.Collapsed;
        }

        private void InputBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //pass through the input parametr from the key down event handler
            if (e.Key == Key.Return)
            {
                PlayerInputSubmitButton_Click(sender, e);
            }
        }

        private void PlayerName_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas.Visibility = Visibility.Visible;
        }
    }
}
