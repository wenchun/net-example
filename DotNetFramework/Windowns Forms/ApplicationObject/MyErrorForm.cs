using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ApplicationObject
{
	/// <summary>
	/// Summary description for MyErrorForm.
	/// </summary>
	public class MyErrorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Button btnAbort;
		private System.Windows.Forms.TextBox txtErrorMessage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyErrorForm()
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
			this.btnIgnore = new System.Windows.Forms.Button();
			this.btnAbort = new System.Windows.Forms.Button();
			this.txtErrorMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnIgnore
			// 
			this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
			this.btnIgnore.Location = new System.Drawing.Point(72, 240);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(88, 32);
			this.btnIgnore.TabIndex = 1;
			this.btnIgnore.Text = "忽略";
			// 
			// btnAbort
			// 
			this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.btnAbort.Location = new System.Drawing.Point(176, 240);
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.Size = new System.Drawing.Size(80, 32);
			this.btnAbort.TabIndex = 2;
			this.btnAbort.Text = "終止";
			// 
			// txtErrorMessage
			// 
			this.txtErrorMessage.BackColor = System.Drawing.SystemColors.Info;
			this.txtErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtErrorMessage.Location = new System.Drawing.Point(0, 0);
			this.txtErrorMessage.Multiline = true;
			this.txtErrorMessage.Name = "txtErrorMessage";
			this.txtErrorMessage.ReadOnly = true;
			this.txtErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtErrorMessage.Size = new System.Drawing.Size(370, 216);
			this.txtErrorMessage.TabIndex = 3;
			this.txtErrorMessage.Text = "";
			this.txtErrorMessage.WordWrap = false;
			// 
			// MyErrorForm
			// 
			this.AcceptButton = this.btnIgnore;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.CancelButton = this.btnAbort;
			this.ClientSize = new System.Drawing.Size(370, 287);
			this.Controls.Add(this.txtErrorMessage);
			this.Controls.Add(this.btnAbort);
			this.Controls.Add(this.btnIgnore);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MyErrorForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "應用程式統一錯誤處理視窗";
			this.ResumeLayout(false);

		}
		#endregion

		public void SetError(Exception ex) 
		{
			ErrorMessage = ex.Message + "\r\n\r\n" + 
				"Stack trace: \r\n" + ex.StackTrace;
		}

		public string ErrorMessage 
		{
			get 
			{
				return txtErrorMessage.Text;
			}

			set 
			{
				txtErrorMessage.Text = value;
			}
		}
	}
}
