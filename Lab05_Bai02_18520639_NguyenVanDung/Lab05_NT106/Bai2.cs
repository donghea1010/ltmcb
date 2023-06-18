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
using System.Threading;

using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace Lab05_NT106
{
	public partial class Bai2 : Form
	{
		public Bai2()
		{
			InitializeComponent();
		}
		private void GetMail()
		{
			using (var client = new ImapClient())
			{
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
				client.Connect("localhost", 993, true);
				client.Authenticate(tb_email.Text, tb_password.Text);
				// The Inbox folder is always available on all IMAP servers...
				var inbox = client.Inbox;
				inbox.Open(FolderAccess.ReadOnly);
				lb_total.Text = inbox.Count.ToString();
				lb_recent.Text = inbox.Recent.ToString();
				listView1.Columns.Add("Email", 200);
				listView1.Columns.Add("From", 100);
				listView1.Columns.Add("Thời gian", 100);
				listView1.View = View.Details;
				for (int i = 0; i < inbox.Count; i++)
				{
					var message = inbox.GetMessage(i);
					ListViewItem name = new ListViewItem(message.Subject);
					ListViewItem.ListViewSubItem from = new
					ListViewItem.ListViewSubItem(name, message.From.ToString());
					name.SubItems.Add(from);
					ListViewItem.ListViewSubItem date = new
					ListViewItem.ListViewSubItem(name, message.Date.Date.ToString());
					name.SubItems.Add(date);
					listView1.Items.Add(name);
				}
				client.Disconnect(true);
			}
		}
		private void bt_login_Click(object sender, EventArgs e)
		{
			GetMail();
		}
	}
}

