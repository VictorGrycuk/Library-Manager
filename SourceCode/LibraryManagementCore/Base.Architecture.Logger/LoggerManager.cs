using Base.Architecture.DatabaseManager;
using System;
using System.Collections.Generic;

namespace Base.Architecture.Logger
{
    public class LoggerManager : IDisposable
    {
        private readonly Dictionary<LogType, DBManager> _loggers = new Dictionary<LogType, DBManager>();

        public void AddNewLogger(DBManager dbManager, LogType logType)
        {
            try
            {
                _loggers.Add(logType, dbManager);
            }
            catch (Exception ex)
            {
                if (ex.Message == "An item with the same key has already been added.")
                {
                    throw new ArgumentException($"The LogType '{ logType.ToString() }' already has a logger associated");
                }

                throw;
            }
        }

        public void Remove(LogType logType)
        {
            Find(logType).Dispose();
            // add dispose
            _loggers.Remove(logType);
        }

        public bool Exists(LogType logType)
        {
            return _loggers.ContainsKey(logType);
        }

        public void Log<TLogEntry>(LogType logType, TLogEntry t) where TLogEntry : class, new()
        {
            Find(logType).NewTableConnection<TLogEntry>(logType.ToString()).Add(t);
        }

        public void Log(LogType logType, Exception exception)
        {
            Find(logType).NewTableConnection<LogEntry>(logType.ToString()).Add(new LogEntry(exception));
        }

        private DBManager Find(LogType logType)
        {
            try
            {
                return _loggers[logType];
            }
            catch (Exception ex)
            {
                if (ex.Message == "The given key was not present in the dictionary.")
                {
                    throw new ArgumentException($"There is no logger associated with '{ logType.ToString() }' LogType");
                }

                throw;
            }
        }

        public void Dispose()
        {
            foreach (var manager in _loggers)
            {
                manager.Value.Dispose();
            }
        }
    }

    public enum LogType
    {
        Audit,
        Error
    }
}
