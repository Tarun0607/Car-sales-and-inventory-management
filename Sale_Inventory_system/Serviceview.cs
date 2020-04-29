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
    public partial class Serviceview : Form
    {
        public Serviceview()
        {
            InitializeComponent();
        }

        SqlConnection conn = new Myconnection().GetConnection();


        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllcardata_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
















        private void Serviceview_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Addtocompleted_sp", conn);
            cmd1.CommandType = CommandType.StoredProcedure;

            SqlCommand cmd = new SqlCommand("deleteservice_sp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceId", textBox1.Text);
            cmd1.Parameters.AddWithValue("@ServiceId", textBox1.Text);
            conn.Open();
            try
            {
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("                   <<<<INVALID SQL OPERATION>>> \n" + ex);
            }
            conn.Close();
            refresh_DataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Completed_service obj = new Completed_service();
            obj.Show();
        }
    }
}
