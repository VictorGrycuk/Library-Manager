using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Architecture.LoggerManager
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

        public LogEntry()
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
        }

        public LogEntry(Exception exception)
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
            Message = exception.Message;
            Source = exception.Source;
            StackTrace = exception.StackTrace;
        }
    }
}
