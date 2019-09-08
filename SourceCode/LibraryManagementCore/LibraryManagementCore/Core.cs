using Base.Architecture.UserManagement;
using System;
using Base.Architecture.DatabaseManager;
using Base.Architecture.UserManagement.Models;

namespace LibraryManagementCore
{
    public class Core
    {
        private User _currentUser;
        private readonly UserManagementCore _userManagement;

        public Core(string connectionString)
        {
            var dbManager = new DBManager(connectionString);
            _userManagement = new UserManagementCore(dbManager);
        }

        public void LogIn(string username, string password)
        {
            // Check if the given password checks against the stored password.
            _currentUser = _userManagement.LogIn(username, password) ??
                           throw new Exception("Username or Password invalid");

            // Update the last accessed date time
            _currentUser.LastAccessed = DateTime.Now;
            _userManagement.UpdateUser(_currentUser);
        }
    }
}