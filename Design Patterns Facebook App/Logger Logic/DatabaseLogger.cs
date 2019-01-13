using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public class DatabaseLogger : AbstractLogger
    {
        protected override void SerializeLog(string i_MessageToLog)
        {
            if (UserSessionsDatabaseFacade.IsValidServerConnection)
            {
                /// log to database. TODO: create logger table for saving log data.
            }
        }

        protected override void WriteLogToConsole(string i_MessageToLog)
        {
            System.Console.WriteLine("File Logger Message:" + i_MessageToLog);
        }
    }
}
