using LiteDB;
using System.Collections.Generic;
using Base.Architecture.UserManagement.Models;

namespace Base.Architecture.UserManagement
{
    public class UserDB
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<DetailedUser> userCollection;

        public UserDB(string connectionString)
        {
            db = new LiteDatabase(connectionString);
            userCollection = db.GetCollection<DetailedUser>("User");
        }

        internal void Add(DetailedUser user) => userCollection.Insert(user);

        internal void Update(DetailedUser user) => userCollection.Update(user);

        internal IEnumerable<DetailedUser> Find(string field, string value) => userCollection.Find(Query.EQ(field, value));

        internal void Delete(string id) => userCollection.Delete(id);

        internal void Drop(string name) => db.DropCollection(name);

        internal void Close() => db.Dispose();
    }
}
