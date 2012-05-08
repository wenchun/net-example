using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace MsnDemo
{
	public partial class Form1 : Form
	{
		private SimpleMsnMessenger msn;

		public Form1()
		{
			InitializeComponent();
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			btnSendMsg.Enabled = false;
			msn = new SimpleMsnMessenger();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{			
			if (msn.Connected)
			{
				SetStatus("Disconnecting from server");
				msn.Disconnect();
			}

			msn.Account = txtAccount.Text;
			msn.Password = txtPassword.Text;


			// inform the user what is happening and try to connecto to the messenger network.			
			SetStatus("正在登入...");

			msn.Connect();

			while (msn.IsConnecting && msn.ErrorCount <= 0)
			{
				Application.DoEvents();
			}

			if (msn.Connected && msn.SignedIn)
			{
				btnSendMsg.Enabled = true;
				SetStatus("登入成功!");
			}
			else
			{
				if (msn.ErrorCount > 0)
				{
					SetStatus("登入失敗! " + msn.LastError.Message);
					txtMsg.Text = "InnerException:\r\n" + msn.LastError.InnerException.Message;
				}
				else 
				{
					SetStatus("登入失敗! ");
				}
			}
		}

		/// <summary>
		/// A delegate passed to Invoke in order to create the conversation form in the thread of the main form.
		/// </summary>
		private delegate void SetStatusDelegate(string status);

		private void SetStatusSynchronized(string status)
		{
			statusStrip1.Items[0].Text = status;
		}

		private void SetStatus(string text)
		{
			this.Invoke(new SetStatusDelegate(SetStatusSynchronized), new object[] { text });
		}

		private void btnSendMsg_Click(object sender, EventArgs e)
		{
			msn.SendTextMessage(txtContact.Text, "Testing MSN robot!");
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			msn.Disconnect();
		}

	}
}