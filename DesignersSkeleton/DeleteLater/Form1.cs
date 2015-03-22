using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeleteLater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button4.Padding = new Padding(0, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gender currentGender = gender.Male;
            if (MaleButton.Checked)
            {
                currentGender = gender.Male;
            }
            if (FemaleButton.Checked)
            {
                currentGender = gender.Female;            
            }
            int tryer=0;
            
            if (int.TryParse(textBox1.Text, out tryer) && (MaleButton.Checked || FemaleButton.Checked))
            {
                Soldier soldier1 = new Soldier((gender)currentGender, int.Parse(textBox1.Text));
                SetGameplayWindow();
                
            }
            else
            {
                MessageBox.Show("You need to fill all fields!", "Invalid data", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Do you really want to leave the game?", "Exit Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
           if (msg == DialogResult.Yes)
           {
               DialogResult saveGame = MessageBox.Show("Do you  want to Save the current progress?","Save Game?", MessageBoxButtons.YesNo, MessageBoxIcon.None);
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
            textBox1.Visible = true;
            textBox1.Enabled = true;
            MaleButton.Enabled = true;
            MaleButton.Visible = true;
            FemaleButton.Enabled = true;
            FemaleButton.Visible = true;

        }

        //STARTING NEW GAME

        private void SetGameplayWindow()
        {
            button1.Visible = false;
            button1.Enabled = false;
            textBox1.Visible = false;
            textBox1.Enabled = false;
            MaleButton.Enabled = false;
            MaleButton.Visible = false;
            FemaleButton.Enabled = false;
            FemaleButton.Visible = false;
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


        private void button5_Click(object sender, EventArgs e)
        {
            ChangeProgressBar(progressBar1, 5);
            pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\eat.png");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeProgressBar(progressBar2, 5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeProgressBar(progressBar3, 5);
            pictureBox1.BackgroundImage = Image.FromFile(@"..\..\Icons\Cat\play.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeProgressBar(progressBar1, -5);
            ChangeProgressBar(progressBar2, -5);
            ChangeProgressBar(progressBar3, -5);
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
            if (progressBar.Value <= 20)
            {
                progressBar.ForeColor = Color.Red;
            }
            else if (progressBar.Value > 20 && progressBar.Value <= 60)
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
