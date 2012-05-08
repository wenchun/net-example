using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;


namespace To_C_Sharp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
#if _DEBUG
const string WmCpyDta = "WmCpyDta_d.dll";
#else
const string WmCpyDta = "WmCpyDta.dll";
#endif


		const int WM_COPYDATA = 0x004A;
		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_MaxTagLen")]
		private static extern int WmCpyDta_MaxTagLen();

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_MaxDataLen")]
		private static extern int WmCpyDta_MaxDataLen();

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_GetMessage_sTagData")]
		private static extern bool WmCpyDta_GetMessage_sTagData(int hReceiver , int hSender, int lParam, StringBuilder lpTag, StringBuilder lpData);

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_SetEncrypt")]
		private static extern void WmCpyDta_SetEncrypt(char c);

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_BaseDefaultMsgId")]
		private static extern int WmCpyDta_BaseDefaultMsgId();

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_SetMessageId")]
		private static extern void WmCpyDta_SetMessageId(int iMsgId);

           
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1 Form1Ref;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Form1Ref = this;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tag that came from the FROM app.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(264, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Data that came from the FROM app.";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 64);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(264, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(14, 126);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(264, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "textBox2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(248, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 205);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "I AM THE C SHARP RECEIVER WINDOW";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		public void ExposeOurTextBoxes(string strTag, string strData)
		{
			textBox1.Text = strTag;
			textBox2.Text = strData;
		}

		protected override void WndProc(ref Message m)
		{
			if(m.Msg == WM_COPYDATA)
			{
				bool bOurMessage = false;

				//Option 1 - Encryption
				//To make a message a little more difficult to hack we can make it look like a bad piece of memory.
				//The sender must also set the same value.
				WmCpyDta_SetEncrypt('d'); // 'd' is a bitwise seed value. I like to use d because it
				//makes the message look like bad memory

				/*Option 2
				//If your receiver wants to conditional handle the received message
				//then define new ids based on the default.
				//This example does not need this so we will define a few but not use them.
				//Look for more comments on wCustomMsgId_1, and wCustomMsgId_2 below.
				WPARAM wCustomMsgId_1 = WmCpyDta_BaseDefaultMsgId() + 1;
				WPARAM wCustomMsgId_2 = WmCpyDta_BaseDefaultMsgId() + 2;
					If some condition then
					WmCpyDta_SetMessageId(wCustomMsgId_1);
					else some other conditin WmCpyDta_SetMessageId(wCustomMsgId_2);
				*/

				WmCpyDta_SetMessageId(WmCpyDta_BaseDefaultMsgId());//define for default behavior

	
				/* Option 3
				The default behavior of the dll is only to accept messages send by the dll.
				If you want to be more specific then set WmCpyDta_SetSenderId(HWND hSenderId);
				The receiver can then use this value to decide if the message should be accepted.

				The 2nd parameter == NULL in WmCpyDta_SendMessage_sTagData() is the same as
				explicity using WmCpyDta_GetSenderId().

				I do not want to couple my programs that tightly, so I will stick with the default behavior.
				*/

				StringBuilder sTag = new StringBuilder(WmCpyDta_MaxTagLen());
				StringBuilder sData = new StringBuilder(WmCpyDta_MaxDataLen());

				bOurMessage = WmCpyDta_GetMessage_sTagData(0, 0, m.LParam.ToInt32(),  sTag,  sData);
				if(bOurMessage)
				{
					if(Form1Ref != null)
					{
						Form1Ref.ExposeOurTextBoxes(sTag.ToString(), sData.ToString());						}
					}

				if(bOurMessage == true)
					return;
			}
	

			base.WndProc(ref m);

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}//WndProc

	}
}
