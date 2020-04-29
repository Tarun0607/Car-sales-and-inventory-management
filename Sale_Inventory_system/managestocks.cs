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
    public partial class managestocks : Form
    {
        public managestocks()
        {
            InitializeComponent();
        }

        SqlConnection conn = new Myconnection().GetConnection();


        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Showspecificcars_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (loginform.recby == "/ams")
                {
                    var Car_manufacturer_id = 4;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/ah")
                {
                    var Car_manufacturer_id = 2;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/ahy")
                {
                    var Car_manufacturer_id = 3;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/ata")
                {
                    var Car_manufacturer_id = 5;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/ato")
                {
                    var Car_manufacturer_id = 6;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/af")
                {
                    var Car_manufacturer_id = 7;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                if (loginform.recby == "/am")
                {
                    var Car_manufacturer_id = 8;
                    cmd.Parameters.AddWithValue("@Car_manufacturer_id", Car_manufacturer_id);
                }
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("         <<<INVALID SQL OPERATION>>>: \n" + ex);

                }

                conn.Close();

                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                /*this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; */





            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }






        private void managestocks_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Updatestock_sp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CarId", textBox1.Text);
            cmd.Parameters.AddWithValue("@Stock", textBox2.Text);
            conn.Open();
            try
            {
                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("                   <<<<INVALID SQL OPERATION>>> \n" + ex);
            }
            conn.Close();
            refresh_DataGridView();
        }
    }
}
