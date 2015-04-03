using Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeleteLater
{
    public partial class Form1 : Form
    {
        private Animal pet;
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gender currentGender = Gender.Male;
            if (MaleButton.Checked)
            {
                currentGender = Gender.Male;
            }
            if (FemaleButton.Checked)
            {
                currentGender = Gender.Female;
            }
            int tryer = 0;

            if (int.TryParse(textBox1.Text, out tryer) && textBox3.Text != "" && (MaleButton.Checked || FemaleButton.Checked) && comboBox1.SelectedItem != null)
            {
                pet = AnimalFactory.CreateAnimal(comboBox1.SelectedItem.ToString(), currentGender, textBox3.Text);

                SetGameplayWindow();
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || (!MaleButton.Checked && !FemaleButton.Checked))
            {
                MessageBox.Show("You need to fill all fields!", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((int.TryParse(textBox1.Text, out tryer)) == false)
            {
                MessageBox.Show("Please enter a correct age!", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


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
            button1.Visible = true;
            button1.Enabled = true;
            groupBox1.Visible = true;
            groupBox1.Enabled = true;
            textBox1.Visible = true;
            textBox1.Enabled = true;
            MaleButton.Enabled = true;
            MaleButton.Visible = true;
            FemaleButton.Enabled = true;
            FemaleButton.Visible = true;
            textBox2.Visible = true;
            textBox2.Enabled = true;
            groupBox2.Visible = true;
            groupBox2.Enabled = true;
            textBox3.Visible = true;
            textBox3.Enabled = true;
            comboBox1.Visible = true;
            comboBox1.Enabled = true;
            radioButton1.Visible = true;
            radioButton1.Enabled = true;
            radioButton2.Visible = true;
            radioButton2.Enabled = true;
            textBox2.Focus();


        }

        //STARTING NEW GAME

        private void SetGameplayWindow()
        {
            textBox2.Visible = false;
            textBox2.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            textBox1.Visible = false;
            textBox1.Enabled = false;
            MaleButton.Enabled = false;
            MaleButton.Visible = false;
            FemaleButton.Enabled = false;
            FemaleButton.Visible = false;
            groupBox1.Enabled = false;
            groupBox1.Visible = false;
            textBox3.Enabled = false;
            textBox3.Visible = false;
            radioButton1.Enabled = false;
            radioButton1.Visible = false;
            radioButton2.Enabled = false;
            radioButton2.Visible = false;
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
        }


        private void FeedClick(object sender, EventArgs e)
        {//FEED BUTTON
            pet.CurrentCondition.ChangeFeed(5);
            progressBar1.Value = pet.CurrentCondition.Feed;
            //ChangeProgressBar(progressBar1, 5);
            pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\eat.png");
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
            pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\play.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pet != null)
            {
                pet.CurrentCondition.ChangeAll(-5);
                progressBar1.Value = pet.CurrentCondition.Feed;
                progressBar2.Value = pet.CurrentCondition.Cleanliness;
                progressBar3.Value = pet.CurrentCondition.Happiness;
                //TODO: add sleep

                //ChangeProgressBar(progressBar1, -5);
                //ChangeProgressBar(progressBar2, -5);
                //ChangeProgressBar(progressBar3, -5);
            }

            if (progressBar1.Value > 20 && progressBar2.Value > 20 && progressBar3.Value > 20)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\initial.png");
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\sad.png");
            }
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
