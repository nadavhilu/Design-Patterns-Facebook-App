using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Design_Patterns_Facebook_App
{
    public class YoutubePostsFeature : IFacebookFeature
    {
        private User m_LoggedInUser;
        private string m_SelectedVideo;

        public string SelectedVideo
        {
            get
            {
                return m_SelectedVideo;
            }

            set
            {
                m_SelectedVideo = value;
            }       
        }

        private List<ListViewItem> m_LoggedInUserListOfFacebookYoutubePosts;

        public List<ListViewItem> ListOfFacebookYoutubePosts
        {
            get
            {
                return m_LoggedInUserListOfFacebookYoutubePosts;
            }
        }

        public User LoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }

            set
            {
                if (value is User)
                {
                    m_LoggedInUser = value;
                }
            }
        }

        public static readonly string sr_FilterString = "www.youtube.com";

        public YoutubePostsFeature(User i_LoggedInUser)
        {
            this.m_LoggedInUser = i_LoggedInUser; 
            m_LoggedInUserListOfFacebookYoutubePosts = GetYoutubeLinksAsList(); 
        }

        public List<ListViewItem> GetYoutubeLinksAsList()
        {
            List<ListViewItem> listOfYoutubeLinks = new List<ListViewItem>();
            foreach (Status status in m_LoggedInUser.Statuses)
            {    
                if (status != null && status.Message != null)
                {
                    if (status.Message.Contains(sr_FilterString))
                    {
                        ListViewItem item = new ListViewItem(new string[] { status.Message, status.CreatedTime.ToString() });
                        listOfYoutubeLinks.Add(item);
                    }
                }
            }

            return listOfYoutubeLinks;
        }

        public List<ListViewItem> GetYoutubeLinksAsListView(User m_SelectedFriend)
        {           
            List<ListViewItem> listOfYoutubeLinks = new List<ListViewItem>();
  
            foreach (Post post in m_SelectedFriend.Posts)
            {
                if (post != null && post.Message != null)
                {
                    if (post.Message.Contains(sr_FilterString))
                    {
                        ListViewItem item = new ListViewItem(new string[] { post.Message, post.CreatedTime.ToString() });
                        listOfYoutubeLinks.Add(item);
                    }
                }
            }

            return listOfYoutubeLinks;
        }

        public string GetFeatureTitle()
        {
            return "YouTube Posts Feature";
        }
    }
}