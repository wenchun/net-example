using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Test
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private EzTextBox.EzTextBox ezTextBox1;
    private EzTextBox.EzTextBox ezTextBox2;
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
         this.ezTextBox1 = new EzTextBox.EzTextBox();
         this.ezTextBox2 = new EzTextBox.EzTextBox();
         this.SuspendLayout();
         // 
         // ezTextBox1
         // 
         this.ezTextBox1.Location = new System.Drawing.Point(32, 56);
         this.ezTextBox1.Name = "ezTextBox1";
         this.ezTextBox1.Size = new System.Drawing.Size(136, 22);
         this.ezTextBox1.TabIndex = 0;
         this.ezTextBox1.Text = "ezTextBox1";
         // 
         // ezTextBox2
         // 
         this.ezTextBox2.Location = new System.Drawing.Point(32, 104);
         this.ezTextBox2.Name = "ezTextBox2";
         this.ezTextBox2.Size = new System.Drawing.Size(136, 22);
         this.ezTextBox2.TabIndex = 1;
         this.ezTextBox2.Text = "ezTextBox2";
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.ezTextBox2,
                                                                      this.ezTextBox1});
         this.Name = "Form1";
         this.Text = "Form1";
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
	}
}
