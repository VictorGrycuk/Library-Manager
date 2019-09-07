using Newtonsoft.Json;
using System.Net;

namespace LibraryManagementCore.BookManagement.Api
{
    public static class GoogleApi
    {
        public static GoogleBookModel FindBook(string ISBN)
        {
            const string url = "https://www.googleapis.com/books/v1/volumes?q=isbn:";

            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(url + ISBN);
                var result = JsonConvert.DeserializeObject<Rootobject>(json);

                return result.items?[0].volumeInfo;
            }
        }
    }
}
