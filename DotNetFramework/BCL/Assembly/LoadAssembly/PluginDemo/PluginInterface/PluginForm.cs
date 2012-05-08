using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PluginInterface
{
	// 基礎表單類別
	public class PluginForm : System.Windows.Forms.Form, IPlugin
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PluginForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			// 
			// PluginForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "PluginForm";
			this.Text = "PluginForm";

		}
		#endregion

		
	
		#region IPlugin Members

		public virtual void Initialize(object sender, object param)
		{
			
		}

		#endregion
	}
}
