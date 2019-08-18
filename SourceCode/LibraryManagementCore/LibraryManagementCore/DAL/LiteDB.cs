using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementCore.Models;
using LiteDB;

namespace LibraryManagementCore.DAL
{
    public class LocalLiteDB : IDAL
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<IBook> bookCollection;
        private readonly LiteCollection<Author> authorCollection;

        public LocalLiteDB(string filePath)
        {
            db = new LiteDatabase(filePath);
            bookCollection = db.GetCollection<IBook>("Book");
            authorCollection = db.GetCollection<Author>("Author");
        }

        public void AddBook(IBook book)
        {
            bookCollection.Insert(book);
        }

        public void DeleteBook(string isbn)
        {
            bookCollection.Delete(isbn);
        }

        public IBook FindBookByISBN(string isbn)
        {
            return bookCollection.Find(x => x.ID == isbn).FirstOrDefault();
        }

        public IBook FindBookByTitle(string title)
        {
            return bookCollection.Find(x => x.Title == title).FirstOrDefault();
        }

        public void UpdateBook(IBook book)
        {
            bookCollection.Update(book);
        }

        public void AddAuthor(Author author)
        {
            if (authorCollection.Find(x => x.Name == author.Name).Any())
                throw new Exception("Author already exists in the DB");

            authorCollection.Insert(author);
        }

        public Author FindAuthor(string name)
        {
            return authorCollection.Find(x => x.Name == name).FirstOrDefault();
        }
    }
}
