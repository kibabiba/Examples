using NLog;

namespace SomeLibrary
{
    public static class MyLogger
    {
        public static void Write(string logFile, string logMessage)
        {
            NLog.Logger logger = LogManager.GetLogger(logFile);
            logger.Log(LogLevel.Info, logMessage);
        }
    }
}
