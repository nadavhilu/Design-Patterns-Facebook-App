using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This enum is responsible for represnting the collection
/// of database tables exist on this application.
/// </summary>
/// 
namespace Design_Patterns_Facebook_App
{
    public enum eKindsOfDatabaseTables
    {
        UserSessions = 0,
        PagesPosts = 1,
        YoutubeLinks = 2
    }
}
