using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Design_Patterns_Facebook_App
{
    public class XmlStrategy : ISerializingStrategy
    {
        public List<string> LoadFromXml(string i_FilePath)
        {
            List<string> favoriteListOfYoutubeLinks = null;

            using (var stream = new StreamReader(i_FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                favoriteListOfYoutubeLinks = (List<string>)serializer.Deserialize(stream);
            }
         
            return favoriteListOfYoutubeLinks;
        }

        public void SaveToXml(string i_FilePath, List<string> i_ListOfLinks)
        {
            FileStream xmlFile = null;
            if(File.Exists(i_FilePath))
            {
                xmlFile = new FileStream(i_FilePath, FileMode.Truncate);
            }
            else
            {
                xmlFile = new FileStream(i_FilePath, FileMode.Create);
            }

            using (Stream stream = xmlFile)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(stream, i_ListOfLinks);
            }

            xmlFile.Dispose();
        }

        public void Serialize(string i_FilePath, List<string> i_ListOfLinks)
        {
            SaveToXml(i_FilePath, i_ListOfLinks);           
        }
    }
}
