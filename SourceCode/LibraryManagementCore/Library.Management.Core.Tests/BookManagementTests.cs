using LibraryManagementCore.BookManagement;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Library.Management.Core.Tests
{
    public class BookManagementTests
    {
        private readonly string _dbDir;
        private readonly BookDB _dummyBookDB;
        private readonly Author _dummyAuthor;

        public BookManagementTests()
        {
            _dbDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "test.db");
            File.Delete(_dbDir);

            _dummyAuthor = new Author
            {
                ID = Guid.NewGuid(),
                Name = "DummyAuthor"
            };

            _dummyBookDB = new BookDB
            {
                Authors = new List<Guid> { _dummyAuthor.ID },
                AverageRating = 10,
                Description = "TestBook",
                ID = Guid.NewGuid(),
                Isbn = "xxxxxxxxxxxxx",
                Language = "en",
                MaturityRating = "MA",
                PageCount = 10,
                PublishedDate = DateTime.Parse("11/06/1987"),
                Publisher = "BookManagement_Should_Add_Book_To_DB Developer",
                Title = "BookManagement_Should_Add_Book_To_DB Book"
            };
        }

        [Fact]
        public void Google_Api_Should_Not_Fail_With_Valid_ISBN10()
        {
            var book = GoogleApi.FindBook("0132350882");
            Assert.NotNull(book);
        }

        [Fact]
        public void Google_Api_Should_Not_Fail_With_Valid_ISBN13()
        {
            var book = GoogleApi.FindBook("9780132350884");
            Assert.NotNull(book);
        }

        [Fact]
        public void Google_Api_Should_Return_Null_With_Invalid_ISBN()
        {
            var book = GoogleApi.FindBook("xxxxxxxxxxxxx");
            Assert.Null(book);
        }

        [Fact]
        public void Mapper_Should_Map_Google_Model_To_Book()
        {
            var mapper = new Mapper(new BookManagementDB(_dbDir));
            var source = GoogleApi.FindBook("9780132350884");
            var destination = mapper.ConvertModel<GoogleBookModel, Book>(source);
            mapper.Dispose();

            Assert.Equal(source.title, destination.Title);
            Assert.Equal(source.industryIdentifiers[0].identifier, destination.Isbn);
            Assert.Equal(source.publisher, destination.Publisher);
            Assert.Equal(source.publishedDate, destination.PublishedDate.Year.ToString());
            Assert.Equal(source.description, destination.Description);
            Assert.Equal(source.pageCount, destination.PageCount);
            Assert.Equal(source.averageRating, destination.AverageRating);
            Assert.Equal(source.maturityRating, destination.MaturityRating);
            Assert.Equal(source.language, destination.Language);

            for (var i = 0; i < source.authors.Length; i++)
            {
                Assert.Equal(destination.Authors[i].Name, source.authors[i]);
            }
        }

        [Fact]
        public void Mapper_Should_Map_Book_To_Database_Model()
        {
            var mapper = new Mapper(new BookManagementDB(_dbDir));
            var googleBook = GoogleApi.FindBook("9780132350884");
            var book = mapper.ConvertModel<GoogleBookModel, Book>(googleBook);
            var databaseModel = mapper.ConvertModel<Book, BookDB>(book);
            mapper.Dispose();

            ValidateBook(book, databaseModel);
        }

        [Fact]
        public void Mapper_Should_Map_DatabaseModel_To_Book()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddAuthorToCollection(_dummyAuthor);
            bookManagement.Disconnect();

            var mapper = new Mapper(new BookManagementDB(_dbDir));
            var book = mapper.ConvertModel<BookDB, Book>(_dummyBookDB);
            mapper.Dispose();

            ValidateBook(book, _dummyBookDB);
        }

        [Fact]
        public void BookManagement_Should_Return_Book_From_Api()
        {
            var bookManagement = new BookManagement(_dbDir);

            Assert.NotNull(bookManagement.GetBookFromApi("9780132350884"));
            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Add_Book_To_DB()
        {
            var bookManagement = new BookManagement(_dbDir);

            bookManagement.AddBookToCollection(_dummyBookDB);
            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Find_Book_In_DB()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddBookToCollection(_dummyBookDB);

            Assert.NotNull(bookManagement.FindBookInCollection("Isbn", "xxxxxxxxxxxxx"));
            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Delete_Book_From_DB()
        {
            var mapper = new Mapper(new BookManagementDB(_dbDir));
            var bookManagement = new BookManagement(_dbDir);
            var book = mapper.ConvertModel<BookDB, Book>(_dummyBookDB);
            mapper.Dispose();

            bookManagement.AddBookToCollection(book);
            bookManagement.RemoveBookFromCollection(book);

            Assert.Null(bookManagement.FindBookInCollection("Isbn", "xxxxxxxxxxxxx"));
            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Add_Author_To_DB()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddAuthorToCollection(_dummyAuthor);

            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Find_Author_In_DB()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddAuthorToCollection(_dummyAuthor);
            Assert.NotNull(bookManagement.FindAuthorInCollection("Name", "DummyAuthor"));

            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Delete_Author_From_DB()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddAuthorToCollection(_dummyAuthor);
            bookManagement.RemoveAuthorFromCollection(_dummyAuthor);
            Assert.Null(bookManagement.FindAuthorInCollection("Name", _dummyAuthor.Name));

            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Update_Author_In_DB()
        {
            var bookManagement = new BookManagement(_dbDir);
            bookManagement.AddAuthorToCollection(_dummyAuthor);
            _dummyAuthor.Name = "NewName";
            bookManagement.Update(_dummyAuthor);
            Assert.NotNull(bookManagement.FindAuthorInCollection("Name", _dummyAuthor.Name));

            bookManagement.Disconnect();
        }

        [Fact]
        public void BookManagement_Should_Update_Book_In_DB()
        {
            var mapper = new Mapper(new BookManagementDB(_dbDir));
            var bookManagement = new BookManagement(_dbDir);
            var book = mapper.ConvertModel<BookDB, Book>(_dummyBookDB);
            mapper.Dispose();

            bookManagement.AddBookToCollection(book);
            book.Isbn = "yyyyyyyyyyyyy";
            bookManagement.Update(book);

            Assert.NotNull(bookManagement.FindBookInCollection("Isbn", "yyyyyyyyyyyyy"));
            bookManagement.Disconnect();
        }

        private static void ValidateBook(Book book, BookDB bookDb)
        {
            Assert.Equal(book.Authors[0].ID, bookDb.Authors[0]);
            Assert.Equal(book.AverageRating, bookDb.AverageRating);
            Assert.Equal(book.Description, bookDb.Description);
            Assert.Equal(book.Isbn, bookDb.Isbn);
            Assert.Equal(book.Language, bookDb.Language);
            Assert.Equal(book.MaturityRating, bookDb.MaturityRating);
            Assert.Equal(book.PageCount, bookDb.PageCount);
            Assert.Equal(book.PublishedDate, bookDb.PublishedDate);
            Assert.Equal(book.Publisher, bookDb.Publisher);
            Assert.Equal(book.Title, bookDb.Title);
        }
    }
}
