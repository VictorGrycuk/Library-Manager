using System;
using System.Collections.Generic;
using LibraryManagementCore.BookManagement.Models;
using LiteDB;

namespace LibraryManagementCore.BookManagement
{
    internal class BookManagementDB
    {
        private readonly LiteDatabase _db;
        private readonly LiteCollection<BookDB> _bookCollection;
        private readonly LiteCollection<Author> _authorCollection;

        public BookManagementDB(string connectionString)
        {
            _db = new LiteDatabase(connectionString);
            _bookCollection = _db.GetCollection<BookDB>("Book");
            _authorCollection = _db.GetCollection<Author>("Author");
        }

        public void Add(BookDB book) => _bookCollection.Insert(book);

        public void Add(Author author) => _authorCollection.Insert(author);

        public void Delete(BookDB bookDB)
        {
            _bookCollection.Delete(bookDB.ID);
        }

        public void Delete(Author author)
        {
            _authorCollection.Delete(author.ID);
        }

        public IEnumerable<T> Find<T>(string field, string value) where T : class, new()
        {
            switch (new T())
            {
                case BookDB _:
                    return (IEnumerable<T>)_bookCollection.Find(Query.EQ(field, value));
                case Author _:
                    return (IEnumerable<T>)_authorCollection.Find(Query.EQ(field, value));
                default:
                    throw new NotImplementedException($"Type { new T().GetType() } is not supported.");
            }
        }

        public T Find<T>(Guid id) where T : class, new()
        {
            switch (new T())
            {
                case BookDB _:
                    return _bookCollection.FindById(id) as T;
                case Author _:
                    return _authorCollection.FindById(id) as T;
                default:
                    throw new NotImplementedException($"Type { new T().GetType() } is not supported.");
            }
        }

        public void Update(BookDB book) => _bookCollection.Update(book);

        public void Update(Author author) => _authorCollection.Update(author);

        internal void Drop(string name) => _db.DropCollection(name);

        internal void Close() => _db.Dispose();
    }
}
