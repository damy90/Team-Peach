using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteLater
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            form.Size = new Size(640, 480);
            form.Location = new Point(0, 0);           
            Application.Run(form);
           
            

        }
        
    }
}
