using NLog;

namespace ConsoleApplication1.Provider.MyLogger.NLog
{
    public class NLogProvider : ILog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }

        public void Fatal(string msg)
        {
            logger.Fatal(msg);
        }

        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Log(string msg)
        {
            logger.Log(LogLevel.Info,msg);
        }

        public void Trace(string msg)
        {
            logger.Trace(msg);
        }

        public void Warn(string msg)
        {
            logger.Warn(msg);
        }
    }
}
