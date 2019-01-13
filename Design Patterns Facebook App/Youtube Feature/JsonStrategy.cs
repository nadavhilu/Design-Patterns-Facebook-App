using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Design_Patterns_Facebook_App
{
    public class JsonStrategy : ISerializingStrategy
    {
        private WrapperOfListOfYoutubeLinks m_YoutubeLinks = new WrapperOfListOfYoutubeLinks();

        private class WrapperOfListOfYoutubeLinks
        {
            [JsonProperty("Links:")]
            public List<string> Links { get; set; }
        }

        public void Serialize(string i_FilePath, List<string> i_DataToSerialize)
        {
            m_YoutubeLinks.Links = i_DataToSerialize;
            var finalizedObjectToSerialize = new WrapperOfListOfYoutubeLinks() { Links = i_DataToSerialize };
            var jsonResult = JsonConvert.SerializeObject(finalizedObjectToSerialize);
            File.WriteAllText(i_FilePath, jsonResult);
        }
    }
}
