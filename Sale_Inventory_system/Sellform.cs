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
    public partial class Sellform : Form
    {
        public Sellform()
        {
            InitializeComponent();
        }

        SqlConnection conn = new Myconnection().GetConnection();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        public void fill_price()
        {
            conn.Open();
            label7.Visible = true;
            string str = "select Price from Car where Car_name='" + comboBox2.Text.ToString() + "'";
            SqlCommand com = new SqlCommand(str, conn);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {


                reader.Read();
                label7.Text = reader["Price"].ToString();
            }
            conn.Close();


        }

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


        private void Sellform_Load(object sender, EventArgs e)
        {

            

            string query = "SELECT * FROM combo";
            fillCombo(comboBox1, query, "Car_Manufacturer_name", "Car_manufacturer_id");
            comboBox1_SelectedIndexChanged(null, null);
            fill_price();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out val);

            string query = "SELECT Car_name,Car_manufacturer_id FROM Car WHERE Car_manufacturer_id=" + val;
            fillCombo(comboBox2, query, "Car_name", "Car_manufacturer_id");
            comboBox2_SelectedIndexChanged(null, null);
            fill_price();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (comboBox2.Text.Equals(" Honda City M"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\0.jpg";




            if (comboBox2.Text.Equals("Hyndai i20"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\1.jpg";

            if (comboBox2.Text.Equals("Maruti Baleno"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\2.jpg";

            if (comboBox2.Text.Equals("Tata Zest"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\3.jpg";

            if (comboBox2.Text.Equals("Toyota Innova"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\4.jpg";
            if (comboBox2.Text.Equals("Ford Figo"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\5.jpg";

            if (comboBox2.Text.Equals("Skoda Rapid"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\6.jpg";
            if (comboBox2.Text.Equals("Mahindra Logan"))
                pictureBox1.ImageLocation = @"C:\Users\Tarun\source\repos\Sale_Inventory_system\Sale_Inventory_system\bin\Debug\7.jpg";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val;
            int val1;
            int flag = 0;
            int flag1 = 0;
            Int32.TryParse(textBox1.Text.ToString(), out val);

            if (val <= 1997 || val >= 2018)
            {
                flag = 1;
                MessageBox.Show("Invalid year choosen!!");
            }
            Int32.TryParse(textBox3.Text.ToString(), out val1);
            if (val1 < 1000 || val1 > 300000)
            {
                flag1 = 1;
                MessageBox.Show("Valid kms range is from 1000 to 300000!! Please enter within this range!!");
            }

            if(flag==0&&flag1==0)
            {



                SqlCommand cmd = new SqlCommand("Addtosell_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carname", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Username", loginform.recby);
                SqlCommand cmd1 = new SqlCommand("Setdetails_sp", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@year", textBox1.Text);
                cmd1.Parameters.AddWithValue("@regno", textBox2.Text);
                cmd1.Parameters.AddWithValue("@distance", textBox3.Text);
                cmd1.Parameters.AddWithValue("@price", label7.Text);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("                   <<<<INVALID SQL OPERATION>>> \n" + ex);
                }
                conn.Close();
                MessageBox.Show("Selling details confirmed !! An employee from our portal will come to your regsitered address within 48 hours for inspection");
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch!=8 && ch != 46)
            {
                e.Handled = true;
                label8.Visible = true;
                label8.Text = "Please Enter Valid Year . .";
            }
            else
            {
                label8.Visible = false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
