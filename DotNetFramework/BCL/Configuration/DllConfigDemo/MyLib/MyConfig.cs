using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyLib
{
    public class MyConfig
    {
        private AssemblySettings _settings = new AssemblySettings(Assembly.GetExecutingAssembly());

        public string UserName
        {
            get
            {
                return _settings["UserName"];
            }
        }
    }
}