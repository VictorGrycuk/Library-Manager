using LibraryManagementCore.Modules.UserManagement;
using System;
using System.Linq;

namespace LibraryManagementCore
{
    public class Core
    {
        private User curentUser;
        public UserManagement userManagement;

        public void SetUserManagementModule(IDataBase dataBase)
        {
            userManagement = new UserManagement(dataBase);
        }

        public void LogIn(string userName, string password)
        {
            // Find the user. If it is not found, throw an exception.
            var tempUser = userManagement.FindByUserID(userName).FirstOrDefault()
                        ?? throw new Exception("Username or Password invalid");

            // Check if the given password checks against the stored password.
            curentUser = tempUser.ValidatePassword(password)
                        ? tempUser
                        : throw new Exception("Username or Password invalid");

            // Update the last accessed date time
            curentUser.LastAccessed = DateTime.Now;
            userManagement.Update(curentUser);
        }
    }
}
