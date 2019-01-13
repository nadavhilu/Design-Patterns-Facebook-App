namespace Design_Patterns_Facebook_App
{
    public abstract class AbstractLogger // TODO: Make Logger Singleton, Make Template Method Pattern that forces such behavour:
    {
        public string m_FilePath = @"FacebookManagerLog.log";
        protected readonly object lockObj = new object();

        public void Log(string i_MessageToLog)
        {
            SerializeLog(i_MessageToLog);
            WriteLogToConsole(i_MessageToLog);
        }

        protected abstract void WriteLogToConsole(string i_MessageToLog);

        protected abstract void SerializeLog(string i_MessageToLog);
    }
}