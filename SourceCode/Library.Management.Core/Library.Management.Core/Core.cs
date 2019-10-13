using Base.Architecture.DatabaseManager;
using Base.Architecture.LocalizationManagement;
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
        public LocalizationManager Localization;
        public readonly BookManager BookManager;
        private readonly UserManager _userManagement;

        public Core(string connectionString)
        {
            var dbManager = new DBManager(connectionString);
            _userManagement = new UserManager(dbManager);
            BookManager = new BookManager(dbManager);
            Localization = new LocalizationManager(dbManager);
        }

        public void LogIn(string username, string password)
        {
            try
            {
                // Check if the given password checks against the stored password.
                LoggedUser = _userManagement.LogIn(username, password) ??
                               throw new ArgumentException("Username or Password invalid");

                // Update the last accessed date time
                LoggedUser.LastAccessed = DateTime.Now;
                _userManagement.UpdateUser(LoggedUser);
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