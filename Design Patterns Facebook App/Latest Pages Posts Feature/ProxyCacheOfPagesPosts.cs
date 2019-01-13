using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    /* This class serve as a proxy cache for the latest pages posts of a specific user. anytime data is not found in m_DictionaryOfPagesPosts, a "fetcher" is being used.
       a dictionary<FacebookUser, dictionary<Page, list<Post>>> saves this information and when client ask for latest pages posts it simply fetches the information
       from facebook server if and only if it does not exist in this dictionary.
    */
    public class ProxyCacheOfPagesPosts : IFetcherOfPagesPosts
    {
        private Dictionary<User, Dictionary<Page, List<Post>>> m_DictionaryOfPagesPosts = null;
        protected readonly object lockObj = new object();

        public ProxyCacheOfPagesPosts()
        {
            m_DictionaryOfPagesPosts = new Dictionary<User, Dictionary<Page, List<Post>>>();
        }

        /*
         * This method is used when the client wants to retrieve the latest pages posts of a specific User. first it checks whether this info exists in m_DictionaryOfPagesPosts
         if it does, then returns Dictionary<Page, List<Post>>, else it uses FetcherOfPagesPosts class to fetch info and right after that stores it in the cache.
         */
        public Dictionary<Page, List<Post>> GetDictionaryOfUserLikedPagesPosts(User i_ChosenUser)
        {
            Dictionary<Page, List<Post>> resultLikedPagesPosts = null;
            lock (lockObj)
            {
                if (m_DictionaryOfPagesPosts.Keys.Contains(i_ChosenUser))
                {
                    resultLikedPagesPosts = m_DictionaryOfPagesPosts[i_ChosenUser];
                }
                else
                {
                    FetcherOfPagesPosts fetcher = new FetcherOfPagesPosts();
                    m_DictionaryOfPagesPosts.Add(i_ChosenUser, fetcher.GetDictionaryOfUserLikedPagesPosts(i_ChosenUser));
                    resultLikedPagesPosts = m_DictionaryOfPagesPosts[i_ChosenUser];
                }
            }

            return resultLikedPagesPosts;
        }

        public void GetListViewItemsOfLikedPageLatestPosts(User i_SelectedFriend, ref List<ListViewItem> io_ListOfPagesPostsListViewItems, string i_FilterString)
        {
            Dictionary<Page, List<Post>> dictionaryOfLatestPosts = GetDictionaryOfUserLikedPagesPosts(i_SelectedFriend);
            io_ListOfPagesPostsListViewItems = new List<ListViewItem>();
            List<Post> listOfPosts = new List<Post>();
            foreach (Page page in dictionaryOfLatestPosts.Keys)
            {
                foreach (Post post in dictionaryOfLatestPosts[page])
                {
                    if (post != null && post.Name != null && post.Name.Contains(i_FilterString))
                    {
                        listOfPosts.Add(post);
                    }
                }
            }

            var sortedListOfPosts = from p in listOfPosts
                orderby p.CreatedTime descending
                select p;

            if (dictionaryOfLatestPosts != null)
            {
                foreach (Post post in sortedListOfPosts)
                {
                    if (post != null && post.Name != null && post.Name.Contains(i_FilterString))
                    {
                        ListViewItem item = new ListViewItem(new string[] { post.Name, post.CreatedTime.Value.ToString() });
                        io_ListOfPagesPostsListViewItems.Add(item);                           
                    }                   
                }
            }       
        }

        public List<Page> FetchListOfLikedPages(User i_FacebookUser)
        {
            List<Page> listOfLikedPages = new List<Page>();
            Dictionary<Page, List<Post>> dictionaryOfLatestPosts = GetDictionaryOfUserLikedPagesPosts(i_FacebookUser);
            foreach (Page page in dictionaryOfLatestPosts.Keys)
            {
                listOfLikedPages.Add(page);
            }

            return listOfLikedPages;
        }

        public List<Post> GetListOfUserLikedPagesPosts(User i_ChosenUser)
        {
            List<Post> resultListOfPosts = new List<Post>();
            Dictionary<Page, List<Post>> dictionaryOfLatestPosts = GetDictionaryOfUserLikedPagesPosts(i_ChosenUser);

            foreach (Page page in dictionaryOfLatestPosts.Keys)
            {
                foreach (Post post in dictionaryOfLatestPosts[page])
                {
                    resultListOfPosts.Add(post);
                }
            }

            return resultListOfPosts;
        }
    }
}
