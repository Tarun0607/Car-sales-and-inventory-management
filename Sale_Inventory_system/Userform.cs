using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_Inventory_system
{
    public partial class Userform : Form
    {
        public Userform()
        {
            InitializeComponent();
        }

        private void Userform_Load(object sender, EventArgs e)
        {
            label7.Hide();
            label5.Hide();
            label6.Hide();
            if (loginform.check == "yes")
                toolStripStatusLabel2.Text = loginform.recby;
            else
                toolStripStatusLabel2.Text = Signupform.recby;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profileform obj = new Profileform();
            obj.Show();
        }

        private int imagenumber = 1;
        private int logonumber = 1;

        private void LoadNextImage()
        {
            if (imagenumber == 1)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Maruti Shift";
                label6.Text = "Maruti Suzuki";

            }
            if (imagenumber == 2)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Maruti Alto";
                label6.Text = "Maruti Suzuki";
            }
            if (imagenumber == 3)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Maruti Baleno";
                label6.Text = "Maruti Suzuki";
            }
            if (imagenumber == 4)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Hyundai Creta";
                label6.Text = "Hyundai";
            }
            if (imagenumber == 5)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Hyundai Elite i20";
                label6.Text = "Hyundai";
            }
            if (imagenumber == 6)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Maruti Vitara Breeza";
                label6.Text = "Maruti Suzuki";
            }
            if (imagenumber == 7)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Hyundai Grand i10";
                label6.Text = "Hyundai";
            }
            if (imagenumber == 8)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Honda Amaze";
                label6.Text = "Honda";
            }
            if (imagenumber == 9)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Honda City";
                label6.Text = "Honda";
            }
            if (imagenumber == 10)
            {
                label5.Show();
                label6.Show();
                label5.Text = "Honda BR-V";
                label6.Text = "Honda";

          
            }
            Slidingpanel.ImageLocation = string.Format(@"Sliding_panel_images\{0}.jpg", imagenumber);
            
            imagenumber++;
            if (imagenumber == 11)
            {
                imagenumber = 1;
            }

        }

        private void LoadNextLogo()
        {




           Logobox.ImageLocation = string.Format(@"Logo\{0}.png", logonumber);
            
            logonumber++;
            if (logonumber == 11)
            {
                logonumber = 1;
            }
        }




        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadNextLogo();
            LoadNextImage();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Slidingpanel_Click(object sender, EventArgs e)
        {

        }

        private void Logobox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Newsform obj = new Newsform();
            obj.Show();
            
            /*label2.Hide();
            panel1.Hide();
            label7.Show();
            label7.Text = "Tata Motors to Launch three new models by 2021\nMotor Vehicles in India to get more expensive as government proposes hike in registration charges\nTata Motors Showcases 7 New Public Transportation Vehicles At Prawaas 2019\nVolkswagen India Extends Service Support To Customers Affected By Bihar & Assam Floods";
              */  


        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buycars obj = new Buycars();
            obj.Show();
            /*label7.Hide();
            label2.Show();
            panel1.Show();
            */
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service obj = new service();
            obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void testDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Testdrive obj = new Testdrive();
            obj.Show();
        }

        private void sellCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sellform obj = new Sellform();
            obj.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profileform obj = new Profileform();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform obj = new loginform();
            obj.Show();
        }

        private void viewCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewcart obj = new Viewcart();
            obj.Show();
        }
    }
}
