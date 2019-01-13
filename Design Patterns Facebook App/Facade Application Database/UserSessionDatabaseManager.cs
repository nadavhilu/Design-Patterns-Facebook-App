using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    public class UserSessionDatabaseManager : AbstractDatabaseManager
    {
        private User m_LoggedInUser;

        public UserSessionDatabaseManager(User i_LoggedInUser, DataGridView i_DataGridForDb)
        {
            Facade = new UserSessionsDatabaseFacade(i_LoggedInUser, i_DataGridForDb);
            m_LoggedInUser = i_LoggedInUser;
        }

        public override void PerformDbLogic()
        {
            Facade.SetQueryCommand(eKindsOfDatabaseTables.UserSessions);
            Facade.UpdateSessionsTable(m_LoggedInUser.Name);
            Facade.DatabaseManipulation();
        }
    }
}