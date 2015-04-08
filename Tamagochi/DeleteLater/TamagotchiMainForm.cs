using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using Models.Models.Foods;

namespace DeleteLater
{
    public partial class TamagotchiMainForm : Form
    {
        private Animal pet;
        private Player player;
        private int overallConditions;
        private Shop shop = Shop.Instance();
        private Food currentFood = new Bread();

        public TamagotchiMainForm()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void CreateAnimal_Click(object sender, EventArgs e)
        {
            var gender = MaleButton.Checked ? MaleButton.Text : FemaleButton.Text;

            Gender currentGender = (Gender)(Enum.Parse(typeof(Gender), gender));

            try
            {
                if (comboBox1.SelectedItem == null || petNameTextBox.Text == "Pet Name")
                {
                    throw new CustomException("Please fill the form!");
                }
                pet = AnimalFactory.CreateAnimal(comboBox1.SelectedItem.ToString(), currentGender, petNameTextBox.Text);

                player = new Player(pet);

                shop.LoadStore(pet);
                shopList.Items.AddRange(shop.FoodsInStore.Select(x => x.GetType().Name).ToArray());
                priceList.Items.AddRange(shop.FoodsInStore.Select(x => x as IBuyable).Select(x => x.Price.ToString()).ToArray());

                petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[0]);

                SetGameplayWindow();
            }
            catch (CustomException)
            {
                MessageBox.Show("Please fill the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            gameTimer.Enabled = true;
        }

        private void ExitGame(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you really want to leave the game?", "Exit Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);

            if (msg == DialogResult.No)
            {
                gameTimer.Enabled = true;
                return;
            }
            else if (msg == DialogResult.Yes)
            {
                DialogResult saveGame = MessageBox.Show("Do you  want to Save the current progress?", "Save Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (saveGame == DialogResult.Yes)
                {
                    player.Serialize();
                }
                Environment.Exit(0);
            }
        }



        //SETTING MOUSE ENTER AND MOUSE LEAVE ON MAIN MENU BUTTONS
        private void ExitGameButton_MouseEnter(object sender, EventArgs e)
        {
            exitGameButton.BackColor = Color.Yellow;
        }

        private void ExitGameButton_MouseLeave(object sender, EventArgs e)
        {
            exitGameButton.BackColor = Color.LightSkyBlue;
        }

        private void LoadGameButton_MouseEnter(object sender, EventArgs e)
        {
            loadGameButton.BackColor = Color.Yellow;
        }

        private void LoadGameButton_MouseLeave(object sender, EventArgs e)
        {
            loadGameButton.BackColor = Color.LightSkyBlue;
        }

        private void NewGameButton_MouseEnter(object sender, EventArgs e)
        {
            newGameButton.BackColor = Color.Yellow;
        }

        private void NewGameButton_MouseLeave(object sender, EventArgs e)
        {
            newGameButton.BackColor = Color.LightSkyBlue;
        }


        //ENTERING NEW GAME MENU
        private void NewGameMenu(object sender, EventArgs e)
        {
            exitGameButton.Visible = false;
            exitGameButton.Enabled = false;
            loadGameButton.Visible = false;
            loadGameButton.Enabled = false;
            newGameButton.Visible = false;
            newGameButton.Enabled = false;
            CreateAnimal.Visible = true;
            CreateAnimal.Enabled = true;
            newPetMenu.Visible = true;
            newPetMenu.Enabled = true;
            petNameTextBox.Visible = true;
            petNameTextBox.Enabled = true;
            comboBox1.Visible = true;
            comboBox1.Enabled = true;
            MaleButton.Visible = true;
            MaleButton.Enabled = true;
            FemaleButton.Visible = true;
            FemaleButton.Enabled = true;
        }

        //STARTING NEW GAME

        private void SetGameplayWindow()
        {
            CreateAnimal.Visible = false;
            CreateAnimal.Enabled = false;
            petNameTextBox.Enabled = false;
            petNameTextBox.Visible = false;
            MaleButton.Enabled = false;
            MaleButton.Visible = false;
            FemaleButton.Enabled = false;
            FemaleButton.Visible = false;
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            newPetMenu.Enabled = false;
            newPetMenu.Visible = false;
            BackgroundImage = null;
            petPictureBox.Visible = true;
            gameTimer.Enabled = true;
            feedButton.Visible = true;
            cleanButton.Visible = true;
            if (pet is IPlayable)
            {
                playButton.Visible = true;
                playButton.Enabled = true;
                happynessStatusBar.Visible = true;
            }
            feedButton.Enabled = true;
            cleanButton.Enabled = true;
            energyStatusBar.Visible = true;
            hygieneStatusBar.Visible = true;

            pointsAndCoins.Visible = true;
            shopList.Visible = true;
            foodList.Visible = true;
            priceList.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            FillFoodList();
        }


        private void FeedClick(object sender, EventArgs e)
        {//FEED BUTTON   
            UpdateCurrentFood();
            FillFoodList();
            pet.CurrentCondition.ChangeFeed(currentFood.FoodValue);
            energyStatusBar.Value = pet.CurrentCondition.Feed;
            petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[1]);
            player.AddPoints(5);
        }

