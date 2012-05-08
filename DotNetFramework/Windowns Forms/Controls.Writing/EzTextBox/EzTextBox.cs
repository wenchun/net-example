using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace EzTextBox
{
	/// <summary>
	/// Summary description for EzTextBox.
	/// </summary>
	[ToolboxBitmap(typeof(TextBox), "EzTextBox.bmp")]
	public class EzTextBox : System.Windows.Forms.TextBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EzTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         if (e.KeyChar == 13)
         {
            SendKeys.Send("{TAB}");
            e.Handled = true;
         }
      }
	}
}
