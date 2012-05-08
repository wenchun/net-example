using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MaskedTextBox
{
	/// <summary>
	/// MaskedTextBox ���K�n�y�z�C
	/// </summary>
	public class MaskedTextBox : System.Windows.Forms.TextBox
	{
		/// <summary>
		/// �]�p�u��һݪ��ܼơC
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaskedTextBox()
		{
			// �o�O Windows.Forms ���]�p�u��һݭn���I�s�C
			InitializeComponent();

			// TODO: �b InitializeComponent �I�s����[�J�����l�]�w
			

		}

		/// <summary>
		/// �M������ϥΤ����귽�C
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{
            // 
            // MaskedTextBox
            // 
            this.Name = "MaskedTextBox";
            this.Size = new System.Drawing.Size(176, 56);
            this.Text = "Hello";
        }
		#endregion
		
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
		  if (e.KeyChar == 13)
		  {
		    SelectNextControl(this, true, true, true, true);
		    e.Handled = true;
		  }
		}
	}
}
