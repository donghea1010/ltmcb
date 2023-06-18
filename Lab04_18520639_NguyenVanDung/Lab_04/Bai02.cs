using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Lab_04
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }
        private string PostHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(Data_txt.Text);
            request.ContentLength = byteArray.Length;
            request.ContentType = "application / x - www - form - urlencoded";

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromSever = reader.ReadToEnd();
            response.Close();

            return responseFromSever;
        }
        private void Post_btn_Click(object sender, EventArgs e)
        {
            ContentHTML_richtxt.Text = PostHTML(URL_txt.Text);
        }
    }
}
