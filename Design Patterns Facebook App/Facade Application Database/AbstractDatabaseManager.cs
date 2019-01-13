using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    public abstract class AbstractDatabaseManager
    {
        protected UserSessionsDatabaseFacade Facade { get; set; }

        public void ManipulateDatabase(User i_LoggedInUser, DataGridView i_dataGridViewUserSessions)
        {          
            Facade.OpenDatabaseConnection();
            PerformDbLogic();
            Facade.CloseDatabaseConnection();
        }

        public abstract void PerformDbLogic();
    }
}
