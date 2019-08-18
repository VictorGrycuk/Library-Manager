using LiteDB;
using System;
using System.Collections.Generic;

namespace LibraryManagementCore.Modules.UserManagement
{
    public class UserDB : IDataBase
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<User> userCollection;

        public UserDB(string connectionString)
        {
            db = new LiteDatabase(connectionString);
            userCollection = db.GetCollection<User>("User");
        }

        public void Add(object user) => userCollection.Insert(user as User);

        public void Update(object user) => userCollection.Update(user as User);

        public IEnumerable<object> Find(string field, string value) => userCollection.Find(Query.EQ(field, value));

        public void Delete(string id) => userCollection.Delete(id);
    }
}
