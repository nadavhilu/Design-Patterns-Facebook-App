using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using Page = FacebookWrapper.ObjectModel.Page;

namespace Design_Patterns_Facebook_App
{
    public class LatestPagesPostsFeature : IFacebookFeature                                                             
    {
        private User m_LoggedInUser;
        private IFetcherOfPagesPosts m_ProxyOfPagesPosts;
        private Post m_SelectedPagePost;

        public Post SelectedPagePost
        {
            get
            {
                return m_SelectedPagePost;
            }

            set
            {
                m_SelectedPagePost = value;
            }
        }
     
        public LatestPagesPostsFeature(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_ProxyOfPagesPosts = new ProxyCacheOfPagesPosts();
        }

        public ProxyCacheOfPagesPosts ProxyOfPagesPosts
        {
            get
            {
                return m_ProxyOfPagesPosts as ProxyCacheOfPagesPosts;
            }

            set
            {
                m_ProxyOfPagesPosts = value;
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

        public string GetFeatureTitle()
        {
            return "YouTube Posts Feature";
        }
        
        public List<Post> GetListOfUserLikedPagesPosts(User i_ChosenUser)
        {
            return ProxyOfPagesPosts.GetListOfUserLikedPagesPosts(i_ChosenUser);
        }

        public void GetListViewItemsOfLikedPageLatestPosts(User i_SelectedUser, ref List<ListViewItem> io_ListOfPagesPostsListViewItems, string i_FilterString)
        {
            ProxyOfPagesPosts.GetListViewItemsOfLikedPageLatestPosts(i_SelectedUser, ref io_ListOfPagesPostsListViewItems, i_FilterString);
        }      
    }
}