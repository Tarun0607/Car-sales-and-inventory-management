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
using System.Data;

namespace Sale_Inventory_system
{
    public partial class Profileform : Form
    {
        public Profileform()
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
            string rec = loginform.recby;
            string str = "select * from Users where Username='" + loginform.recby.ToString() + "'";
          
         
            SqlCommand com = new SqlCommand(str, conn);
          
            SqlDataReader reader = com.ExecuteReader();

             reader.Read();
             label7.Text = reader["FirstName"].ToString();
             label8.Text = reader["Lastname"].ToString();
             label9.Text = reader["DoorNo"].ToString();
            
                label10.Text = reader["Street"].ToString();
            
                label11.Text = reader["City"].ToString();
            
            label12.Text = reader["Landmark"].ToString();
            
            label15.Text = reader["State"].ToString();
            
            label16.Text = reader["Pincode"].ToString();
            
            label17.Text = reader["Contactno"].ToString();
            
            conn.Close();
        }



        private void Profileform_Load(object sender, EventArgs e)
        {
            fill_price();
         }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
