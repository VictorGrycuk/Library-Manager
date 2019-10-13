using Base.Architecture.DatabaseManager;
using LibraryManagementCore.BookManagement;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Library.Management.Core.Tests
{
    public class BookManagementTests
    {
        private readonly DBManager _dbManager;
        private readonly BookDB _dummyBookDB;
        private readonly Author _dummyAuthor;

        public BookManagementTests()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            var dbDir = string.Empty;
            if (directoryInfo != null)
            {
                dbDir = Path.Combine(directoryInfo.FullName, this + ".db");

                if (File.Exists(dbDir))
                {
                    File.Delete(dbDir);
                }
            }

            _dbManager = new DBManager(dbDir);

            _dummyAuthor = new Author
            {
                Id = Guid.NewGuid(),
                Name = "DummyAuthor"
            };

            _dummyBookDB = new BookDB
            {
                Authors = new List<Guid> { _dummyAuthor.Id },
                AverageRating = 10,
                Description = "TestBook",
                Id = Guid.NewGuid(),
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
            var source = GoogleApi.FindBook("9780132350884");
            var destination = Mapper.ConvertModel<GoogleBookModel, Book>(source);

            Assert.Equal(source.title, destination.Title);
            Assert.Equal(source.industryIdentifiers[0].identifier, destination.Isbn);
            Assert.Equal(source.publisher, destination.Publisher);
            Assert.Equal(source.publishedDate, destination.PublishedDate.Year.ToString());
            Assert.Equal(source.description, destination.Description);
            Assert.Equal(source.pageCount, destination.PageCount);
            Assert.Equal(source.averageRating, destination.AverageRating);
            Assert.Equal(source.maturityRating, destination.MaturityRating);
            Assert.Equal(source.language, destination.Language);
            Assert.Equal(source.authors[0], destination.Authors[0].Name);
        }

        [Fact]
        public void Mapper_Should_Map_Book_To_Database_Model()
        {
            var googleBook = GoogleApi.FindBook("9780132350884");
            var book = Mapper.ConvertModel<GoogleBookModel, Book>(googleBook);
            var databaseModel = Mapper.ConvertModel<Book, BookDB>(book);

            ValidateBook(book, databaseModel);
        }

        [Fact]
        public void Mapper_Should_Map_DatabaseModel_To_Book()
        {
            var book = Mapper.ConvertModel<BookDB, Book>(_dummyBookDB);

            ValidateBook(book, _dummyBookDB);
        }

        [Fact]
        public void BookManagement_Should_Return_Book_From_Api()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(new Author { Name = "Robert C. Martin", Id = Guid.NewGuid()});

            var book = bookManagement.GetBookFromApi("9780132350884");
            _dbManager.Dispose();

            Assert.Equal("en", book.Language);
            Assert.Equal(431, book.PageCount);
            Assert.Equal(4.5, book.AverageRating);
            Assert.Equal("Clean Code", book.Title);
            Assert.Equal("9780132350884", book.Isbn);
            Assert.Equal("NOT_MATURE", book.MaturityRating);
            Assert.Equal("Pearson Education", book.Publisher);
            Assert.Equal("2009", book.PublishedDate.Year.ToString());
            Assert.Equal("Robert C. Martin", book.Authors.FirstOrDefault()?.Name);
            Assert.StartsWith("Looks at the principles and clean code", book.Description);
        }

        [Fact]
        public void BookManagement_Should_Add_Book_To_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            var book = bookManagement.GetBookFromApi("9780132350884");

            bookManagement.AddToCollection(book);
            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Find_Book_In_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(new Author { Name = "Robert C. Martin", Id = Guid.NewGuid() });
            var book = bookManagement.GetBookFromApi("9780132350884");
            bookManagement.AddToCollection(book);

            var foundBook = bookManagement.FindBook("Title", "Clean Code");

            Assert.Equal(book.Id, foundBook.Id);
            Assert.Equal(book.Isbn, foundBook.Isbn);
            Assert.Equal(book.Title, foundBook.Title);
            Assert.Equal(book.Publisher, foundBook.Publisher);
            Assert.Equal(book.Language, foundBook.Language);
            Assert.Equal(book.PageCount, foundBook.PageCount);
            Assert.Equal(book.Description, foundBook.Description);
            Assert.Equal(book.AverageRating, foundBook.AverageRating);
            Assert.Equal(book.Authors[0].Id, foundBook.Authors[0].Id);
            Assert.Equal(book.PublishedDate, foundBook.PublishedDate);
            Assert.Equal(book.MaturityRating, foundBook.MaturityRating);
            Assert.Equal(book.Authors[0].Name, foundBook.Authors[0].Name);
            _dbManager.Dispose();

        }

        [Fact]
        public void BookManagement_Should_Delete_Book_From_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            var book = bookManagement.GetBookFromApi("9780132350884");
            bookManagement.AddToCollection(book);

            bookManagement.RemoveFromCollection(book);

            Assert.Null(bookManagement.FindBook("Title", book.Title));
            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Add_Author_To_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(_dummyAuthor);

            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Find_Author_In_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(_dummyAuthor);

            Assert.NotNull(bookManagement.FindAuthor("Name", _dummyAuthor.Name));

            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Delete_Author_From_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(_dummyAuthor);
            bookManagement.RemoveFromCollection(_dummyAuthor);

            Assert.Null(bookManagement.FindAuthor("Name", _dummyAuthor.Name));

            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Update_Author_In_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            bookManagement.AddToCollection(_dummyAuthor);
            _dummyAuthor.Name = "NewName";
            bookManagement.Update(_dummyAuthor);
            Assert.NotNull(bookManagement.FindAuthor("Name", _dummyAuthor.Name));

            _dbManager.Dispose();
        }

        [Fact]
        public void BookManagement_Should_Update_Book_In_DB()
        {
            var bookManagement = new BookManager(_dbManager);
            var book = bookManagement.GetBookFromApi("9780132350884");
            bookManagement.AddToCollection(book);
            book.Title = "Modified Title";

            bookManagement.Update(book);
            Assert.NotNull(bookManagement.FindBook("Title", book.Title));

            _dbManager.Dispose();
        }

        private static void ValidateBook(Book book, BookDB bookDb)
        {
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
