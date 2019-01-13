using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    /// <summary>
    ///  This class will be used in the future as decorator for the Validator of Database. this decorator gives the database validator
    ///  the ability to log its conclusions into a log file.
    /// </summary>
    public class ValidatorOfDatabase : IValidatorOfDatabase
    {
        private string sr_ConnectionString = "Server = 104.236.120.156; Database = dp039525910; Uid = admin; Pwd = admin;";

        public bool CheckConnection()
        {
            MySqlConnection conn = new MySqlConnection(sr_ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e) { }
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
