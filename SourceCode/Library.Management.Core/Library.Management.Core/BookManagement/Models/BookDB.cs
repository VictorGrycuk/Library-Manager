using System;
using System.Collections.Generic;

namespace LibraryManagementCore.BookManagement.Models
{
    internal class BookDB : Book
    {
        public new List<Guid> Authors { get; set; }
    }
}
