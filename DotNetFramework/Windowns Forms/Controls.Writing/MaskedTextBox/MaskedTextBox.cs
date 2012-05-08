using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MaskedTextBox
{
	/// <summary>
	/// MaskedTextBox 的摘要描述。
	/// </summary>
	public class MaskedTextBox : System.Windows.Forms.TextBox
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaskedTextBox()
		{
			// 這是 Windows.Forms 表單設計工具所需要的呼叫。
			InitializeComponent();

			// TODO: 在 InitializeComponent 呼叫之後加入任何初始設定
			

		}

		/// <summary>
		/// 清除任何使用中的資源。
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
		/// 此為設計工具支援所必需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
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
