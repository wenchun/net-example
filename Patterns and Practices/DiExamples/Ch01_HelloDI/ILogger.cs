using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_HelloDI
{
    public interface ILogger
    {
        void WriteEntry(string msg);
    }
}
