using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public enum eStrategies
    {
        /// <summary>
        /// XmlSerializing For choosing save to xml file option
        /// </summary>
        XmlSerializing = 0,

        /// <summary>
        /// JsonSerializing For choosing save to json file option
        /// </summary>
        JsonSerializing = 1
    }
}
