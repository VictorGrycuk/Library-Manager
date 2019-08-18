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
            var tempUser = userManagement.FindByUserID(userName).First();

            curentUser = tempUser.ValidatePassword(password)
                        ? tempUser
                        : throw new Exception("Username or Password invalid");
        }
    }
}
