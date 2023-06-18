using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
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
            ContentHTML_richtxt.Text=getHTML(URL_txt.Text);
        }
    }
}
