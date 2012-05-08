using System;
using System.Reflection;

namespace PluginInterface
{
	/// <summary>
	/// Plugin 介面
	/// </summary>
	public interface IPlugin
	{
		void Initialize(object sender, object param); 
	}

	/// <summary>
	/// 載入組件並建立表單物件的類別工廠
	/// </summary>
	public class PluginFactory
	{
		/// <summary>
		/// 建立 plugin：載入指定的 DLL，建立 form 類別的 instancel，並傳回
		/// 該類別實作的 IPlugin 介面。
		/// </summary>
		/// <param name="dllName">DLL 檔案名稱</param>
		/// <param name="className">Form 類別名稱，可指定全名或簡單名稱</param>
		/// <returns></returns>
		public static IPlugin CreatePlugin(string dllName, string className)
		{ 
			Assembly anAsm; 
			Type aType; 
			Type aPluginType; 
			object aObj; 
			IPlugin aPlugin; 
			anAsm = Assembly.LoadFrom(dllName); 
			if (className.IndexOf('.') >= 0) // 是否有指定類別全名？
			{ 
				aType = anAsm.GetType(className, false, true); 
			} 
			else // 沒有指定類別全名，以比對字串的方式尋找符合的類別名稱
			{ 
				aType = FindClass(anAsm, className); 
			} 
			if ((aType == null)) 
			{ 
				throw new Exception("無法建立視窗物件! 無此類別: " + className); 
			} 
			aPluginType = aType.GetInterface("IPlugin", true); 
			if ((aPluginType == null)) 
			{ 
				throw new Exception("Form 類別必須實作 IPlugin 介面。"); 
			} 
			aObj = Activator.CreateInstance(aType);
			aPlugin = (IPlugin)(aObj); 
			return aPlugin; 
		}

		// 使用部分名稱比對的方式尋找類別
		public static System.Type FindClass(Assembly asm, string className) 
		{ 
			Type[] aTypes; 
			aTypes = asm.GetTypes(); 
			foreach (Type aType in aTypes) 
			{ 
				if (className.IndexOf(aType.Name) >= 0) 
				{ 
					return aType; 
				} 
			} 
			return null; 
		}
	}
}
