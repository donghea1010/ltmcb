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

namespace Bai02
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        void Fill(string s)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(s);
                DirectoryInfo[] diArr = di.GetDirectories();
                FileInfo[] fiArr = di.GetFiles();

                foreach (DirectoryInfo i in diArr)
                {
                    ListViewItem lvi = new ListViewItem(i.Name);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("Folder");
                    lvi.SubItems.Add(i.CreationTime.ToString());
                    listView.Items.Add(lvi);

                }
                foreach (FileInfo i in fiArr)
                {
                    ListViewItem lvi = new ListViewItem(i.Name);
                    lvi.SubItems.Add((i.Length / 1024).ToString() + " KB");
                    lvi.SubItems.Add(i.Extension.ToString());
                    lvi.SubItems.Add(i.CreationTime.ToString());
                    listView.Items.Add(lvi);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("ổ đĩa không tồn tại");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo i in drives)
            {
                ODia.Items.Add(i.Name);
            }
        }
        private void ODia_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        private void Go_Click(object sender, EventArgs e)
        {

        }

        private void Go_Click_1(object sender, EventArgs e)
        {
           
        }

        private void ODia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView.Items.Clear();
            try
            {
                DirectoryInfo di = new DirectoryInfo(ThuMuc.Text);
                FileInfo[] fiArr = di.GetFiles();
                foreach (FileInfo i in fiArr)
                {
                    ListViewItem lvi = new ListViewItem(i.Name);
                    lvi.SubItems.Add((i.Length / 1024).ToString() + " KB");
                    lvi.SubItems.Add(i.Extension.ToString());
                    lvi.SubItems.Add(i.CreationTime.ToString());
                    listView.Items.Add(lvi);

                }
            }
            catch (IOException)
            {
                MessageBox.Show("Thư mục không tồn tại. Xin vui lòng kiểm tra lại!");
            }
        }
    }
}
