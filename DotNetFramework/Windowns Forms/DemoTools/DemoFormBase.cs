using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DemoTools
{
	/// <summary>
	/// 繼承自此類別的 form 將會有一個 TextBox，用來輸出文字訊息。
	/// 使用此 form 類別的好處是應用程式無論在任何地方都可以用 Console.WriteLine() 來輸出訊息，
	/// 而無需 using 額外的 namespace。那些透過 Console.WriteLine 輸出的訊息都會被重新導向至 TextBbox。
	/// 
	/// <para>NOTE：若要清除整個 TextBox 的內容，可以用 Console.WriteLine("!CLEAR")。</para>
	/// 
	/// Written by Huan-Lin Tsai. 2009-9-27.
	/// </summary>
	public partial class DemoFormBase : Form
	{
		private TextWriter m_OldConsoleWriter = Console.Out;

		public DemoFormBase()
		{
			InitializeComponent();
		}

		protected void WriteLine(string msg)
		{
			if (msg.StartsWith("!CLEAR"))
			{
				ClearOutput();
			}
			else
			{
				txtOutput.AppendText(msg + Environment.NewLine);
			}
		}

		protected void ClearOutput()
		{
			txtOutput.Clear();
		}

		private void btnClearOutput_Click(object sender, EventArgs e)
		{
			ClearOutput();
		}

		private void DemoFormBase_Load(object sender, EventArgs e)
		{
			MyConsoleWriter writer = new MyConsoleWriter();
			Console.SetOut(writer);

			MyConsole.RegisterMessageEvent(this.WriteLine);
		}

		private void DemoFormBase_FormClosed(object sender, FormClosedEventArgs e)
		{
			Console.SetOut(m_OldConsoleWriter);
		}
	}

	class MyConsoleWriter : StringWriter
	{
		public override void WriteLine(string value)
		{
			// 把字串轉由 MyConsole 輸出.
			MyConsole.WriteLine(value);
		}

		public override void WriteLine(int value)
		{
			WriteLine(value.ToString());
		}

		public override void WriteLine(bool value)
		{
			WriteLine(value.ToString());
		}

		public override void WriteLine(object value)
		{
			WriteLine(Convert.ToString(value));
		}

		public override void WriteLine(string format, object arg0)
		{
			base.Write(format, arg0);
			StringBuilder sb = base.GetStringBuilder();
			this.WriteLine(sb.ToString());
			sb.Length = 0;
		}

		public override void WriteLine(string format, object arg0, object arg1)
		{
			base.Write(format, arg0, arg1);
			StringBuilder sb = base.GetStringBuilder();
			this.WriteLine(sb.ToString());
			sb.Length = 0;
		}

		public override void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			base.Write(format, arg0, arg1, arg2);
			StringBuilder sb = base.GetStringBuilder();
			this.WriteLine(sb.ToString());
			sb.Length = 0;
		}

		public override void WriteLine(string format, params object[] arg)
		{
			base.Write(format, arg);
			StringBuilder sb = base.GetStringBuilder();
			this.WriteLine(sb.ToString());
			sb.Length = 0;
		}
	}

	#region MyConsole helper class

	public delegate void OutputMessageEvent(string msg);

	public static class MyConsole
	{
		private static event OutputMessageEvent m_OutputMsgEvent = null;

		public static void RegisterMessageEvent(OutputMessageEvent handler)
		{
			m_OutputMsgEvent = handler;
		}


		public static void Clear()
		{
			if (m_OutputMsgEvent != null)
			{
				m_OutputMsgEvent("!CLEAR");
			}
		}

		public static void WriteLine(string msg)
		{
			if (m_OutputMsgEvent != null)
			{
				m_OutputMsgEvent(msg);
			}
		}

		public static void WriteLine(object value)
		{
			if (m_OutputMsgEvent != null)
			{
				m_OutputMsgEvent(Convert.ToString(value));
			}
		}
	}
	#endregion 
}
