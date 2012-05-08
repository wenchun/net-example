using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;


namespace SerialPortTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string s = File.ReadAllText(@"C:\test.txt.brl", Encoding.Default);

			serialPort1.PortName = listBox1.SelectedItem.ToString();
			serialPort1.Open();
			serialPort1.WriteLine(s);
			while (serialPort1.BytesToWrite > 0)
			{
				// wait for writing pending data.
			}
			serialPort1.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listBox1.Items.AddRange(SerialPort.GetPortNames());

			//configuring the serial port
			serialPort1.PortName = "COM3";
			serialPort1.BaudRate = 9600;
			serialPort1.DataBits = 8;
			serialPort1.Parity = Parity.None;
			serialPort1.StopBits = StopBits.One;
			serialPort1.Handshake = Handshake.XOnXOff;
		}
	}
}
