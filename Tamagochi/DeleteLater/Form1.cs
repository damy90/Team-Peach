using System.Collections.Generic;
using System.Linq;
using Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeleteLater
{
    public partial class Form1 : Form
    {
        private Animal pet;
        private Player player;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void CreateAnimal_Click(object sender, EventArgs e)
        {
            var gender =  MaleButton.Checked ? MaleButton.Text :FemaleButton.Text;

            Gender currentGender = (Gender)(Enum.Parse(typeof(Gender), gender));
            
            if ( textBox3.Text != "" && comboBox1.SelectedItem != null)
            {
                pet = AnimalFactory.CreateAnimal(comboBox1.SelectedItem.ToString(), currentGender, textBox3.Text); 

                player = new Player(pet);

                SetGameplayWindow();
            }

            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
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
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Yellow;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightSkyBlue;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Yellow;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightSkyBlue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Yellow;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSkyBlue;
        }


        //ENTERING NEW GAME MENU
        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button4.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            CreateAnimal.Visible = true;
            CreateAnimal.Enabled = true;         
            groupBox2.Visible = true;
            groupBox2.Enabled = true;
            textBox3.Visible = true;
            textBox3.Enabled = true;
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
            textBox3.Enabled = false;
            textBox3.Visible = false;
            MaleButton.Enabled = false;
            MaleButton.Visible = false;
            FemaleButton.Enabled = false;
            FemaleButton.Visible = false;
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            groupBox2.Enabled = false;
            groupBox2.Visible = false;
            BackgroundImage = null;
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            FillFoodList();
        }


        private void FeedClick(object sender, EventArgs e)
        {//FEED BUTTON

            ChooseFood();

            pet.CurrentCondition.ChangeFeed(5);
            progressBar1.Value = pet.CurrentCondition.Feed;
            //ChangeProgressBar(progressBar1, 5);
            pictureBox1.BackgroundImage = Image.FromFile(pet.Pictures[1]);
        }

        private void ChooseFood()
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Choose Food");
            }

            string selectedFood = "";

            if (comboBox2.SelectedItem != null)
            {
                selectedFood = comboBox2.SelectedItem.ToString();
            }
            

            if (selectedFood != "Pizza")
            {
                player.RemoveFood(selectedFood);
            }

            FillFoodList();
        }

        private void FillFoodList()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(player.AvailableFood.Select(x => x.GetType().Name).ToArray());
        }

        private void CleanClick(object sender, EventArgs e)
        {//CLEAN BUTTON
            pet.CurrentCondition.ChangeCleanliness(5);
            progressBar2.Value = pet.CurrentCondition.Cleanliness;
            //ChangeProgressBar(progressBar2, 5);
        }

        private void PlayClick(object sender, EventArgs e)
        {//PLAY BUTTON
            pet.CurrentCondition.ChangeHappiness(5);
            progressBar3.Value = pet.CurrentCondition.Happiness;
            //ChangeProgressBar(progressBar3, 5);
            pictureBox1.BackgroundImage = Image.FromFile(pet.Pictures[3]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pet != null)
            {
                pet.CurrentCondition.ChangeAll(-5);

                //TODO: add sleep
            }

            if (pet.CurrentCondition.Feed > 20 && pet.CurrentCondition.Cleanliness > 20 && pet.CurrentCondition.Happiness > 20)
            {
                pictureBox1.BackgroundImage = Image.FromFile(pet.Pictures[0]);
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(pet.Pictures[2]);
            }
            progressBar1.Value = pet.CurrentCondition.Feed;
            progressBar2.Value = pet.CurrentCondition.Cleanliness;
            progressBar3.Value = pet.CurrentCondition.Happiness;
            ChangeProgressBar(progressBar1, -5);
            ChangeProgressBar(progressBar2, -5);
            ChangeProgressBar(progressBar3, -5);
            
        }

        private void ChangeProgressBar(ProgressBar progressBar, int increment)
        {
            //COLORS OF BARS WHEN DECREASING
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

            if (progressBar.Value >= 0 && progressBar.Value <= 100)
            {
                progressBar.Increment(increment);
            }
        }

        
    }
}
