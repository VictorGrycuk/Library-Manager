using System;
using Base.Architecture.DatabaseManager;
using Base.Architecture.Logger;
using System.IO;
using Xunit;
using Xunit.Sdk;

namespace Base.Architecture.Tests
{
    public class LoggerTests
    {
        private readonly string _baseFolder;
        private readonly string _db;

        public LoggerTests()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
            {
                _baseFolder = directoryInfo.FullName;
            }

            _db = this + ".db";
        }

        [Fact]
        public void Using_Different_LogTypes_Should_Create_Different_Logs()
        {
            var loggerManager = new LoggerManager();
            var primaryDB = Path.Combine(_baseFolder, "primaryDB.db");
            var secondaryDB = Path.Combine(_baseFolder, "secondaryDB.db");

            loggerManager.AddNewLogger(new DBManager(primaryDB), LogType.Audit);
            loggerManager.Log(LogType.Audit, new LogEntry("Test Message") );

            loggerManager.AddNewLogger(new DBManager(secondaryDB), LogType.Error);
            loggerManager.Log(LogType.Error, new Exception("Test Message") );

            Assert.True(File.Exists(primaryDB));
            Assert.True(File.Exists(secondaryDB));

            loggerManager.Dispose();
            File.Delete(primaryDB);
            File.Delete(secondaryDB);
        }

        [Fact]
        public void Removing_Invalid_LogType_Should_Be_Controller()
        {
            var loggerManager = new LoggerManager();
            var ex = Assert.Throws<ArgumentException>(() => loggerManager.Log(LogType.Audit, new Exception("Test Message")));

            Assert.Equal(ex.Message, $"There is no logger associated with '{ LogType.Audit.ToString() }' LogType");
        }

        [Fact]
        public void Adding_Duplicated_LogType_Should_Be_Controlled()
        {
            var loggerManager = new LoggerManager();
            var db = Path.Combine(_baseFolder, _db);
            loggerManager.AddNewLogger(new DBManager(db), LogType.Audit);

            var ex = Assert.Throws<ArgumentException>(() => loggerManager.AddNewLogger(new DBManager(db), LogType.Audit));
            Assert.Equal(ex.Message, $"The LogType '{ LogType.Audit.ToString() }' already has a logger associated");

            loggerManager.Dispose();
            File.Delete(db);
        }

        [Fact]
        public void Removing_Logger_Should_Successfully_Dispose_It()
        {
            var loggerManager = new LoggerManager();
            var db = Path.Combine(_baseFolder, _db);
            loggerManager.AddNewLogger(new DBManager(db), LogType.Audit);
            loggerManager.Log(LogType.Audit, new LogEntry( new Exception("Test Message")));
            loggerManager.Remove(LogType.Audit);

            Assert.True(!loggerManager.Exists(LogType.Audit));

            loggerManager.Dispose();
            File.Delete(db);
        }

        [Fact]
        public void Must_Log_LogEntry_With_Every_Constructor()
        {
            var loggerManager = new LoggerManager();
            var db = Path.Combine(_baseFolder, _db);
            loggerManager.AddNewLogger(new DBManager(db), LogType.Audit);

            loggerManager.Log(LogType.Audit, new LogEntry { Username = "TestUsername" });
            loggerManager.Log(LogType.Audit, new LogEntry("Test Message"));
            loggerManager.Log(LogType.Audit, new LogEntry(new Exception("Test Message")));

            loggerManager.Dispose();
            File.Delete(db);
        }
    }
}
