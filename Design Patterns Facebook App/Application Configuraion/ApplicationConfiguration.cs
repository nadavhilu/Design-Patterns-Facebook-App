using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Design_Patterns_Facebook_App
{
    public class ApplicationConfiguration
    {   
        /// <summary>The user interface language of the application.</summary>
        public string ConnectionString { get; set; }

        public int NumberOfComplainsNeededForMail { get; set; }

        public int AmountOfLatestPostsFromEachPage { get; set; }

        public int MaximumNumberOfLatestPagesPostsElements { get; set; }

        public int MaximumNumberOfYoutubeElements { get; set; }

        public string AppOfficialEmail { get; set; }

        public string AppMainEmailPassword { get; set; }

        public string AppId { get; set; }

        public List<PluginConfiguration> Plugins { get; set; }

        public ApplicationConfiguration()
        {
            AppOfficialEmail = "dpappofficialmail@gmail.com"; 
            ConnectionString = "Server = 104.236.120.156; Database = dp039525910; Uid = admin; Pwd = admin; charset = utf8; ";
            AppId = "124737198162402";
            NumberOfComplainsNeededForMail = 5;
            MaximumNumberOfLatestPagesPostsElements = 20;
            MaximumNumberOfYoutubeElements = 20;
            AmountOfLatestPostsFromEachPage = 3;
            AppMainEmailPassword = "AppPassword";
            Plugins = new List<PluginConfiguration>();
        }  
    }

    public class PluginConfiguration
    {
        private string m_Path;

        public PluginConfiguration()
        {      
            m_Path = "";
        }

        [JsonProperty(PropertyName = "Path")]
        public string PathInFilesystem { get; set; }
    }
}
