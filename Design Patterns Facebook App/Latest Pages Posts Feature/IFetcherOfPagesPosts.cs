using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace Design_Patterns_Facebook_App
{
    public interface IFetcherOfPagesPosts
    {
        Dictionary<Page, List<Post>> GetDictionaryOfUserLikedPagesPosts(User i_FacebookUser);
    }
}