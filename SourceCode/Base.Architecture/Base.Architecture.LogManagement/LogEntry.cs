using System;

namespace Base.Architecture.LogManagement
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public EntryException Exception { get; set; }

        public LogEntry()
        {
            DateTime = DateTime.Now;
        }

        public LogEntry(string message)
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
            Message = message;
        }

        public LogEntry(Exception exception)
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
            Message = exception.Message;
            Exception = new EntryException(exception);
        }

        public class EntryException
        {
            public string Type { get; set; }
            public string Source { get; set; }
            public string StackTrace { get; set; }

            public EntryException(Exception exception)
            {
                Type = exception.GetType().ToString();
                Source = exception.Source;
                StackTrace = exception.StackTrace;
            }
        }
    }
}
