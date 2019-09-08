using LiteDB;
using System;
using System.Collections.Generic;

namespace Base.Architecture.DatabaseManager
{
    public class TableManager<TObjectType> where TObjectType : class, new()
    {
        private readonly LiteCollection<TObjectType> _db;

        public TableManager(LiteCollection<TObjectType> collection)
        {
            _db = collection;
        }

        public void Add(TObjectType objectType)
        {
            _db.Insert(objectType);
        }

        public void Update(TObjectType objectType)
        {
            _db.Update(objectType);
        }

        public void Delete(TObjectType objectType)
        {
            var value = typeof(TObjectType).GetProperty("ID")?.GetValue(objectType)
                ?? throw new ArgumentException($"Object { objectType.GetType() } is missing property 'ID'");

            _db.Delete((Guid) value);
        }

        public IEnumerable<TObjectType> Find(string field, string value)
        {
            return _db.Find(Query.EQ(field, value));
        }

        public TObjectType Find(Guid id)
        {
            return _db.FindById(id);
        }

        public bool Exists(string field, string value)
        {
            return _db.Exists(Query.EQ(field, value));
        }
    }
}
