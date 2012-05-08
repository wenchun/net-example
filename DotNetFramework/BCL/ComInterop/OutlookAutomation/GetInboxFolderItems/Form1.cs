using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace GetInboxFolderItems
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnGetInboxItems;
		private System.Windows.Forms.ListView lvMailItems;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lvMailItems = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.btnGetInboxItems = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvMailItems
			// 
			this.lvMailItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader2,
																						  this.columnHeader1});
			this.lvMailItems.FullRowSelect = true;
			this.lvMailItems.GridLines = true;
			this.lvMailItems.Location = new System.Drawing.Point(16, 72);
			this.lvMailItems.Name = "lvMailItems";
			this.lvMailItems.Size = new System.Drawing.Size(560, 344);
			this.lvMailItems.TabIndex = 0;
			this.lvMailItems.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "寄件人";
			this.columnHeader2.Width = 173;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "信件標題";
			this.columnHeader1.Width = 356;
			// 
			// btnGetInboxItems
			// 
			this.btnGetInboxItems.Location = new System.Drawing.Point(16, 16);
			this.btnGetInboxItems.Name = "btnGetInboxItems";
			this.btnGetInboxItems.Size = new System.Drawing.Size(184, 40);
			this.btnGetInboxItems.TabIndex = 1;
			this.btnGetInboxItems.Text = "取得收件夾的信件清單";
			this.btnGetInboxItems.Click += new System.EventHandler(this.btnGetInboxItems_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(296, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(592, 437);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnGetInboxItems);
			this.Controls.Add(this.lvMailItems);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Outlook Automation 範例";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnGetInboxItems_Click(object sender, System.EventArgs e)
		{
			Outlook.Application outlook;
			Outlook.MailItem mail;
			Outlook.NameSpace ns;
			Outlook.MAPIFolder inbox;
			Outlook.Items items;

			outlook = new Outlook.Application();
			ns = outlook.GetNamespace("mapi");
			inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
			items = inbox.Items;

			ListViewItem lvItem;

			foreach (object item in items) 
			{
				mail = (Outlook.MailItem) item;

				lvItem = new ListViewItem();
				lvItem.Text = mail.SenderName;
				lvItem.SubItems.Add(mail.Subject);

				lvMailItems.Items.Add(lvItem);
			}

			outlook = null;
		}


		Outlook.Application outlook;

		private void button1_Click(object sender, System.EventArgs e)
		{

			Outlook.NameSpace myNameSpace;
			outlook = new Outlook.Application();
			myNameSpace = outlook.GetNamespace("MAPI");
			myNameSpace.Logon("Outlook", null, true, true);


		}
	}
}
