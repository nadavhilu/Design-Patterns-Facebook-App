using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Design_Patterns_Facebook_App
{
    public class DownloadManager
    {
       public void SaveVideoToDisk(string i_YoutubeLink, string i_Path)
       {
            var youTube = YouTube.Default; // starting point for YouTube actions

            var video = youTube.GetVideo(i_YoutubeLink); // gets a Video object with info about the video

            File.WriteAllBytes(i_Path + video.FullName, video.GetBytes());
       }
     }
}
