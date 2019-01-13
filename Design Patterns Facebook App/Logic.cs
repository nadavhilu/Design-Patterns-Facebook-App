using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace Design_Patterns_Facebook_App
{
    public class Logic
    {
        public ApplicationConfiguration m_Configuration;
        private const string k_DefaultAppID = "124737198162402";
        private User m_SelectedFriend;

        public User SelectedFriend
        {
            get
            {
                return m_SelectedFriend;
            }

            set
            {
                m_SelectedFriend = value;
            }
        }

        /*
         * Facebook permissions required for this application:
         */
        #region Facebook Permissions
        private static readonly string[] sr_RequiredPermissions =
        {
            "user_friends",
            "user_videos",
            "public_profile",
            "user_likes",
            "user_actions.music",
            "user_actions.news",
            "user_actions.video",
        };
        #endregion

        private string m_ChosenAppID = null; // Facebook Application ID
        private User m_LoggedInUser;

        public bool IsLoggedIn { get; private set; }

        public YoutubePostsFeature YoutubePostsFeature { get; private set; }

        public LatestPagesPostsFeature LatestPagesPostsFeature { get; private set; }

        public User GetLoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }
        }

        public string ChosenAppID
        {
            get
            {
                return m_ChosenAppID;
            }

            set
            {
                m_ChosenAppID = value;
            }
        }

        public Logic()
        {
            m_ChosenAppID = k_DefaultAppID;
        }

        public bool Login()
        {
            bool isLoginSucceeded = false;
            IsLoggedIn = false;
            LoginResult result = FacebookService.Login(m_ChosenAppID, sr_RequiredPermissions);
            isLoginSucceeded = !string.IsNullOrEmpty(result.AccessToken);

            if (isLoginSucceeded)
            {
                m_Configuration = JsonApplicationConfiguration.Load<ApplicationConfiguration>("Config");
                IsLoggedIn = true;
                m_LoggedInUser = result.LoggedInUser;
                YoutubePostsFeature = FacebookFeatureCreator.CreateFacebookFeature(eKindsOfFacebookFeatures.YoutubePostsFeature, m_LoggedInUser) as YoutubePostsFeature;
                LatestPagesPostsFeature = FacebookFeatureCreator.CreateFacebookFeature(eKindsOfFacebookFeatures.LatestPagesPostsFeature, m_LoggedInUser) as LatestPagesPostsFeature;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }

            return isLoginSucceeded;
        }
    }
}
