using System;
using System.Collections.Generic;

namespace LibraryManagementCore.Models
{
    public interface IBook
    {
        float AverageRating { get; set; }
        List<Author> Authors { get; set; }
        string Description { get; set; }
        string Language { get; set; }
        string MaturityRating { get; set; }
        int PageCount { get; set; }
        DateTime PublishedDate { get; set; }
        string Publisher { get; set; }
        string Title { get; set; }
    }
}