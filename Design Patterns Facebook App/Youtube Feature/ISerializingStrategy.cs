using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public interface ISerializingStrategy
    {
        void Serialize(string i_FilePath, List<string> i_DataToSerialize);
    }
}
