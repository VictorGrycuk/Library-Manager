using LibraryManagementCore.Models;
using LiteDB;
using System.Linq;

namespace LibraryManagementCore.DAL
{
    internal class BookManagement
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<IBook> bookCollection;

        public BookManagement(LiteDatabase database)
        {
            db = database;
            bookCollection = db.GetCollection<IBook>("Book");
        }

        public void Add(IBook book)
        {
            bookCollection.Insert(book);
        }

        public void Delete(string isbn)
        {
            bookCollection.Delete(isbn);
        }

        public IBook FindByISBN(string isbn)
        {
            return bookCollection.Find(x => x.ID == isbn).FirstOrDefault();
        }

        public IBook FindByTitle(string title)
        {
            return bookCollection.Find(x => x.Title == title).FirstOrDefault();
        }

        public void Update(IBook book)
        {
            bookCollection.Update(book);
        }
    }
}
