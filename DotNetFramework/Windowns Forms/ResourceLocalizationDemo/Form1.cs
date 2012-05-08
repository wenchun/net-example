using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Globalization;

namespace ResourceLocalizationDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCultureNeutral;
		private System.Windows.Forms.Button btnCultureChs;
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

		// 額外增加的建構元，提供文化特性參數。
		public Form1(string culture) 
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnCultureNeutral = new System.Windows.Forms.Button();
			this.btnCultureChs = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// textBox1
			// 
			this.textBox1.AccessibleDescription = resources.GetString("textBox1.AccessibleDescription");
			this.textBox1.AccessibleName = resources.GetString("textBox1.AccessibleName");
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textBox1.Anchor")));
			this.textBox1.AutoSize = ((bool)(resources.GetObject("textBox1.AutoSize")));
			this.textBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBox1.BackgroundImage")));
			this.textBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textBox1.Dock")));
			this.textBox1.Enabled = ((bool)(resources.GetObject("textBox1.Enabled")));
			this.textBox1.Font = ((System.Drawing.Font)(resources.GetObject("textBox1.Font")));
			this.textBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textBox1.ImeMode")));
			this.textBox1.Location = ((System.Drawing.Point)(resources.GetObject("textBox1.Location")));
			this.textBox1.MaxLength = ((int)(resources.GetObject("textBox1.MaxLength")));
			this.textBox1.Multiline = ((bool)(resources.GetObject("textBox1.Multiline")));
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = ((char)(resources.GetObject("textBox1.PasswordChar")));
			this.textBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textBox1.RightToLeft")));
			this.textBox1.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textBox1.ScrollBars")));
			this.textBox1.Size = ((System.Drawing.Size)(resources.GetObject("textBox1.Size")));
			this.textBox1.TabIndex = ((int)(resources.GetObject("textBox1.TabIndex")));
			this.textBox1.Text = resources.GetString("textBox1.Text");
			this.textBox1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textBox1.TextAlign")));
			this.textBox1.Visible = ((bool)(resources.GetObject("textBox1.Visible")));
			this.textBox1.WordWrap = ((bool)(resources.GetObject("textBox1.WordWrap")));
			// 
			// btnCultureNeutral
			// 
			this.btnCultureNeutral.AccessibleDescription = resources.GetString("btnCultureNeutral.AccessibleDescription");
			this.btnCultureNeutral.AccessibleName = resources.GetString("btnCultureNeutral.AccessibleName");
			this.btnCultureNeutral.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnCultureNeutral.Anchor")));
			this.btnCultureNeutral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCultureNeutral.BackgroundImage")));
			this.btnCultureNeutral.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnCultureNeutral.Dock")));
			this.btnCultureNeutral.Enabled = ((bool)(resources.GetObject("btnCultureNeutral.Enabled")));
			this.btnCultureNeutral.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnCultureNeutral.FlatStyle")));
			this.btnCultureNeutral.Font = ((System.Drawing.Font)(resources.GetObject("btnCultureNeutral.Font")));
			this.btnCultureNeutral.Image = ((System.Drawing.Image)(resources.GetObject("btnCultureNeutral.Image")));
			this.btnCultureNeutral.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCultureNeutral.ImageAlign")));
			this.btnCultureNeutral.ImageIndex = ((int)(resources.GetObject("btnCultureNeutral.ImageIndex")));
			this.btnCultureNeutral.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnCultureNeutral.ImeMode")));
			this.btnCultureNeutral.Location = ((System.Drawing.Point)(resources.GetObject("btnCultureNeutral.Location")));
			this.btnCultureNeutral.Name = "btnCultureNeutral";
			this.btnCultureNeutral.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnCultureNeutral.RightToLeft")));
			this.btnCultureNeutral.Size = ((System.Drawing.Size)(resources.GetObject("btnCultureNeutral.Size")));
			this.btnCultureNeutral.TabIndex = ((int)(resources.GetObject("btnCultureNeutral.TabIndex")));
			this.btnCultureNeutral.Text = resources.GetString("btnCultureNeutral.Text");
			this.btnCultureNeutral.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCultureNeutral.TextAlign")));
			this.btnCultureNeutral.Visible = ((bool)(resources.GetObject("btnCultureNeutral.Visible")));
			this.btnCultureNeutral.Click += new System.EventHandler(this.btnCultureNeutual_Click);
			// 
			// btnCultureChs
			// 
			this.btnCultureChs.AccessibleDescription = resources.GetString("btnCultureChs.AccessibleDescription");
			this.btnCultureChs.AccessibleName = resources.GetString("btnCultureChs.AccessibleName");
			this.btnCultureChs.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnCultureChs.Anchor")));
			this.btnCultureChs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCultureChs.BackgroundImage")));
			this.btnCultureChs.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnCultureChs.Dock")));
			this.btnCultureChs.Enabled = ((bool)(resources.GetObject("btnCultureChs.Enabled")));
			this.btnCultureChs.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnCultureChs.FlatStyle")));
			this.btnCultureChs.Font = ((System.Drawing.Font)(resources.GetObject("btnCultureChs.Font")));
			this.btnCultureChs.Image = ((System.Drawing.Image)(resources.GetObject("btnCultureChs.Image")));
			this.btnCultureChs.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCultureChs.ImageAlign")));
			this.btnCultureChs.ImageIndex = ((int)(resources.GetObject("btnCultureChs.ImageIndex")));
			this.btnCultureChs.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnCultureChs.ImeMode")));
			this.btnCultureChs.Location = ((System.Drawing.Point)(resources.GetObject("btnCultureChs.Location")));
			this.btnCultureChs.Name = "btnCultureChs";
			this.btnCultureChs.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnCultureChs.RightToLeft")));
			this.btnCultureChs.Size = ((System.Drawing.Size)(resources.GetObject("btnCultureChs.Size")));
			this.btnCultureChs.TabIndex = ((int)(resources.GetObject("btnCultureChs.TabIndex")));
			this.btnCultureChs.Text = resources.GetString("btnCultureChs.Text");
			this.btnCultureChs.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCultureChs.TextAlign")));
			this.btnCultureChs.Visible = ((bool)(resources.GetObject("btnCultureChs.Visible")));
			this.btnCultureChs.Click += new System.EventHandler(this.btnCultureChs_Click);
			// 
			// Form1
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.btnCultureChs);
			this.Controls.Add(this.btnCultureNeutral);
			this.Controls.Add(this.groupBox1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "Form1";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.groupBox1.ResumeLayout(false);
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

		private void btnCultureNeutual_Click(object sender, System.EventArgs e)
		{
			Form1 aForm = new Form1("");
			aForm.ShowDialog();
		}

		private void btnCultureChs_Click(object sender, System.EventArgs e)
		{
			Form1 aForm = new Form1("zh-CHS");
			aForm.ShowDialog();		
		}
	}
}
