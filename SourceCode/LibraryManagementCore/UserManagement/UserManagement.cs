using Base.Architecture.DatabaseManager;
using Base.Architecture.UserManagement.Models;
using Base.Architecture.UserManagement.Security;
using System;
using System.Linq;

namespace Base.Architecture.UserManagement
{
    public class UserManagementCore
    {
        private readonly TableManager<DetailedUser> _db;
        private bool _isLogged;

        public enum Field
        {
            Username,
            Name,
            LastName,
        }

        public UserManagementCore(DBManager dbManager)
        {
            _db = dbManager.NewTableConnection<DetailedUser>("User");

            if (!_db.Exists("Username", "admin"))
            {
                _db.Add(GetNewAdmin());
            }
        }

        public User LogIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Username or Password cannot be null.");
            }

            var user = _db.Find("Username", username).FirstOrDefault() ?? throw new ArgumentException("User not found.");
            _isLogged = user.ValidatePassword(password);
            if (_isLogged)
            {
                UpdateLastAccess(user);
            }

            return _isLogged ? user.ToUser() : null;
        }

        public void StoreUser(User user, string password)
        {
            CheckLoginStatus();
            if (_db.Exists("Username", user.Username))
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

            _db.Add(newUser);
        }

        public User FindUser(Field field, string value)
        {
            CheckLoginStatus();

            var tempUser = _db.Find(field.ToString(), value).FirstOrDefault();

            return tempUser?.ToUser();
        }

        public void UpdateUser(User user)
        {
            CheckLoginStatus();

            var detailedUser = _db.Find("Username", user.Username).FirstOrDefault();
            detailedUser.Username = user.Username;
            detailedUser.Name = user.Name;
            detailedUser.LastName = user.LastName;

            _db.Update(detailedUser);
        }

        public void UpdatePassword(User user, string password)
        {
            CheckLoginStatus();
            PasswordValidationHelper.ValidatePassword(password);

            var detailedUser = _db.Find("Username", user.Username).FirstOrDefault();
            detailedUser.SetPassword(password);

            _db.Update(detailedUser);
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
            _db.Update(detailedUser);
        }

        private void CheckLoginStatus()
        {
            if (!_isLogged)
            {
                throw new UnauthorizedAccessException("Please log in.");
            }
        }
    }
}
