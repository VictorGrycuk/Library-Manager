using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementCore.Modules.UserManagement
{
    public class UserManagement
    {
        private readonly IDataBase userDB;

        public UserManagement(IDataBase dataBase)
        {
            userDB = dataBase;
        }

        public void AddNewUser(User user)
        {
            if (CheckIfUserExists(user.UserID))
                throw new ArgumentException($"The ID { user.UserID } already exists.");

            userDB.Add(user);
        }

        public void AddNewUser(string name, string lastName, string userId, string password)
        {
            var user = new User
            {
                Name = name,
                LastName = lastName,
                UserID = userId,
                DateCreated = DateTime.Now,
                LastAccessed = DateTime.Now,
            };

            user.SetPassword(password);

            AddNewUser(user);
        }

        public void Update(User user)
        {
            userDB.Update(user);
        }

        public List<User> FindByName(string name)
        {
            return userDB.Find("Name", name).ToList().ConvertAll(x => x as User);
        }

        public List<User> FindByLastName(string lastName)
        {
            return userDB.Find("LastName", lastName).ToList().ConvertAll(x => x as User);
        }

        public List<User> FindByUserID(string userID)
        {
            return userDB.Find("UserID", userID).ToList().ConvertAll(x => x as User);
        }

        public void Delete(User user)
        {
            userDB.Delete(user.ID.ToString());
        }

        private bool CheckIfUserExists(string userId)
        {
            return FindByUserID(userId).Count > 0 ? true : false;
        }
    }
}
