using System;
using LibraryManagementCore;
using LibraryManagementCore.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Tests
{
    [TestClass]
    public class TestApi
    {
        [TestMethod]
        public void GetBookFromGoogleApi()
        {
            Factory factory = new Factory(new GoogleApi());
            var book = factory.GetBookFromAPI("9780132350884");

            Assert.AreEqual(book.Title, "Clean Code");
        }
    }
}
