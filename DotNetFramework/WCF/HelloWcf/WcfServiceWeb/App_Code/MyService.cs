using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
public class MyService : IMyService
{
    public string GetTime()
    {
        return DateTime.Now.ToString();        
    }
}
