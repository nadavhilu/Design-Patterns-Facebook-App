using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public enum eLogLevel
    {
        Debug = 1,
        Verbose = 2,
        Information = 3,
        Warning = 4,
        Error = 5,
        Critical = 6,
        None = int.MaxValue
    }
}