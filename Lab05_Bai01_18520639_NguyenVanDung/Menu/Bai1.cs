using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Menu
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void sendEmail_click(object sender, EventArgs e)
        {
            using (SmtpClient smtpClient = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = txtFrom.Text.ToString().Trim();
                string mailTo = txtTo.Text.ToString().Trim();
                string password = txtPassword.ToString().Trim();
                var basicCredential = new NetworkCredential(mailFrom, password);
                using (MailMessage message = new MailMessage()) 
                {
                    MailAddress fromAddress = new MailAddress(mailFrom);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = txtSubject.Text.ToString().Trim();
                    message.IsBodyHtml = true;
                    message.Body = richtxtBody.Text.ToString();
                    message.To.Add(mailTo);

                    try
                    {
                        smtpClient.Send(message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtpClient = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = txtFrom.Text.ToString().Trim();
                string mailTo = txtTo.Text.ToString().Trim();
                string password = txtPassword.ToString().Trim();
                var basicCredential = new NetworkCredential(mailFrom, password);
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(mailFrom);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = txtSubject.Text.ToString().Trim();
                    message.IsBodyHtml = true;
                    message.Body = richtxtBody.Text.ToString();
                    message.To.Add(mailTo);

                    try
                    {
                        smtpClient.Send(message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
