using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public class SerializerCreator
    {
        public static ISerializingStrategy GetSerializer(eStrategies i_SerializerRequest)
        {
            switch (i_SerializerRequest)
            {
                case eStrategies.XmlSerializing:
                    return new XmlStrategy();
                case eStrategies.JsonSerializing:
                    return new JsonStrategy();

                default:
                    throw new NotImplementedException("This serializer does not exist!");
            }
        }
    }
}
