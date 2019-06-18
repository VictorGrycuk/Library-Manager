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
        public void TestGoogleApi()
        {
            Factory factory = new Factory(new GoogleApi());
            var book = factory.GetBookFromAPI("0735619670");

            Assert.AreEqual(book.Title, "Code Complete");
        }
    }
}
