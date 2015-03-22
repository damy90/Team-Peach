using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        

        


     
    }
}
