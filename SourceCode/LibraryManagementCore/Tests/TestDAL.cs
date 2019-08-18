using LibraryManagementCore;
using LibraryManagementCore.API;
using LibraryManagementCore.DAL;
using LibraryManagementCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestDAL
    {
        private readonly IDAL dal;
        private readonly Factory factory;
        private readonly IBook book;

        public TestDAL()
        {
            dal = new LocalLiteDB(@"C:\Repositories\Library Manager\SourceCode\LibraryManagementCore\LibraryManagementCore\bin\Debug\test.db");
            factory = new Factory(new GoogleApi());
            book = factory.GetBookFromAPI("9780132350884");
        }

        [TestMethod]
        public void AddBook()
        {
            dal.AddBook(book);
        }

        [TestMethod]
        public void UpdateBook()
        {
            book.Title = "Test Title";
            dal.UpdateBook(book);

            Assert.IsNotNull(dal.FindBookByTitle("Test Title"));
        }

        [TestMethod]
        public void FindBook()
        {
            var result = dal.FindBookByISBN("9780132350884");
            Assert.IsTrue(!string.IsNullOrEmpty(result.Title));
        }

        [TestMethod]
        public void RemoveBook()
        {
            dal.DeleteBook("9780132350884");
            Assert.IsNull(dal.FindBookByISBN("9780132350884"));
        }

        [TestMethod]
        public void AddAuthor()
        {
            var author = new Author
            {
                Name = "Robert C. Martin",
                DoB = new DateTime(1952, 1, 1)
            };

            dal.AddAuthor(author);
        }

        [TestMethod]
        public void FindAuthor()
        {
            Assert.IsNotNull(dal.FindAuthor("Robert C. Martin"));
        }
    }
}
