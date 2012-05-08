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
			 * �Q�� context �Ѽƪ� UsageMode �ݩʨӧP�_�ثe�O�b
			 * �]�p�ɴ��A�٬O�b����ɴ�. �o�̧ڭ̥u�b�]�p�ɴ��~
			 * �ˬd���󪺱��v.
			 */
			if (context.UsageMode == LicenseUsageMode.Designtime) 
			{
				// �u��ª��ˬd����Ҧb�����|�O�_���@�� MyLic.txt �ɮ�, 
				// �����ܴN��ܦX�k���v.
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
						throw new Exception("�z�|�����o�ϥΦ����󪺦X�k���v�A�ЦV XX ���q����!");
					}
					return null;
				}			   
			}
			else // ���ݭn�ˬd���v
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
				// �A���ӭק�o�ӹ�@�A�H�������ε{���ߤ@�����v�X
				return "123";
			}
		}

		public override void Dispose()
		{
		}
	}
}
