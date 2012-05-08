using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel=Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace CSharp4Demo
{
    /// <summary>
    /// 練習此範例時，你必須：
    ///   - 加入 COM 組件參考: Microsoft Excel 12.0 Object Library.
    ///   - 使用 namespace 別名: using Excel=Microsoft.Office.Interop.Excel;
    /// </summary>
    class DemoComInterop
    {
        public static void Run()
        {
            var excel = new Excel.Application();
            excel.Visible = true;
            excel.Workbooks.Add(Type.Missing);

            // C# 2008 必須這樣寫 (C# 2010 也支援):
            //excel.get_Range("A1", Type.Missing).Value2 = "處理序名稱";
            //excel.get_Range("B1", Type.Missing).Value2 = "記憶體配置";

            // C# 2010 寫法更簡潔，可以省略一些參數:
            excel.Range["A1"].Value2 = "處理序名稱";
            excel.Range["B1"].Value2 = "處理序名稱";

            var processes = Process.GetProcesses()
                    .OrderByDescending(p => p.WorkingSet64)
                    .Take(10);

            int i = 2;
            foreach (var p in processes)
            {
                excel.Range["A" + i].Value = p.ProcessName;
                excel.Range["B" + i].Value = p.WorkingSet64;
                i++;
            }
        }
    }
}
