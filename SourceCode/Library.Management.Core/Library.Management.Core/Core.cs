using Base.Architecture.DatabaseManager;
using Base.Architecture.LogManagement;
using Base.Architecture.UserManagement;
using Base.Architecture.UserManagement.Models;
using LibraryManagementCore.BookManagement;
using System;
using System.IO;
using System.Security;

namespace LibraryManagementCore
{
    public class Core
    {
        public LogManager Logger;
        public User LoggedUser;
        public Localization.Localization Localization;
        public BookManager BookManager;
        public UserManager UserManagement;

        private DBManager _businessDB;
        private readonly DatabaseIntegrity _dbIntegrity;
        private readonly LocalConfiguration _localConfiguration;

        public Core(LocalConfiguration localConfiguration)
        {
            _localConfiguration = localConfiguration;

            // Load and setups the db with the application settings
            var configurationDB = new DBManager(_localConfiguration.ApplicationSettings);
            _dbIntegrity = new DatabaseIntegrity(configurationDB);
            Localization = new Localization.Localization(configurationDB);
            Logger = new LogManager();

            // Set the business database integrity
            CheckDBIntegrity(_localConfiguration.Database);

            // Tries to load the last used localization, otherwise it uses the default
            Localization.SetLocalization(!string.IsNullOrWhiteSpace(localConfiguration.Localization)
                ? localConfiguration.Localization
                : "en-us");
        }

        public void LogIn(string username, string password)
        {
            try
            {
                // Load and setups the db with the business data
                OpenBusinessDB();

                // Check if the given password checks against the stored password.
                LoggedUser = UserManagement.LogIn(username, password) ??
                               throw new ArgumentException("Username or Password invalid");

                // Update the last accessed date time
                LoggedUser.LastAccessed = DateTime.Now;
                UserManagement.UpdateUser(LoggedUser);
                Logger?.Log(LogType.Audit, new LogEntry { Username = LoggedUser.Username, Message = "Logged in" });
            }
            catch (Exception e)
            {
                Logger?.Log(LogType.Audit, new LogEntry { Username = username, Message = "Failed log in" });
                Logger?.Log(LogType.Error, e);
                throw;
            }
        }

        public void LogOut()
        {
            _businessDB.Dispose();
            LoggedUser = null;
            _dbIntegrity.SaveDatabaseHash("business");
        }

        private void OpenBusinessDB()
        {
            _businessDB = new DBManager(_localConfiguration.Database);
            UserManagement = new UserManager(_businessDB);
            BookManager = new BookManager(_businessDB);
            Logger.AddNewLogger(_businessDB, LogType.Audit);
        }

        private void CheckDBIntegrity(string path)
        {
            if (!File.Exists(path))
            {
                // No file to check
                return;
            }

            _dbIntegrity.RegisterNewDB("business", path);

            if (_dbIntegrity.Exists("business") && !_dbIntegrity.CheckIntegrity("business"))
            {
                throw new SecurityException("Database hash does not match.");
            }
        }
    }
}