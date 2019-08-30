using System;
using System.Linq;
using Base.Architecture.UserManagement.Models;
using Base.Architecture.UserManagement.Security;

namespace Base.Architecture.UserManagement
{
    public class UserManagementCore
    {
        readonly UserDB db;
        bool isLogged;

        public enum Field
        {
            Username,
            Name,
            LastName,
        }

        public UserManagementCore(string connection)
        {
            db = new UserDB(connection);

            if (db.Find("Username", "admin").Count() == 0)
            {
                db.Add(GetNewAdmin());
            }
        }

        public User LogIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Username or Password cannot be null.");
            }

            var user = db.Find("Username", username).FirstOrDefault() ?? throw new ArgumentException("User not found.");
            isLogged = user.ValidatePassword(password);
            if (isLogged)
            {
                UpdateLastAccess(user);
            }

            return isLogged ? user.ToUser() : null;
        }

        public void StoreUser(User user, string password)
        {
            CheckLoginStatus();
            if (db.Find("Username", user.Username).Count() > 0)
            {
                throw new ArgumentException($"Username '{ user.Username }' already exists.");
            }

            var newUser = new DetailedUser
            {
                Username = user.Username,
                Name = user.Name,
                LastName = user.LastName,
                DateCreated = DateTime.Now
            };

            PasswordValidationHelper.ValidatePassword(password);
            newUser.SetPassword(password);

            db.Add(newUser);
        }

        public User FindUser(Field field, string value)
        {
            CheckLoginStatus();

            var tempUser = db.Find(field.ToString(), value).FirstOrDefault();

            return tempUser?.ToUser();
        }

        public void UpdateUser(User user)
        {
            CheckLoginStatus();

            var detailedUser = db.Find("Username", user.Username).FirstOrDefault();
            detailedUser.Username = user.Username;
            detailedUser.Name = user.Name;
            detailedUser.LastName = user.LastName;

            db.Update(detailedUser);
        }

        public void UpdatePassword(User user, string password)
        {
            CheckLoginStatus();
            PasswordValidationHelper.ValidatePassword(password);

            var detailedUser = db.Find("Username", user.Username).FirstOrDefault();
            detailedUser.SetPassword(password);

            db.Update(detailedUser);
        }

        private static DetailedUser GetNewAdmin()
        {
            var admin = new DetailedUser
            {
                Username = "admin",
                DateCreated = DateTime.Now,
            };

            admin.SetPassword("admin");

            return admin;
        }

        private void UpdateLastAccess(DetailedUser detailedUser)
        {
            detailedUser.LastAccessed = DateTime.Now;
            db.Update(detailedUser);
        }

        private void CheckLoginStatus()
        {
            if (!isLogged)
            {
                throw new UnauthorizedAccessException("Please log in.");
            }
        }

        public void DropTable(string tableName)
        {
            db.Drop(tableName);
        }

        public void CloseConnection()
        {
            db.Close();
        }
    }
}
