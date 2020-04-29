using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sale_Inventory_system
{
    public partial class Signupform : Form
    {
        public Signupform()
        {
            InitializeComponent();
        }

        public static string username;
        public static string recby
        {
            get { return username; }
            set { username = value; }
        }


        SqlConnection cm = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\Database.mdf';Integrated Security=True");

        private void Signupform_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "")
                MessageBox.Show("Please Enter Username and password");
            else if (textBox12.Text != textBox10.Text)
                MessageBox.Show("Password do not match");
            else
            {



                SqlCommand cmd = new SqlCommand("Addperson", cm);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", textBox11.Text);
                recby = textBox11.Text;
                cmd.Parameters.AddWithValue("@Password", textBox12.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@DoorNo", textBox3.Text);
                cmd.Parameters.AddWithValue("@Street", textBox4.Text);
                cmd.Parameters.AddWithValue("@City", textBox5.Text);
                cmd.Parameters.AddWithValue("@Landmark", textBox6.Text);
                cmd.Parameters.AddWithValue("@State", textBox7.Text);
                cmd.Parameters.AddWithValue("@Pincode", textBox8.Text);
                cmd.Parameters.AddWithValue("@Contactno", textBox9.Text);
                cm.Open();
                cmd.ExecuteNonQuery();
                cm.Close();
                MessageBox.Show("Registration complete!!!");
                Mail1 obj1 = new Mail1();
                obj1.Show();

                
            }
        }
    }
}
