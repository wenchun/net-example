using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace MyLib
{
	public class MyLicenseProvider : LicenseProvider
	{
		public MyLicenseProvider()
		{
		}

		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			/*
			 * 利用 context 參數的 UsageMode 屬性來判斷目前是在
			 * 設計時期，還是在執行時期. 這裡我們只在設計時期才
			 * 檢查元件的授權.
			 */
			if (context.UsageMode == LicenseUsageMode.Designtime) 
			{
				// 只單純的檢查元件所在的路徑是否有一個 MyLic.txt 檔案, 
				// 有的話就表示合法授權.
				FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().FullName);
				string fname = fi.DirectoryName + @"\MyLic.txt";				
				fi = new FileInfo(fname);
				if (fi.Exists) 
				{
					return new MyLicense();
				}
				else 
				{
					if (allowExceptions) 
					{
						throw new Exception("您尚未取得使用此元件的合法授權，請向 XX 公司洽詢!");
					}
					return null;
				}			   
			}
			else // 不需要檢查授權
			{
				return new MyLicense();
			}
		}

	}

	public class MyLicense : License
	{
		public override string LicenseKey
		{
			get
			{
				// 你應該修改這個實作，以提供應用程式唯一的授權碼
				return "123";
			}
		}

		public override void Dispose()
		{
		}
	}
}
