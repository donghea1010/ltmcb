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
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }
        private string getHTML(string szURl)
        {
            WebRequest request = WebRequest.Create(szURl);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromSever = reader.ReadToEnd();

            response.Close();

            return responseFromSever;
        }
        private void Send_Click(object sender, EventArgs e)
        {
            ContentHTML_richtxt.Text = getHTML(URL_txt.Text);
        }

        private void URL_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContentHTML_richtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
