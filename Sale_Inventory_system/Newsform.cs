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
    public partial class Newsform : Form
    {
        public Newsform()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Newsform_Load(object sender, EventArgs e)
        {
            label1.Text = "Tata Motors to Launch three new models by 2021";
            label2.Text = "Motor Vehicles in India to get more expensive as government proposes hike in registration charges";

            label3.Text = "Tata Motors Showcases 7 New Public Transportation Vehicles At Prawaas 2019";
            label4.Text = "Volkswagen India Extends Service Support To Customers Affected By Bihar & Assam Floods";

            label5.Text = "New BMW 7 series launched, Gets plug in hybrid variant and more luxury";
            label5.Text = "Maruti Suzuki ertiga CNG and ertiga tour CNG launched";
            label6.Text = "Triumph Bonneville 900cc Family launched";
            label7.Text = "Kawasaki Launched the W800 Street at Rs.7.99 lakh";
            label8.Text = "Mahindra Bolero gets BS6 ready engine and safety updates";
            label9.Text = "Yamaha SZ-RR version 2.0 discontinued";


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X , label1.Location.Y-5);
            if (label1.Location.Y <-this.Height)
            {
                label1.Location = new Point(label1.Location.X,label1.Height);
            }
            label2.Location = new Point(label2.Location.X, label2.Location.Y - 5);
            if (label2.Location.Y <- this.Height)
            {
                label2.Location = new Point(label2.Location.X,label2.Height);
            }
            label3.Location = new Point(label3.Location.X, label3.Location.Y - 5);
            if (label3.Location.Y <- this.Height)
            {
                label3.Location = new Point(label3.Location.X, label3.Height);
            }
            label4.Location = new Point(label4.Location.X, label4.Location.Y - 5);
            if (label4.Location.Y <-this.Height)
            {
                label4.Location = new Point(label4.Location.X,label4.Height);
            }
            label5.Location = new Point(label5.Location.X, label5.Location.Y - 5);
            if (label5.Location.Y < -this.Height)
            {
                label5.Location = new Point(label5.Location.X, label5.Height);
            }
            label6.Location = new Point(label6.Location.X, label6.Location.Y - 5);
            if (label6.Location.Y < -this.Height)
            {
                label6.Location = new Point(label6.Location.X, label6.Height);
            }
            label7.Location = new Point(label7.Location.X, label7.Location.Y - 5);
            if (label7.Location.Y < -this.Height)
            {
                label7.Location = new Point(label7.Location.X, label7.Height);
            }
            label8.Location = new Point(label8.Location.X, label8.Location.Y - 5);
            if (label8.Location.Y < -this.Height)
            {
                label8.Location = new Point(label8.Location.X, label8.Height);
            }
            label9.Location = new Point(label9.Location.X, label9.Location.Y - 5);
            if (label9.Location.Y < -this.Height)
            {
                label9.Location = new Point(label9.Location.X, label9.Height);
            }
        }
    }
}
