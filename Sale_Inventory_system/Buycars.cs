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
    public partial class Buycars : Form
    {
        public Buycars()
        {
            InitializeComponent();
        }


        SqlConnection conn = new Myconnection().GetConnection();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;


        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            command = new SqlCommand(query, conn);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;


        }


        public void fill_features()
        {
            conn.Open();
            label7.Visible = true;
            string rec = loginform.recby;
            string str = "select * from Car where Car_name ='" + comboBox2.Text.ToString() + "'";


            SqlCommand com = new SqlCommand(str, conn);

            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {

                reader.Read();
                label8.Text = reader["Gear"].ToString();
                label9.Text = reader["Engine_power"].ToString();
                label10.Text = reader["Mileage"].ToString();

                label11.Text = reader["Steering"].ToString();

                label12.Text = reader["Fuel"].ToString();

                label14.Text = reader["Ratings"].ToString();


                label16.Text = reader["Price"].ToString();

            }

            conn.Close();
        }



        private void Buycars_Load(object sender, EventArgs e)
        {
            fill_features();
            string query = "SELECT * FROM combo";
            fillCombo(comboBox1, query, "Car_Manufacturer_name", "Car_manufacturer_id");
            comboBox1_SelectedIndexChanged(null, null);







        }

        public void getimages()
        {
            if(comboBox2.Text== " Honda City M")
            {
                count = -1;
                imagenumber = 3;
                imagestartnumber = 0;
                next_Click(null, null);
                previous_Click(null, null);

            }
            if(comboBox2.Text== "Hyndai i20")
            {
                pictureBox1.ImageLocation = string.Format(@"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\Resources\imagelist\4.jpg");
                count = 4;
                imagenumber = 7;
                imagestartnumber = 4;
                next_Click(null, null);
                previous_Click(null, null);
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int val;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out val);

            string query = "SELECT Car_name,Car_manufacturer_id FROM Car WHERE Car_manufacturer_id=" + val;
            fillCombo(comboBox2, query, "Car_name", "Car_manufacturer_id");
            comboBox2_SelectedIndexChanged(null, null);


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_features();
            getimages();
        }
        int count = -1;
        int imagenumber = 3;

        private void next_Click(object sender, EventArgs e)
        {
            if (count < imagenumber)
            {
                count++;
                pictureBox1.Image = imageList1.Images[count];
            }
        }

        int imagestartnumber = 0;
        private void previous_Click(object sender, EventArgs e)
        {
            if (count > imagestartnumber)
            {
                count--;
                pictureBox1.Image = imageList1.Images[count];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Car added to cart!!");
        }
    }
}
