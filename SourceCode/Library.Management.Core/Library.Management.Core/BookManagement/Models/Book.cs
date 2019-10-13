using System;
using System.Collections.Generic;

namespace LibraryManagementCore.BookManagement.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public List<Author> Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public float AverageRating { get; set; }
        public string MaturityRating { get; set; }
        public string Language { get; set; }
    }
}
