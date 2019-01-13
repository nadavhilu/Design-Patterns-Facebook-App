using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  This interface is the base polymorphism tool for the factory method pattern which is responsible for
///  returning a specific IFacebookFeature instance
/// </summary>
/// 
namespace Design_Patterns_Facebook_App
{
    public interface IFacebookFeature
    {
        string GetFeatureTitle();

        User LoggedInUser { get; set; }
    }
}
