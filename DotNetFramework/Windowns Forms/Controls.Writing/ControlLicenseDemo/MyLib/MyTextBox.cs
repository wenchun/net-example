using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace MyLib
{
	[LicenseProvider(typeof(MyLicenseProvider))]
	public class MyTextBox : TextBox
	{
		private MyLicense lic;

		public MyTextBox()
		{
			lic = (MyLicense) LicenseManager.Validate(typeof(MyTextBox), this);

			this.BackColor = Color.Yellow;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (lic != null)
				{
					lic.Dispose();
					lic = null;
				}
			}
			base.Dispose(disposing);
		}
	}
}
