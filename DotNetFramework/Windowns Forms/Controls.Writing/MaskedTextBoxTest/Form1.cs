using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
	/// <summary>
	/// Form1 ���K�n�y�z�C
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private MaskedTextBox.MaskedTextBox maskedTextBox1;
    private System.Windows.Forms.Button button1;
		/// <summary>
		/// �]�p�u��һݪ��ܼơC
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows Form �]�p�u��䴩�����n��
			//
			InitializeComponent();

			//
			// TODO: �b InitializeComponent �I�s����[�J����غc�禡�{���X
			//
		}

		/// <summary>
		/// �M������ϥΤ����귽�C
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
		/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.maskedTextBox1 = new MaskedTextBox.MaskedTextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(48, 64);
      this.textBox1.Name = "textBox1";
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "textBox1";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(48, 104);
      this.textBox2.Name = "textBox2";
      this.textBox2.TabIndex = 2;
      this.textBox2.Text = "textBox2";
      // 
      // maskedTextBox1
      // 
      this.maskedTextBox1.Location = new System.Drawing.Point(48, 24);
      this.maskedTextBox1.Name = "maskedTextBox1";
      this.maskedTextBox1.Size = new System.Drawing.Size(80, 22);
      this.maskedTextBox1.TabIndex = 3;
      this.maskedTextBox1.Text = "maskedTextBox1";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(176, 48);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(80, 24);
      this.button1.TabIndex = 4;
      this.button1.Text = "button1";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
      this.ClientSize = new System.Drawing.Size(296, 242);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.button1,
                                                                  this.maskedTextBox1,
                                                                  this.textBox2,
                                                                  this.textBox1});
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }
		#endregion

		/// <summary>
		/// ���ε{�����D�i�J�I�C
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

    private void button1_Click(object sender, System.EventArgs e)
    {
      textBox2.SelectNextControl(textBox1, false, false, false, true);
    }
	}
}