        private void FillFoodList()
        {
            foodList.Items.Clear();
            if (currentFood.GetType().Name != "Bread")
            {
                player.RemoveFood(currentFood.GetType().Name);
            }
            foodList.Items.AddRange((string[])player.AvailableFood.Select(x => x.GetType().Name).ToArray());
        }

        private void CleanClick(object sender, EventArgs e)
        {//CLEAN BUTTON
            pet.CurrentCondition.ChangeCleanliness(5);
            hygieneStatusBar.Value = pet.CurrentCondition.Cleanliness;
            player.AddPoints(5);
        }

        private void PlayClick(object sender, EventArgs e)
        {//PLAY BUTTON
            pet.CurrentCondition.ChangeHappiness(5);
            happynessStatusBar.Value = pet.CurrentCondition.Happiness;
            player.AddPoints(5);
            //ChangeProgressBar(progressBar3, 5);
            petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[3]);
        }

        private void GameTimerTickEvents(object sender, EventArgs e)
        {
            if (!(pet is IPlayable))
            {
                pet.CurrentCondition.ChangeHappiness(60);
            }
            overallConditions = (pet.CurrentCondition.Feed + pet.CurrentCondition.Cleanliness +
                                    pet.CurrentCondition.Happiness) / 30;

            if (overallConditions > 5)
            {
                player.ChangeCoins(overallConditions);
                player.AddPoints(5);
            }

            actualPointsLabel.Text = player.Points.ToString();
            actualCoinsLabel.Text = player.Coins.ToString();

            pet.CurrentCondition.ChangeAll(-5);

            if (pet is ISoundable &&
                (pet.CurrentCondition.Feed < 20
                || pet.CurrentCondition.Cleanliness < 20
                || pet.CurrentCondition.Happiness < 20))
            {
                (pet as ISoundable).MakeSound();
            }

            energyStatusBar.Value = pet.CurrentCondition.Feed;
            hygieneStatusBar.Value = pet.CurrentCondition.Cleanliness;
            if (pet is IPlayable)
            {
                happynessStatusBar.Value = pet.CurrentCondition.Happiness;
            }

            //TODO: add sleep

            ChangeProgressBarColor(energyStatusBar);
            ChangeProgressBarColor(hygieneStatusBar);
            if (pet is IPlayable)
            {
                ChangeProgressBarColor(happynessStatusBar);
            }

            if (pet.CurrentCondition.Feed > 20 && pet.CurrentCondition.Cleanliness > 20 && pet.CurrentCondition.Happiness > 20)
            {
                petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[0]);
            }
            else
            {
                petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[2]);
            }
        }

        private void ChangeProgressBarColor(ProgressBar progressBar)
        {
            //COLORS OF BARS
            if (progressBar.Value <= 20)
            {
                progressBar.ForeColor = Color.Red;
            }
            else if (progressBar.Value <= 60)
            {
                progressBar.ForeColor = Color.DarkOrange;
            }
            else
            {
                progressBar.ForeColor = Color.Green;
            }
        }

        private void LoadGame(object sender, EventArgs e)
        {
            player = Player.Deserialize(@"../../savedgame.xml");
            pet = player.Pet;

            shop.LoadStore(pet);
            shopList.Items.AddRange(shop.FoodsInStore.Select(x => x.GetType().Name).ToArray());
            priceList.Items.AddRange(shop.FoodsInStore.Select(x => x as IBuyable).Select(x => x.Price.ToString()).ToArray());

            exitGameButton.Visible = false;
            exitGameButton.Enabled = false;
            loadGameButton.Visible = false;
            loadGameButton.Enabled = false;
            newGameButton.Visible = false;
            newGameButton.Enabled = false;
            BackgroundImage = null;
            petPictureBox.Visible = true;
            gameTimer.Enabled = true;
            feedButton.Visible = true;
            cleanButton.Visible = true;
            if (pet is IPlayable)
            {
                playButton.Visible = true;
                playButton.Enabled = true;
                happynessStatusBar.Visible = true;
            }
            feedButton.Enabled = true;
            cleanButton.Enabled = true;
            energyStatusBar.Visible = true;
            hygieneStatusBar.Visible = true;

            pointsAndCoins.Visible = true;
            shopList.Visible = true;
            foodList.Visible = true;
            priceList.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            FillFoodList();

        }

        private void shopList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            shop.BuyItem(shopList.Text, player);
            FillFoodList();
        }

        private void foodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foodList.Text != "Bread")
            {
                currentFood = FoodFactory.CreateFood(foodList.Text) as Food;
            }
        }

        private void UpdateCurrentFood()
        {
            if (string.IsNullOrEmpty(foodList.Text))
            {
                this.currentFood = FoodFactory.CreateFood("Bread");
            }
            else
            {
                this.currentFood = FoodFactory.CreateFood(foodList.Text) as Food;
            }
        }

        private void TamagotchiMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Enabled = false;
            ExitGame(sender, e);
            e.Cancel = true;
        }

    }
}
