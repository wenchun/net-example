using System;
using System.Windows.Forms;

namespace FormThreadTest
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : Form
	{
		public MainForm()
		{
			this.Closed += new EventHandler(MainForm_Closed);
		}

		public static void Main()
		{			
			MainForm fm = new MainForm();
			fm.Visible = true;
			Application.Run();
		}

		private void MainForm_Closed(object sender, EventArgs e)
		{
			Application.ExitThread();
		}
	}
}
