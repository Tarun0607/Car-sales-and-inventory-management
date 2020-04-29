using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Sale_Inventory_system
{
    public partial class Mail1 : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;


        public Mail1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential("tarun.ambili123", "achan123");
            client = new SmtpClient("smtp.gmail.com");
            client.Port = Convert.ToInt32("587");
            client.EnableSsl = checkBox1.Checked;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("tarun.ambili123@gmail.com") };
            msg.To.Add(new MailAddress(textBox1.Text));
            msg.Subject = "Registartion Complete";
            msg.Body = "Welcome to CAR WORLD";
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);
            Userform obj = new Userform();
            this.Hide();
            obj.Show();
        }

        private static void SendCompletedCallback(object sender,AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
               MessageBox.Show(string.Format("{0} send cancelled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("An confirmatory message has been sent to ur mail id","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        

        
    }
}
