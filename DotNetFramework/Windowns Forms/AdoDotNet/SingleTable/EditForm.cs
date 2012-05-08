using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SingleTable
{
	/// <summary>
	/// Summary description for EditForm.
	/// </summary>
	public class EditForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCustomerID;
		private System.Windows.Forms.TextBox txtCompanyName;
		private System.Windows.Forms.TextBox txtContactName;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditForm()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCustomerID = new System.Windows.Forms.TextBox();
			this.txtCompanyName = new System.Windows.Forms.TextBox();
			this.txtContactName = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "CustomerID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "CompanyName";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 112);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "ContactName";
			// 
			// txtCustomerID
			// 
			this.txtCustomerID.Location = new System.Drawing.Point(120, 24);
			this.txtCustomerID.Name = "txtCustomerID";
			this.txtCustomerID.Size = new System.Drawing.Size(248, 25);
			this.txtCustomerID.TabIndex = 3;
			this.txtCustomerID.Tag = "CustomerID";
			this.txtCustomerID.Text = "";
			// 
			// txtCompanyName
			// 
			this.txtCompanyName.Location = new System.Drawing.Point(120, 64);
			this.txtCompanyName.Name = "txtCompanyName";
			this.txtCompanyName.Size = new System.Drawing.Size(248, 25);
			this.txtCompanyName.TabIndex = 4;
			this.txtCompanyName.Tag = "CompanyName";
			this.txtCompanyName.Text = "";
			// 
			// txtContactName
			// 
			this.txtContactName.Location = new System.Drawing.Point(120, 104);
			this.txtContactName.Name = "txtContactName";
			this.txtContactName.Size = new System.Drawing.Size(248, 25);
			this.txtContactName.TabIndex = 5;
			this.txtContactName.Tag = "ContactName";
			this.txtContactName.Text = "";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(81, 176);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(112, 32);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "確定";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(201, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 32);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "取消";
			// 
			// EditForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(394, 231);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtContactName);
			this.Controls.Add(this.txtCompanyName);
			this.Controls.Add(this.txtCustomerID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EditForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新增/修改";
			this.ResumeLayout(false);

		}
		#endregion

		public Control FindControlByTag(Control container, object tag)
		{
			foreach (Control ctrl in container.Controls)
			{
				if ((tag != null) && (tag.Equals(ctrl.Tag)))
					return ctrl;
			}
			return null;
		} 		

		public string GetValue(string fieldName) 
		{
			TextBox txt = FindControlByTag(this, fieldName) as TextBox;
			if (txt != null) 
			{
				return txt.Text; 
			}
			return "";
		}

		public void SetValue(string fieldName, string fieldValue) 
		{
			TextBox txt = FindControlByTag(this, fieldName) as TextBox;
			if (txt != null) 
			{
				txt.Text = fieldValue; 
			}
		}
	}
}
