using Base.Architecture.DatabaseManager;
using Base.Architecture.LoggerManager;
using System;
using System.Collections.Generic;

namespace Base.Architecture.Logger
{
    public class LoggerManager
    {
        public enum LogType
        {
            Audit,
            Error
        }

        private Dictionary<LogType, DBManager> _loggers = new Dictionary<LogType, DBManager>();

        public void AddNewLogger(DBManager dbManager, LogType logType)
        {
            _loggers.Add(logType, dbManager);
        }

        public void Log<TLogEntry>(LogType logType, TLogEntry t) where TLogEntry : class, new()
        {
            _loggers[logType].NewTableConnection<TLogEntry>(logType.ToString()).Add(t);
        }

        public void Log(LogType logType, Exception exception)
        {
            _loggers[logType].NewTableConnection<LogEntry>(logType.ToString()).Add(new LogEntry(exception));
        }
    }
}
