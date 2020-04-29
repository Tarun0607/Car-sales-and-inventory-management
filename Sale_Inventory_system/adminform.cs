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
    public partial class adminform : Form
    {
        public adminform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void adminform_Load(object sender, EventArgs e)
        {
            textBox1.Text = loginform.recby;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void viewServiceBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serviceview obj = new Serviceview();
            obj.Show();
        }

        private void viewTestDrivesBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Testdriveview obj = new Testdriveview();
            obj.Show();
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform obj = new loginform();
            obj.Show();
        }
    }
}
