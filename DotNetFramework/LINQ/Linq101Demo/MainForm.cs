using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoTools;

namespace Linq101Demo
{
	public partial class MainForm : DemoFormBase
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		
		}		

		private void btnLinqBasic_Click(object sender, EventArgs e)
		{
			LinqBasicDemo demo = new LinqBasicDemo();
			demo.Run();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DelayedExecutionDemo demo = new DelayedExecutionDemo();
			demo.Run();
		}
	}

}
