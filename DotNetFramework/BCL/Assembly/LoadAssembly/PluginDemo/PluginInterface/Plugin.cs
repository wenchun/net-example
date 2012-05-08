using System;
using System.Reflection;

namespace PluginInterface
{
	/// <summary>
	/// Plugin ����
	/// </summary>
	public interface IPlugin
	{
		void Initialize(object sender, object param); 
	}

	/// <summary>
	/// ���J�ե�ëإߪ�檫�����O�u�t
	/// </summary>
	public class PluginFactory
	{
		/// <summary>
		/// �إ� plugin�G���J���w�� DLL�A�إ� form ���O�� instancel�A�öǦ^
		/// �����O��@�� IPlugin �����C
		/// </summary>
		/// <param name="dllName">DLL �ɮצW��</param>
		/// <param name="className">Form ���O�W�١A�i���w���W��²��W��</param>
		/// <returns></returns>
		public static IPlugin CreatePlugin(string dllName, string className)
		{ 
			Assembly anAsm; 
			Type aType; 
			Type aPluginType; 
			object aObj; 
			IPlugin aPlugin; 
			anAsm = Assembly.LoadFrom(dllName); 
			if (className.IndexOf('.') >= 0) // �O�_�����w���O���W�H
			{ 
				aType = anAsm.GetType(className, false, true); 
			} 
			else // �S�����w���O���W�A�H���r�ꪺ�覡�M��ŦX�����O�W��
			{ 
				aType = FindClass(anAsm, className); 
			} 
			if ((aType == null)) 
			{ 
				throw new Exception("�L�k�إߵ�������! �L�����O: " + className); 
			} 
			aPluginType = aType.GetInterface("IPlugin", true); 
			if ((aPluginType == null)) 
			{ 
				throw new Exception("Form ���O������@ IPlugin �����C"); 
			} 
			aObj = Activator.CreateInstance(aType);
			aPlugin = (IPlugin)(aObj); 
			return aPlugin; 
		}

		// �ϥγ����W�٤�諸�覡�M�����O
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
