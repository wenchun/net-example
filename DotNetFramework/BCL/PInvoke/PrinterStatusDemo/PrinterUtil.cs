using System;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace PrinterStatusDemo
{
	/// <summary>
	/// Summary description for PrinterUtil.
	/// </summary>
	public class PrinterUtil
	{
		private PrinterUtil()
		{
		}

		[DllImport("winspool.drv", 
			 EntryPoint="OpenPrinterW", 
			 CharSet=CharSet.Auto, 
			 SetLastError=true, 
			 ExactSpelling=true, 
			 CallingConvention=CallingConvention.StdCall) 
		] 
		private static extern bool OpenPrinter( 
			string pPrinterName, // printer or server name 
			ref IntPtr hPrinter, // printer or server handle 
			IntPtr pDefault // printer defaults 
			); 

		[DllImport("winspool.drv", 
			 CharSet=CharSet.Auto, 
			 SetLastError=true, 
			 ExactSpelling=true, 
			 CallingConvention=CallingConvention.StdCall) 
		] 
		private static extern bool ClosePrinter( 
			IntPtr hPrinter // handle to printer 
			); 


		[DllImport("winspool.drv", 
			 EntryPoint="GetPrinterW", 
			 CharSet=CharSet.Auto, 
			 SetLastError=true, 
			 ExactSpelling=true, 
			 CallingConvention=CallingConvention.StdCall) 
		] 
		private static extern bool GetPrinter( 
			IntPtr hPrinter, // handle to printer 
			int dwLevel, // information level 
			IntPtr pPrinter, // printer information buffer 
			int cbBuf, // size of buffer 
			ref int pcbNeeded // bytes received or required 
			); 


		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)] 
			public struct PRINTER_INFO_2 
		{ 
			public string pServerName; 
			public string pPrinterName; 
			public string pShareName; 
			public string pPortName; 
			public string pDriverName; 
			public string pComment; 
			public string pLocation; 
			public IntPtr  pDevMode; 
			public string pSepFile; 
			public string pPrintProcessor; 
			public string pDatatype; 
			public string pParameters; 
			public IntPtr pSecurityDescriptor; 
			public uint Attributes; 
			public uint Priority; 
			public uint DefaultPriority; 
			public uint StartTime; 
			public uint UntilTime; 
			public uint Status; 
			public uint cJobs; 
			public uint AveragePPM; 
		} 

		private static uint mStatus; 
		private static uint mJobs; 
		private static string mDriver; 
		private static string mDevice; 
		private static string mPort; 

		public static void GetPrinterInfo(string sName) 
		{ 
			try 
			{ 
				IntPtr hPrinter = IntPtr.Zero; 
				IntPtr pPrinterInfo = IntPtr.Zero; 

				if ( !OpenPrinter( sName, ref hPrinter, IntPtr.Zero ) ) 
				{ 
					Marshal.ThrowExceptionForHR( 
						System.Runtime.InteropServices.Marshal.GetHRForLastWin32Error() ); 
				} 

				try 
				{ 
					int iNeed = -1; 

					// Get the number of bytes needed. 
					GetPrinter(hPrinter, 2, IntPtr.Zero, 0, ref iNeed); 

					// Allocate enough memory. 
					pPrinterInfo = Marshal.AllocHGlobal(iNeed); 

					int SizeOf = iNeed; 


					if ( !GetPrinter(hPrinter, 2, pPrinterInfo, SizeOf, ref iNeed) ) 
					{ 
						Marshal.ThrowExceptionForHR( 
							System.Runtime.InteropServices.Marshal.GetHRForLastWin32Error()); 
					} 

					// Now marshal the structure manually. 
					PRINTER_INFO_2 PrinterInfo = (PRINTER_INFO_2) Marshal.PtrToStructure(pPrinterInfo, 
						typeof(PRINTER_INFO_2)); 

					mStatus = PrinterInfo.Status; 
					mJobs = PrinterInfo.cJobs; 
					mDriver = PrinterInfo.pDriverName; 
					mDevice = PrinterInfo.pPrinterName; 
					mPort = PrinterInfo.pPortName; 
				} 
				catch (Exception exp) 
				{ 
					throw exp; 
				} 
				finally 
				{ 
					// Close the printer object. 
					ClosePrinter(hPrinter); 

					// Deallocate the memory. 
					Marshal.FreeHGlobal(pPrinterInfo); 
				} 
			} 
			catch (Exception exp) 
			{ 
				throw exp; 
			} 
		} 

		public static void CheckPrinter() 
		{
			PrintDocument pd = new PrintDocument();
			PrinterUtil.GetPrinterInfo(pd.PrinterSettings.PrinterName);
		}

	}
}
