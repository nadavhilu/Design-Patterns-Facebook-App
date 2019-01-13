using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Design_Patterns_Facebook_App.LatestPagesPostsFeature;
using Page = FacebookWrapper.ObjectModel.Page;

namespace Design_Patterns_Facebook_App
{
    public class FetcherOfPagesPosts : IFetcherOfPagesPosts 
    {
        private static readonly int sr_AmountOfLatestPostsFromEachPage = 3;

        private List<Page> fetchListOfLikedPages(User i_FacebookUser)
        {
            List<Page> listOfLikedPages = new List<Page>();
            foreach (Page page in i_FacebookUser.LikedPages)
            {
                listOfLikedPages.Add(page);
            }

            return listOfLikedPages;
        }

        public List<Post> FetchLatestPagePosts(Page i_Page)
        {
            List<Post> listOfPosts = i_Page.Posts.OrderByDescending(specificDateOfItem => specificDateOfItem.CreatedTime.Value).ToList();
            var listOfLatestPosts = listOfPosts.Take(sr_AmountOfLatestPostsFromEachPage).ToList();

            return (List<Post>)listOfLatestPosts;
        }

        public Dictionary<Page, List<Post>> GetDictionaryOfUserLikedPagesPosts(User i_SelectedFriend)
        {
            List<Page> listOfLikedPages = fetchListOfLikedPages(i_SelectedFriend);
            List<Post> specificPagePosts;
            Dictionary<Page, List<Post>> dictionaryOfLikedPagesLatestPosts = new Dictionary<Page, List<Post>>();

            if (listOfLikedPages != null)
            {
                foreach (Page page in i_SelectedFriend.LikedPages)
                {
                    specificPagePosts = FetchLatestPagePosts(page); /* fetching the X latest posts of a specific page */
                    dictionaryOfLikedPagesLatestPosts.Add(page, specificPagePosts);
                }
            }

            return dictionaryOfLikedPagesLatestPosts;
        }
    }
}
