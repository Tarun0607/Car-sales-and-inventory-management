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
    public partial class agentform : Form
    {
        public agentform()
        {
            InitializeComponent();
        }

        private void agentform_Load(object sender, EventArgs e)
        {
            if (loginform.recby.Equals("/ah"))
            {

                toolStripStatusLabel2.Text = "Honda agent";
                pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\8.png");
            }

            if (loginform.recby.Equals("/ams"))
            {
                toolStripStatusLabel2.Text = "Maruti Suzuki agent";
                pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\1.png");
            }

            if (loginform.recby.Equals("/ahy"))
            {

                toolStripStatusLabel2.Text = "Hyundai agent";
                pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\4.png");
            }


            if (loginform.recby.Equals("/ato"))
            {

                toolStripStatusLabel2.Text = "Toyota agent";
                pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\11.png");
            }


            if (loginform.recby.Equals("/ata"))
            {

                toolStripStatusLabel2.Text = "Tata agent";
                pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\12.png");

            }
                if (loginform.recby.Equals("/af"))
                {

                    toolStripStatusLabel2.Text = "Ford agent";
                    pictureBox2.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\Logo\13.png");
                }


            



                }

                private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serviceview_agent obj = new serviceview_agent();
            obj.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform obj = new loginform();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            managestocks obj = new managestocks();
            obj.Show();
        }
    }
}
