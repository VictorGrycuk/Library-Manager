using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Models
{
    public class Book : IBook
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        //public string[] categories { get; set; }
        public float AverageRating { get; set; }
        public string MaturityRating { get; set; }
        public string Language { get; set; }
    }
}
