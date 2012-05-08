using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;


namespace From_C_Sharp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
	public class Form1 : System.Windows.Forms.Form
	{
#if _DEBUG
const string WmCpyDta = "WmCpyDta_d.dll";
#else
const string WmCpyDta = "WmCpyDta.dll";
#endif

		[DllImport("user32.dll",EntryPoint="FindWindow")]
		private static extern int FindWindow(string _ClassName, string _WindowName);


		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_SetMessageId")]
		private static extern int WmCpyDta_SetMessageId(int iMsgId);

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_GetMessageId")]
		private static extern int WmCpyDta_GetMessageId();

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_SendMessage_sTagData")]
		private static extern int WmCpyDta_SendMessage_sTagData(int hReceiver , int hSender, string _strTag, string _strData);

		[DllImport(WmCpyDta,EntryPoint="WmCpyDta_SetEncrypt")]
		private static extern void WmCpyDta_SetEncrypt(char c);

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(264, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "Ping -  send a message to the TO apps if they are running";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 72);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(248, 40);
			this.button2.TabIndex = 1;
			this.button2.Text = "Close";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1});
			this.Name = "Form1";
			this.Text = "From C Sharp";
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

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public IntPtr FindProcessByName(string strProcessName)
		{
			IntPtr HandleOfToProcess = IntPtr.Zero;
			Process []p = Process.GetProcesses();
			foreach(Process p1 in p)
			{
				Debug.WriteLine(p1.ProcessName.ToUpper());
				if(p1.ProcessName.ToUpper() == strProcessName)
				{
					HandleOfToProcess = p1.MainWindowHandle;
					break;
				}
			}
			return HandleOfToProcess;
		}//ListAllProcess

		private void button1_Click(object sender, System.EventArgs e)
		{
			//Step 1.
			//To send a message to another application the first thing we need is the 
			//handle of the receiving application.
			//One way is to use the FindWindow API
			string cstrReceiverWindowName = "I AM THE C++ RECEIVER WINDOW";
			int WindowHandleOfToProcess  = FindWindow(null, cstrReceiverWindowName);//find by window name
			IntPtr WindowHandle = new IntPtr(WindowHandleOfToProcess);
			//The second way is to iter through all processes 
			//Since a windows title can change, I perfer the second method
			string cstrProcessName = "TO_C";
			IntPtr ProcessHandle = FindProcessByName(cstrProcessName);

			//Step 2.
			//Create some information to send.
			string strTag ="Tag1";
			StringBuilder strMsg = new StringBuilder();
			String strDateTime = DateTime.Now.ToLongTimeString() ;
			DateTime currentDate = new DateTime();
			//currentDate.Now;
			strMsg.Append("Send this string - ");
			strMsg.Append(strDateTime); 
			String strData = strMsg.ToString();

			//Option 1 - Encryption
			//To make a message a little more difficult to hack we can make it look like a bad piece of memory.
			//The receiver must also set the same value.
			WmCpyDta_SetEncrypt('d'); // 'd' is a bitwise seed value. I like to use d because it 
			//makes the message look like bad memory

			/*Option 2
			//If your receiver wants to conditional handle the received message
			//then define new ids based on the default.
			//This example does not need this so we will define a few but not use them.
			WPARAM wCustomMsgId_1 = WmCpyDta_BaseDefaultMsgId() + 1;
			WPARAM wCustomMsgId_2 = WmCpyDta_BaseDefaultMsgId() + 2;
				If some condition then
				WmCpyDta_SetMessageId(wCustomMsgId_1);
				else some other conditin WmCpyDta_SetMessageId(wCustomMsgId_2);
			*/

	
			/* Option 3
			The default behavior of the dll is only to accept messages send by the dll.
			If you want to be more specific then set WmCpyDta_SetSenderId(HWND hSenderId);
			The receiver can then use this value to decide if the message should be accepted.

			The 2nd parameter == NULL in WmCpyDta_SendMessage_sTagData() is the same as
			explicity using WmCpyDta_GetSenderId().

			I do not want to couple my programs that tightly, so I will stick with the default behavior.
			*/
			
			int iResult = 0;
			if(ProcessHandle.ToInt32() != 0)
				iResult = WmCpyDta_SendMessage_sTagData(ProcessHandle.ToInt32() , 0, strTag, strData);
			//------------------------------------------------
			//Now lets send the same message to the C Shape program

			string cstrProcessNameCShape = "TO_C_SHARP";
			IntPtr ProcessHandleCShape = FindProcessByName(cstrProcessNameCShape);
			if(ProcessHandleCShape.ToInt32() != 0)
				iResult = WmCpyDta_SendMessage_sTagData(ProcessHandleCShape.ToInt32() , 0, strTag, strData);
				
		}
	}
}
