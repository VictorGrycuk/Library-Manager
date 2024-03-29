﻿using System;
using System.Linq;
using Base.Architecture.DatabaseManager;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;

namespace LibraryManagementCore.BookManagement
{
    public class BookManagement
    {
        private readonly TableManager<BookDB> _bookCollection;
        private readonly TableManager<Author> _authorCollection;

        public BookManagement(DBManager dbManager)
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

        private BookDB GetDbModel(Book book)
        {
            var dbModel = Mapper.ConvertModel<Book, BookDB>(book);

            foreach (var author in book.Authors)
            {
                var storedAuthor = _authorCollection.Find("Name", author.Name).FirstOrDefault();
                if (storedAuthor != null) dbModel.Authors.Add(storedAuthor.ID);
                else
                {
                    var newAuthor = new Author { Name = author.Name, ID = Guid.NewGuid() };
                    dbModel.Authors.Add(newAuthor.ID);
                    _authorCollection.Add(newAuthor);
                }
            }

            return dbModel;
        }
    }
}
