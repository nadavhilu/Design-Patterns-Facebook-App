using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    /// <summary>
    ///  This class will be used in the future as decorator for the Validator of Database. this decorator gives the database validator
    ///  the ability to log its conclusions into a log file.
    ///  The DB facade should use this logic in those classes for the initial connection stage
    /// </summary>
    public class ValidatorOfDatabaseWithLogger : IValidatorOfDatabase
    {
        private IValidatorOfDatabase m_DatabaseValidator;
        private FileLogger m_FileLogger = new FileLogger();

        public ValidatorOfDatabaseWithLogger()
        {
            m_DatabaseValidator = new ValidatorOfDatabase();
        }

        public bool CheckConnection()
        {
            if (m_DatabaseValidator.CheckConnection())
            {
                m_FileLogger.Log("Log Written: Connected Established:" + DateTime.Now + "Log Level:" + eLogLevel.Information);
                return true;
            }
            else
            {
                m_FileLogger.Log("Log Written: DB Connection Failed. " + DateTime.Now + "Log Level:" + eLogLevel.Critical);
                return false;
            }
        }
    }
}
