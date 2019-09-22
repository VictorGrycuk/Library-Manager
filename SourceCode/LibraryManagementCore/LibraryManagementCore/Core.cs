using Base.Architecture.UserManagement;
using System;
using Base.Architecture.DatabaseManager;
using Base.Architecture.UserManagement.Models;
using Base.Architecture.Logger;

namespace LibraryManagementCore
{
    public class LibraryCore
    {
        public LoggerManager Logger;
        private User _currentUser;
        private readonly UserManagementCore _userManagement;

        public LibraryCore(string connectionString)
        {
            var dbManager = new DBManager(connectionString);
            _userManagement = new UserManagementCore(dbManager);
        }

        public void LogIn(string username, string password)
        {
            try
            {
                // Check if the given password checks against the stored password.
                _currentUser = _userManagement.LogIn(username, password) ??
                               throw new Exception("Username or Password invalid");

                // Update the last accessed date time
                _currentUser.LastAccessed = DateTime.Now;
                _userManagement.UpdateUser(_currentUser);
                Logger?.Log(LogType.Audit, new LogEntry { Username = _currentUser.Username, Message = "Logged in" });
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