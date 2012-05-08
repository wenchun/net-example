using System;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using MSForms = Microsoft.Vbe.Interop.Forms;

// Office integration attribute. Identifies the startup class for the document. Do not modify.
[assembly:System.ComponentModel.DescriptionAttribute("OfficeStartupClass, Version=1.0, Class=WordProject1.OfficeCodeBehind")]

namespace WordProject1
{
	/// <summary>
	/// Contains managed code extensions for the document.
	/// </summary>
	public class OfficeCodeBehind
	{

		/// <summary>
		/// Application object.
		/// </summary>
		internal Word.Application ThisApplication
		{
			get { return thisApplication;}
		}

		/// <summary>
		/// Document object.
		/// </summary>
		internal Word.Document ThisDocument
		{
			get { return thisDocument;}
		}
        
		private Word.Application thisApplication = null;
		private Word.Document    thisDocument = null;

		private Word.DocumentEvents2_OpenEventHandler openEvent;
		private Word.DocumentEvents2_CloseEventHandler closeEvent;

		// Determines whether ActiveX controls will be set to
		// Run mode even if Word is in High security mode.
		// Set this variable to True if your solution uses
		// ActiveX controls.
		private bool toggleActiveXControls = false;
                                          
		#region Generated initialization code

		/// <summary>
		/// Default constructor.
		/// </summary>
		public OfficeCodeBehind()
		{
		}

		private bool designModeClose = false;

		/// <summary>
		/// Required procedure. Do not modify.
		/// </summary>
		/// <param name="application">Application object.</param>
		/// <param name="document">Document object.</param>
		public void _Startup(object application, object document)
		{
			this.thisApplication = application as Word.Application;
			this.thisDocument = document as Word.Document;

			openEvent = new Word.DocumentEvents2_OpenEventHandler (ThisDocument_Open);
			thisDocument.Open += openEvent;

			closeEvent = new Word.DocumentEvents2_CloseEventHandler(ThisDocument_Close);
			((Word.DocumentEvents2_Event)thisDocument).Close += closeEvent;

			// Check if the document is in Design mode.
			if (ThisDocument.FormsDesign == true)
			{
				// Set ActiveX controls to Run mode.
				if (toggleActiveXControls == true)
				{
					ThisDocument.ToggleFormsDesign();
				}

				// Check if the thisDocument is a document and not a template.
				if (thisDocument.Path != "")
				{
					// Set the shutdown procedure to use design mode and then call the Open handler.
					designModeClose = true;
					ThisDocument_Open();

					// Ensure that Open is not called twice.
					thisDocument.Open -= openEvent;
				}
			}
		}

		/// <summary>
		/// Required procedure. Do not modify.
		/// </summary>
		public void _Shutdown()
		{
			// If the document is in design mode, call the Close handler.
			if (designModeClose == true)
				ThisDocument_Close();

			thisApplication = null;
			thisDocument = null;
		}

		/// <summary>
		/// Finds the control with the specified name in ThisDocument.
		/// </summary>
		/// <param name='name'>Name of the control to find.</param>
		/// <returns>
		/// Returns the specified control, or null if it is not found.
		/// </returns>
		object FindControl(string name)
		{
			return FindControl(name, ThisDocument);
		}
 
		/// <summary>
		/// Returns the control with the specified name in the specified document.
		/// </summary>
		/// <param name='name'>Name of the control to find.</param>
		/// <param name='document'>Document object that contains the control.</param>
		/// <returns>Returns the specified control, or null if it is not found.
		/// </returns>
		object FindControl(string name, Word.Document document)
		{
			try
			{
				foreach (Word.InlineShape shape in document.InlineShapes)
				{
					if (shape.Type == Word.WdInlineShapeType.wdInlineShapeOLEControlObject)
					{
						object oleControl = shape.OLEFormat.Object;
						Type oleControlType = oleControl.GetType();
						string oleControlName = (string) oleControlType.InvokeMember("Name", 
							System.Reflection.BindingFlags.GetProperty, null, oleControl, null);
						if (String.Compare(oleControlName, name, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
						{
							return oleControl;
						}
					}
				}

				foreach (Word.Shape shape in document.Shapes)
				{
					if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoOLEControlObject)
					{
						object oleControl = shape.OLEFormat.Object;
						Type oleControlType = oleControl.GetType();
						string oleControlName = (string) oleControlType.InvokeMember("Name", 
							System.Reflection.BindingFlags.GetProperty, null, oleControl, null);
						if (String.Compare(oleControlName, name, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
						{
							return oleControl;
						}
					}
				}
			}
			catch
			{
				// Returns null if the control is not found.
			}
			return null;
		}

		#endregion

		/// <summary>
		/// Called when the document is opened.
		/// </summary>
		protected void ThisDocument_Open()
		{
			object missing = System.Type.Missing;
			object fname = @"C:\Temp\測試文件-複製.doc";

			thisDocument.SaveAs(ref fname, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing);	

			thisApplication.Selection.TypeText("Hello, WORD!");

			//Test(true);

		}

		private void Test(bool disableRefresh) 
		{
			object missing = System.Type.Missing;
			int x = 10;
			int y = 10;

			thisApplication.ScreenUpdating = !disableRefresh;
		
			DateTime beginTime = DateTime.Now;

			for (int i = 0; i < 200; i++) 
			{
				Word.Shape txtBox = thisDocument.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, x, y, 40, 30, ref missing);
				txtBox.TextFrame.TextRange.Font.Size = 8.0f;   //---字型大小
				//txtBox.Line.Visible = Office.MsoTriState.msoFalse;     //---文字方塊外框
				//txtBox.Fill.Transparency = 1.0f;                //---文字方塊透明度(0.0 ~ 1.0)
				txtBox.TextFrame.TextRange.Text = "文字 " + i.ToString();

				x += 50;
				if (x > 500) 
				{
					x = 10;
					y += 40;
				}
			}

			// 恢復螢幕更新.
			thisApplication.ScreenUpdating = true;

			TimeSpan diffTime = new TimeSpan(DateTime.Now.Ticks - beginTime.Ticks);
			thisApplication.Selection.TypeText("共花費時間: " + diffTime.ToString());

		}

		/// <summary>
		/// Called when the document is closed.
		/// </summary>
		protected void ThisDocument_Close()
		{
			// Ensure that Close is not called twice.
			designModeClose = false;
		}
	}
}
