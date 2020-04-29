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
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
            timer1.Start();
            loadcaptcha();
        }

        public static string check="no";
        public static string username;
        public static string recby
        {
            get { return username;}
            set { username = value; }
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        int num = 0;
        private void loadcaptcha()
        {
            //throw new NotImplementedException();
            Random r1 = new Random();
            num = r1.Next(100,5000);
            var img = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Arial",30,FontStyle.Bold,GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(img);
            graphics.DrawString(num.ToString(), font, Brushes.Red, new Point(0, 0));
            pictureBox1.Image = img;
        }

        private void getdata()
        {
            var flag = 0;
            var flag1 = 0;
            var flag2 = 0;
            string name = UserName.Text;
            recby = name;
            string pass = Password.Text;
            string adu = "admin";
            da = new SqlDataAdapter("Select Username FROM Users WHERE Username like'" + UserName.Text + "'and Password='" + Password.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (UserName.Text == "")
            {
                flag = 1;
                MessageBox.Show("Enter a valid Username!!");
            }
            if (Password.Text == "")
            {
                flag1 = 1;
                MessageBox.Show("Enter a valid Password!!");
            }
            if (textBox1.Text != num.ToString())
            {
                flag2 = 1;
                MessageBox.Show("Entered captcha is wrong !!");
            }

            if (flag == 0 && flag1 == 0 && flag2==0) { 
                if (dt.Rows.Count == 1 && textBox1.Text == num.ToString())
                {
                    MessageBox.Show("Log in Success");
                    Userform obj = new Userform();
                    this.Hide();
                    obj.Show();
                }
                else if (name.Equals(adu) && pass.Equals(adu))
                {
                    MessageBox.Show("Successfully logged in as admin");
                    adminform obj = new adminform();
                    this.Hide();
                    obj.Show();


                }
                else if (name.StartsWith("/") && pass.StartsWith("/"))
                {
                    MessageBox.Show("Successfully loged in as agent");
                    agentform obj = new agentform();
                    this.Hide();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Entered credentials are wrong");
                }
        }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            check = "yes";
            getdata();


            

        }

        public static string transfer
        {
            get { return check; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label6.Location = new Point(label6.Location.X -5, label6.Location.Y);
            if (label6.Location.X<-this.Width)
            {
                label6.Location = new Point(label6.Width,label6.Location.Y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signupform obj = new Signupform();
            this.Hide();
            obj.Show();
        }




        private void loginform_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadcaptcha();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
