using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    public partial class FormApplicationBrowser : Form
    {
        private readonly string r_YoutubeLinkToPlay;

        public FormApplicationBrowser(string i_YoutubeLink)
        {
            InitializeComponent();
            r_YoutubeLinkToPlay = i_YoutubeLink;
            webBrowserYoutubeBrowserPlayer.Navigate(r_YoutubeLinkToPlay);         
        } 
    }
}
