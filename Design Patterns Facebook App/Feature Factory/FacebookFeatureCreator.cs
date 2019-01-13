using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    /// <summary>
    /// Factory method for creating facebook features.
    /// </summary>
    public class FacebookFeatureCreator
    {
        public static IFacebookFeature CreateFacebookFeature(eKindsOfFacebookFeatures i_FeatureChoice, User i_LoggedInUser)
        {
            IFacebookFeature feature = null;

            switch (i_FeatureChoice)
            {
                case eKindsOfFacebookFeatures.LatestPagesPostsFeature:
                    feature = new LatestPagesPostsFeature(i_LoggedInUser);
                    break;
                case eKindsOfFacebookFeatures.YoutubePostsFeature:
                    feature = new YoutubePostsFeature(i_LoggedInUser);
                    break;
                default:
                    throw new NotImplementedException();                    
            }

            return feature;
        }
    }
}
