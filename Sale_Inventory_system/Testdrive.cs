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
    public partial class Testdrive : Form
    {
        public Testdrive()
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



        private void Testdrive_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM combo";
            fillCombo(comboBox1, query, "Car_Manufacturer_name", "Car_manufacturer_id");
            comboBox1_SelectedIndexChanged(null, null);
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
            SqlCommand cmd = new SqlCommand("Addtotestdrive_sp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Carname", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Username", loginform.recby);
            
            SqlCommand cmd1 = new SqlCommand("SETDATETIME_sp", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
            cmd1.Parameters.AddWithValue("@Time", dateTimePicker2.Text);
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
            MessageBox.Show("Testdrive details added to cart");
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker2.CustomFormat = "HH:mm";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = " ";
            }
        }
    }
}
