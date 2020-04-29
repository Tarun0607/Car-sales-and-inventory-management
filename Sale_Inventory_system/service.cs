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
using System.Globalization;



namespace Sale_Inventory_system
{
    public partial class service : Form
    {
        /*List<Car> Cars = new List<Car>();
        List<CarManu> Manufacturer = new List<CarManu>();*/
        SqlConnection conn = new Myconnection().GetConnection();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;


        public service()
        {
            InitializeComponent();
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

        /*public void display()
        {
            
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)comboBox2.SelectedItem;
            string key1 = kvp1.Key.ToString();
            string value1 = kvp1.Value.ToString();
            int i;
            for (i = 0;i<8; i++)
           {
               KeyValuePair<string, string> sample = (KeyValuePair<string, string>)comboBox2.Items[i];
               if (sample.Key.ToString().StartsWith(key1))
               {
                   comboBox2.DisplayMember = sample.Key.ToString();
               }
           }
   
        }*/

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            label6.Visible = true;
            string str = "select Price from Service1 where Service_name='" + comboBox3.Text.ToString() + "'";
            SqlCommand com1 = new SqlCommand(str, conn);
            SqlDataReader reader = com1.ExecuteReader();
            if (reader.HasRows)
            {


                reader.Read();
                label6.Text = reader["Price"].ToString();
            }
            conn.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {








            int val;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out val);

            string query = "SELECT Car_name,Car_manufacturer_id FROM Car WHERE Car_manufacturer_id=" + val;
            fillCombo(comboBox2, query, "Car_name", "Car_manufacturer_id");
            comboBox2_SelectedIndexChanged(null, null);



            /*comboBox2.Items.Clear();
            int id = Cars[comboBox1.SelectedIndex].id;
            foreach(string name in GetcarById(id))
            {
                this.comboBox2.Items.Add(name);
            }*/
        }





        private void service_Load(object sender, EventArgs e)
        {
            label6.Hide();
            string query = "SELECT * FROM combo";
            fillCombo(comboBox1, query, "Car_Manufacturer_name", "Car_manufacturer_id");
            comboBox1_SelectedIndexChanged(null, null);

            /* SqlConnection conn = new Myconnection().GetConnection();
            conn.Open();
            SqlCommand cmdmanufacturer = new SqlCommand("SELECT * from combo", conn);
            SqlDataReader dr = cmdmanufacturer.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Car_Manufacturer_name"]);
                Manufacturer.Add(new CarManu()
                {
                    id = ((int)dr["Car_manufacturer_id"]),
                    Car_Manufacturer_name = dr["Car_Manufacturer_name"] as string

                });
            }
            conn.Close();*/
            /*conn.Open();
            SqlCommand cmdcar = new SqlCommand("SELECT * from Car", conn);
            SqlDataReader dr1 = cmdcar.ExecuteReader();
            while (dr1.Read())
            {
                Cars.Add(new Car()
                { 
                    id=(int)((dr1["CarId"])),
                    Car_name = Convert.ToString(dr1["Car_name"]),
                    Car_manufacturer_id = (Convert.ToInt32(dr1["Car_manufacturer_id"]))

                });
                


            }
            conn.Close();
            
                */







            /*comboBox1.Items.Add(new KeyValuePair<string, string>("Honda", "0"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Hyundai", "1"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Maruti Suzuki", "2"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Tata", "3"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Toyota", "4"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Ford", "5"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Skoda", "6"));
        comboBox1.Items.Add(new KeyValuePair<string, string>("Mahindra", "7"));
        comboBox1.DisplayMember = "key";
        comboBox2.Items.Add(new KeyValuePair<string, string>("Honda City", "0"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Hyundai i20", "1"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Maruti Baleno", "2"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Tata Zest", "3"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Toyota Innova", "4"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Ford figo", "5"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Skoda Rapid", "6"));
        comboBox2.Items.Add(new KeyValuePair<string, string>("Mahindra logan", "7"));
        comboBox2.DisplayMember = "key";

*/







            comboBox3.Items.Add(new KeyValuePair<string, string>("Air filter Change", "0"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Spark Plugs change", "1"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Extensive brake inspection", "2"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Shock absorbers inspection", "3"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("battery and starter tester", "4"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Air conditioning inspection", "5"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Radiator and coolant inspection", "6"));
            comboBox3.Items.Add(new KeyValuePair<string, string>("Body wash", "7"));
            comboBox3.DisplayMember = "key";







        }



        [Serializable]
        class CarManu
        {
            public int id { get; set; }
            public string Car_Manufacturer_name { get; set; }
        }

        class Car
        {
            public int id { get; set; }
            public string Car_name { get; set; }
            public int Car_manufacturer_id { get; set; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {




            /*KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)comboBox2.SelectedItem;*/

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var flag = 0;
            var flag1 = 0;
            var currentDate = DateTime.Today;
            var pardate = DateTime.ParseExact(dateTimePicker1.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture);
            if (pardate <= currentDate)
            {
                flag = 1;
                MessageBox.Show("Invalid date!! Select a date which is more than sysdate!!");
            }

            
            if (comboBox3.Text.Equals(""))
            {
                flag1 = 1;
                MessageBox.Show("Please select a type of service !!");
            }
            

            if(flag==0 && flag1==0)
            {


                SqlCommand cmd = new SqlCommand("Addtoservice_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Carname", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Username", loginform.recby);
                cmd.Parameters.AddWithValue("@Servicetype", comboBox3.Text);
                SqlCommand cmd1 = new SqlCommand("SETDATE_sp", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
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
                MessageBox.Show("Service details added to cart!!!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
