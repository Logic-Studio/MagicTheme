using System;
namespace MagicTheme.Utils.Loggers
{
    public enum LogLevel
    {
        Debug = 1,
        Info = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5,
    }
    public interface ILogger
    {
        string ClassTag { get; set; }
        void Debug(string format, params object[] args);
        void Info(string format, params object[] args);
        void Warning(string format, params object[] args);
        void Error(string format, params object[] args);
        void Exception(Exception ex);
        void Log(LogLevel level, string format, params object[] args);
    }
}
