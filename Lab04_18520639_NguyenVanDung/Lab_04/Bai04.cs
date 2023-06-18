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
    public partial class Bai04 : Form
    {
        public Bai04()
        {
            InitializeComponent();
        }
        
        private void Go_btn_Click(object sender, EventArgs e)
        {
            if (URL_txt == null)
                MessageBox.Show("Địa chỉ không được để trống");
            webBrowser1.Navigate(URL_txt.Text); 
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void DownlSource_btn_Click(object sender, EventArgs e)
        {
            Bai03 bai03 = new Bai03();
            bai03.Show();
            // Phần down này giống bài 3 đúng không cô, bây giờ hình như có hỗ trợ hết rồi, không cần json luôn ấy cô, 
            //các file HTML vẫn có thể hiển thị hình ảnh video được
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Forward_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Refesh_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
