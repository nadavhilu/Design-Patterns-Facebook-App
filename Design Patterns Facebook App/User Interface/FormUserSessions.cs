using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FacebookWrapper.ObjectModel;
using MaterialSkin;

/// <summary>
/// This Form is the User Sessions form which is responsible of showing the user information
/// about all of the users app sessions.
/// </summary>
/// 
namespace Design_Patterns_Facebook_App
{
    public partial class FormUserSessions : Form
    {
        private User m_LoggedInUser;
        private MaterialSkinManager m_SkinManager;

        public FormUserSessions(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;
            InitializeComponent();
        }

        private void FormUserSessions_Load(object sender, EventArgs e)
        {
            UserSessionDatabaseManager userSessionsManager = new UserSessionDatabaseManager(m_LoggedInUser, dataGridViewUserSessions);
            userSessionsManager.ManipulateDatabase(m_LoggedInUser, dataGridViewUserSessions);
        }
    }
}
