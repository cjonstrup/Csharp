namespace ConsoleApplication1.Provider.MyLogger
{
    public interface ILog
    {
        void Trace(string msg);
        void Debug(string msg);
        void Info(string msg);
        void Warn(string msg);
        void Error(string msg);
        void Fatal(string msg);
        void Log(string msg);
    }
}
