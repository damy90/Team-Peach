using System.Linq;
using Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeleteLater
{
    public partial class TamagotchiMainForm : Form
    {
        private Animal pet;
        private Player player;

        public TamagotchiMainForm()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void CreateAnimal_Click(object sender, EventArgs e)
        {
            var gender =  MaleButton.Checked ? MaleButton.Text :FemaleButton.Text;

            Gender currentGender = (Gender)(Enum.Parse(typeof(Gender), gender));
            
            if ( petNameTextBox.Text != "" && comboBox1.SelectedItem != null)
            {
                pet = AnimalFactory.CreateAnimal(comboBox1.SelectedItem.ToString(), currentGender, petNameTextBox.Text); 

                player = new Player(pet);

                SetGameplayWindow();
            }
            
            gameTimer.Enabled = true;
        }

        private void ExitGame(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you really want to leave the game?", "Exit Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (msg == DialogResult.Yes)
            {
                DialogResult saveGame = MessageBox.Show("Do you  want to Save the current progress?", "Save Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (saveGame == DialogResult.Yes)
                {
                    // USE SAVE GAME METHOD
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
            playButton.Visible = true;
            feedButton.Enabled = true;
            cleanButton.Enabled = true;
            playButton.Enabled = true;
            energyStatusBar.Visible = true;
            hygieneStatusBar.Visible = true;
            happynessStatusBar.Visible = true;
            chooseFoodDropComboBox.Enabled = true;
            chooseFoodDropComboBox.Visible = true;
            FillFoodList();
        }


        private void FeedClick(object sender, EventArgs e)
        {//FEED BUTTON
            ChooseFood();
            if (chooseFoodDropComboBox.SelectedItem != null)
            {
                pet.CurrentCondition.ChangeFeed(5);
            }
            energyStatusBar.Value = pet.CurrentCondition.Feed;
            pet.CurrentCondition.ChangeFeed(5);
            petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[1]);
        }

        private void ChooseFood()
        {
            //if (chooseFoodDropComboBox.SelectedItem == null)
            //{
            //    MessageBox.Show("Choose Food");
            //}

            chooseFoodDropComboBox.SelectedItem = chooseFoodDropComboBox.Items[0];

            string selectedFood = chooseFoodDropComboBox.SelectedItem.ToString();

            if (chooseFoodDropComboBox.SelectedItem != null)
            {
                selectedFood = chooseFoodDropComboBox.SelectedItem.ToString();
            }
            

            if (selectedFood != "Pizza")
            {
                player.RemoveFood(selectedFood);
            }

            FillFoodList();
        }

        private void FillFoodList()
        {
            chooseFoodDropComboBox.Items.Clear();
            chooseFoodDropComboBox.Items.AddRange(player.AvailableFood.Select(x => x.GetType().Name).ToArray());
        }

        private void CleanClick(object sender, EventArgs e)
        {//CLEAN BUTTON
            pet.CurrentCondition.ChangeCleanliness(5);
            hygieneStatusBar.Value = pet.CurrentCondition.Cleanliness;
            //ChangeProgressBar(progressBar2, 5);
        }

        private void PlayClick(object sender, EventArgs e)
        {//PLAY BUTTON
            pet.CurrentCondition.ChangeHappiness(5);
            happynessStatusBar.Value = pet.CurrentCondition.Happiness;
            //ChangeProgressBar(progressBar3, 5);
            petPictureBox.BackgroundImage = Image.FromFile(pet.Pictures[3]);
        }

        private void GameTimerTickEvents(object sender, EventArgs e)
        {
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
            happynessStatusBar.Value = pet.CurrentCondition.Happiness;

            //TODO: add sleep

            ChangeProgressBarColor(energyStatusBar);
            ChangeProgressBarColor(hygieneStatusBar);
            ChangeProgressBarColor(happynessStatusBar);

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
            // TODO
        }

        
    }
}
