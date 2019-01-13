using FacebookWrapper.ObjectModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Patterns_Facebook_App
{
    /* This class isa facade for the user sessions database. instead of directly interact with the different subsystem classes regarding the mysql API
       A simple interface is provided to make it easier for the developer to query the db*/
    public class UserSessionsDatabaseFacade
    {
        private ApplicationConfiguration m_Configuration;
        public IValidatorOfDatabase m_DatabaseValidator { get; private set; }

        private FileLogger m_Logger = new FileLogger();

        private MySqlConnection m_DatabaseConnection = null;

        private MySqlDataAdapter m_ConnectionAdapter = null;

        private DataGridView m_DatabaseUIControl = null;

        private string m_CurrentSqlCommand = null;

        private User m_LoggedInUser;

        public static bool IsValidServerConnection { get; private set; }

        public UserSessionsDatabaseFacade(User i_LoggedInUser, DataGridView i_UIComponent)
        {
            m_LoggedInUser = i_LoggedInUser;
            m_DatabaseUIControl = i_UIComponent;
            m_DatabaseValidator = new ValidatorOfDatabaseWithLogger();          
            m_Configuration = new ApplicationConfiguration();

            if (m_DatabaseValidator.CheckConnection())
            {
                IsValidServerConnection = true;
            }
        }

        public UserSessionsDatabaseFacade(User i_LoggedInUser)
        {
            m_Configuration = new ApplicationConfiguration();
            m_DatabaseValidator = new ValidatorOfDatabaseWithLogger();
            m_LoggedInUser = i_LoggedInUser;
            m_DatabaseUIControl = null;

            if (m_DatabaseValidator.CheckConnection())
            {
                IsValidServerConnection = true;
            }
        }

        public void SetQueryCommand(eKindsOfDatabaseTables i_CommandType)
        {
            switch (i_CommandType)
            {
                case eKindsOfDatabaseTables.UserSessions:
                    m_CurrentSqlCommand = "select * from sessions";
                    break;

                case eKindsOfDatabaseTables.YoutubeLinks:
                    m_CurrentSqlCommand = "select * from youtubelinks";
                    break;
                case eKindsOfDatabaseTables.PagesPosts:
                    m_CurrentSqlCommand = "select * from pagesposts";
                    break;

                default:
                    throw new NotImplementedException("invalid command");
            }
        }

        public DataGridView DatabaseUIControl
        {
            get
            {
                return m_DatabaseUIControl;
            }

            set
            {
                if (value is DataGridView)
                {
                    m_DatabaseUIControl = value;
                }
                else
                {
                    throw new Exception("Trying to assign a non data grid view control is not allowed.");
                }
            }
        }

        public void OpenDatabaseConnection()
        {
            m_DatabaseConnection = new MySqlConnection("Server = 104.236.120.156; Database = dp039525910; Uid = admin; Pwd = admin; charset=utf8;");
            m_DatabaseConnection.Open();
           
            m_Logger.Log("Log Written: Connected Established In" + DateTime.Now + "Log Level:" + eLogLevel.Information);
            // 104.236.120.156 is a mysql server rent in DigitalOcean.com afor this facebook desktop app. db039525910 is a db for app-user-sessions storage 
            // aka saves all app users activities 
        }

        public void QueryDatabase(string i_DatabaseQuery)
        {
            m_ConnectionAdapter = new MySqlDataAdapter()
            {
                SelectCommand = new MySqlCommand(i_DatabaseQuery, m_DatabaseConnection)
            };
            m_Logger.Log("Log Written: Query In" + DateTime.Now + "Log Level:" + eLogLevel.Information);
        }

        public void UpdateSessionsTable(string i_Username)
        {
            m_DatabaseConnection = new MySqlConnection("Server = 104.236.120.156; Database = dp039525910; Uid = admin; Pwd = admin; charset=utf8;");
            m_DatabaseConnection.Open();
            MySqlCommand command = m_DatabaseConnection.CreateCommand();

            command.CommandText = "INSERT INTO sessions (Date, name) VALUES (?Date, ?name)";
            command.Parameters.AddWithValue("?name", i_Username);
            command.Parameters.AddWithValue("?Date", DateTime.Now);
            command.ExecuteNonQuery();
        }

        public void UpdateYoutubeTable(string i_Username, string i_YoutubeLink)
        {
            m_DatabaseConnection = new MySqlConnection("Server = 104.236.120.156; Database = dp039525910; Uid = admin; Pwd = admin; charset=utf8;");
            m_DatabaseConnection.Open();
            MySqlCommand command = m_DatabaseConnection.CreateCommand();
            command.CommandText = "INSERT INTO youtubelinks (username, youtubelink) VALUES (?username, ?link)";
            command.Parameters.AddWithValue("?username", i_Username);
            command.Parameters.AddWithValue("?link", i_YoutubeLink);
            command.ExecuteNonQuery();
            m_Logger.Log("Log Written: DB Update Established In" + DateTime.Now + "Log Level:" + eLogLevel.Information);
        }

        public void UpdatePagesPostsTable(string i_PagePost, string i_Likes)
        {
            MySqlCommand command = m_DatabaseConnection.CreateCommand();
            command.CommandText = "INSERT INTO pagesposts (post, likes) VALUES (?post, ?likes)";
        //    command.Parameters.AddWithValue("?username", i_Username);
            command.Parameters.AddWithValue("?post", i_PagePost.Substring(0, 10));
         //   MessageBox.Show(i_Likes.ToString());
            System.Console.WriteLine(":" + i_Likes + ":");
            command.Parameters.AddWithValue("?likes", i_Likes);
            command.ExecuteNonQuery();
        }

        public void UpdatePagesPostsTableComplains(Post i_PagePost)
        {    
            OpenDatabaseConnection();
            MySqlCommand command = new MySqlCommand();
            command = m_DatabaseConnection.CreateCommand();
         //   if (IsRowExist(i_PagePost))
         //   { }
            command.CommandText = "INSERT INTO pagesposts (id, post, complains) VALUES (?id, ?post, ?complains) ON DUPLICATE KEY UPDATE complains = complains + 1";
            //    command.Parameters.AddWithValue("?username", i_Username);
            command.Parameters.AddWithValue("?post", i_PagePost.Name);
            command.Parameters.AddWithValue("?id", i_PagePost.Id.ToString());
            command.Parameters.AddWithValue("?complains", 1);
            command.ExecuteNonQuery();
        }

        public bool IsRowExist(Post i_Key)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                OpenDatabaseConnection();
                cmd.Connection = m_DatabaseConnection;
                cmd.CommandText = @"SELECT EXISTS(SELECT 1 FROM pagesposts WHERE id=@id)";
                cmd.Parameters.AddWithValue("id", i_Key.Id);
                var result = cmd.ExecuteScalar();

                if (result.ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //result will be 1 if it exists, and 0 if it does not..
            }
        }

        public Boolean IsPagesPostsTableMailTime(Post i_PagePost)
        {
            string postAmount;
            
            string queryStr = "select complains" + " from pagesposts where id=@theId";

            MySqlCommand cmd = new MySqlCommand(queryStr, m_DatabaseConnection);
            cmd.Parameters.AddWithValue("@theId", i_PagePost.Id);

            OpenDatabaseConnection();
            var queryResult = cmd.ExecuteScalar();
            postAmount = Convert.ToString(queryResult);
            if (Int32.Parse(postAmount) == m_Configuration.NumberOfComplainsNeededForMail)
            {              
                return true;
            }
            else
            {
                postAmount = "";
                return false;
            }         
        }

        public void DatabaseManipulation()
        {
            try
            {
                QueryDatabase(m_CurrentSqlCommand);
                if (m_DatabaseUIControl != null)
                {
                    UpdateFormControls();
                }
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void UpdateFormControls()
        {
            DataTable table = new DataTable();
            m_ConnectionAdapter.Fill(table);
            BindingSource bSource = new BindingSource()
            {
                DataSource = table
            };
            DatabaseUIControl.DataSource = bSource;
        }

        public void CloseDatabaseConnection()
        {
            m_DatabaseConnection.Close();
        }
    }
}
