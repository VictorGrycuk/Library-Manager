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
            result.PublishedDate = new DateTime(int.Parse(result.publishedDate), 1, 1);

            result.Authors = new List<Author>();
            foreach (var author in result.authors)
            {
                result.Authors.Add(new Models.Author(author));
            }

            return result;
        }
    }
}
