using System;
using System.Collections.Generic;
using System.Linq;
using Base.Architecture.DatabaseManager;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;

namespace LibraryManagementCore.BookManagement
{
    public class BookManager
    {
        private readonly TableManager<BookDB> _bookCollection;
        private readonly TableManager<Author> _authorCollection;

        public BookManager(DBManager dbManager)
        {
            _bookCollection = dbManager.NewTableConnection<BookDB>("Book");
            _authorCollection = dbManager.NewTableConnection<Author>();
        }

        public Book GetBookFromApi(string isbn)
        {
            var googleBook = GoogleApi.FindBook(isbn);
            var book = Mapper.ConvertModel<GoogleBookModel, Book>(googleBook);

            foreach (var author in googleBook.authors)
            {
                var foundAuthor = _authorCollection.Find("Name", author).FirstOrDefault();
                if (foundAuthor == null) continue;

                book.Authors.Remove(book.Authors.SingleOrDefault(a => a.Name == author));
                book.Authors.Add(foundAuthor);
            }

            return book;
        }

        public void AddToCollection(Book book)
        {
            _bookCollection.Add(GetDbModel(book));
        }

        public void AddToCollection(Author author)
        {
            _authorCollection.Add(author);
        }

        public Book FindBook(string field, string value)
        {
            var storedBook = _bookCollection.Find(field, value).FirstOrDefault();
            if (storedBook == null) return null;

            var book = Mapper.ConvertModel<BookDB, Book>(storedBook);
            foreach (var storedAuthor in storedBook.Authors.Select(author => _authorCollection.Find(author)).Where(storedAuthor => storedAuthor != null))
            {
                book.Authors.Add(storedAuthor);
            }

            return book;
        }

        public Author FindAuthor(string field, string value)
        {
            return _authorCollection.Find(field, value).FirstOrDefault();
        }

        public Author FindAuthor(Guid key)
        {
            return _authorCollection.Find(key);
        }

        public void RemoveFromCollection(Book book)
        {
            _bookCollection.Delete(GetDbModel(book));
        }

        public void RemoveFromCollection(Author author)
        {
            _authorCollection.Delete(author);
        }

        public void Update(Author author)
        {
            _authorCollection.Update(author);
        }

        public void Update(Book book)
        {
            _bookCollection.Update(GetDbModel(book));
        }

        public List<Book> GetAll()
        {
            var dbBooks = _bookCollection.GetAll().ToArray();
            var books = _bookCollection.GetAll().Select(Mapper.ConvertModel<BookDB, Book>).ToList();

            foreach (var UPPER in books)
            {
                var test = new List<Author>();
                foreach (var book in dbBooks)
                {
                    if (UPPER.Isbn == book.Isbn)
                    {
                        UPPER.Authors = book.Authors.Select(FindAuthor).ToList();
                    }
                }
            }

            return books;
        }

        private BookDB GetDbModel(Book book)
        {
            var dbModel = Mapper.ConvertModel<Book, BookDB>(book);

            foreach (var author in book.Authors)
            {
                var storedAuthor = _authorCollection.Find("Name", author.Name).FirstOrDefault();
                if (storedAuthor != null) dbModel.Authors.Add(storedAuthor.Id);
                else
                {
                    var newAuthor = new Author { Name = author.Name, Id = Guid.NewGuid() };
                    dbModel.Authors.Add(newAuthor.Id);
                    _authorCollection.Add(newAuthor);
                }
            }

            return dbModel;
        }
    }
}
