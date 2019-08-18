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
        private readonly LiteCollection<Author> authorCollection;
        private readonly BookManagement bookManagement;

        public LocalLiteDB(string filePath)
        {
            db = new LiteDatabase(filePath);

            bookManagement = new BookManagement(db);
            authorCollection = db.GetCollection<Author>("Author");
        }

        public void AddBook(IBook book)
        {
            bookManagement.Add(book);
        }

        public void DeleteBook(string isbn)
        {
            bookManagement.Delete(isbn);
        }

        public IBook FindBookByISBN(string isbn)
        {
            return bookManagement.FindByISBN(isbn);
        }

        public IBook FindBookByTitle(string title)
        {
            return FindBookByTitle(title);
        }

        public void UpdateBook(IBook book)
        {
            bookManagement.Update(book);
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
