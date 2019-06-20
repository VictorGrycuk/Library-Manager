using LibraryManagementCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.API
{
    public class GoogleApi : IAPI
    {
        private const string url = "https://www.googleapis.com/books/v1/volumes?q=isbn:";
        private static readonly WebClient webClient = new WebClient();

        public IBook GetBookDetailsFromISBN(string ISBN)
        {
            var json = webClient.DownloadString(url + ISBN);
            var result = JsonConvert.DeserializeObject<GoogleRootObject>(json).items[0].GoogleBookModel;

            return Adapt(result);
        }

        private IBook Adapt(GoogleBookModel googleBook)
        {
            googleBook.ID = googleBook.industryIdentifiers[0].identifier;
            googleBook.PublishedDate = new DateTime(int.Parse(googleBook.publishedDate), 1, 1);

            //googleBook.Authors = new List<Author>();

            //foreach (var author in googleBook.authors)
            //{
            //    googleBook.Authors.Add(new Author(author));
            //}

            return googleBook;
        }
    }
}
