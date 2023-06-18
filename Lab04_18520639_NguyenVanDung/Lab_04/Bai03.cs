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
using System.IO;

namespace Lab_04
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }
        private string DownloadHTML(string szURL)
        {
           
            WebClient myClient = new WebClient();
            Stream response = myClient.OpenRead(szURL);

            StreamReader reader = new StreamReader(response);

            string responseFromSever = reader.ReadToEnd();

            response.Close();

            return responseFromSever;
        }

        private void Download_btn_Click(object sender, EventArgs e)
        {
            WebClient myClient = new WebClient();
            myClient.DownloadFile(URL_txt.Text, NameHTML_txt.Text);
            ContentRich_txt.Text = DownloadHTML(URL_txt.Text);

            System.Diagnostics.Process.Start(URL_txt.Text);

        }
    }
}
