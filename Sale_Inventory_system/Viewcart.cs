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
    public partial class Viewcart : Form
    {
        public Viewcart()
        {
            InitializeComponent();
        }

        SqlConnection conn = new Myconnection().GetConnection();

        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Viewcart_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", loginform.recby);
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
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                





            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void refresh_DataGridView2()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Viewcarttestdrive_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", loginform.recby);
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

                dataGridView2.DataSource = DS.Tables[0];
                this.dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                





            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

















        private void Viewcart_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
            refresh_DataGridView2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order confirmed!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("deleteservice_sp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceId", textBox1.Text);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Userform obj = new Userform();
            obj.Show();
        }
    }
}
