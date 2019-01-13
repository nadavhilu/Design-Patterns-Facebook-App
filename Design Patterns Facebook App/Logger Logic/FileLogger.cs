using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns_Facebook_App
{
    public class FileLogger : AbstractLogger
    {
        protected override void SerializeLog(string i_MessageToLog)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(m_FilePath, true))
                {
                    streamWriter.WriteLine(i_MessageToLog);
                    streamWriter.Close();
                }
            }
        }

        protected override void WriteLogToConsole(string i_MessageToLog)
        {
            System.Console.WriteLine("File Logger Message:"+i_MessageToLog);
        }
    }
}
