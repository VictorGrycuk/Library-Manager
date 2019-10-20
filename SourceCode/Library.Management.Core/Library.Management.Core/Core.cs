using Base.Architecture.DatabaseManager;
using Base.Architecture.LogManagement;
using Base.Architecture.UserManagement;
using Base.Architecture.UserManagement.Models;
using LibraryManagementCore.BookManagement;
using System;

namespace LibraryManagementCore
{
    public class Core
    {
        public LogManager Logger;
        public User LoggedUser;
        public Localization.Localization Localization;
        public readonly BookManager BookManager;
        public readonly UserManager UserManagement;

        public Core(LocalConfiguration localConfiguration)
        {
            // Load and setups the db with the application settings
            var configurationDB = new DBManager(localConfiguration.ApplicationSettings);
            Localization = new Localization.Localization(configurationDB);

            // Load and setups the db with the business data
            var businessDB = new DBManager(localConfiguration.Database);
            UserManagement = new UserManager(businessDB);
            BookManager = new BookManager(businessDB);

            // Tries to load the last used localization
            Localization.SetLocalization(!string.IsNullOrWhiteSpace(localConfiguration.Localization)
                ? localConfiguration.Localization
                : "en-us");
        }

        public void LogIn(string username, string password)
        {
            try
            {
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
    }
}