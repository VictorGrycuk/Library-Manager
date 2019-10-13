using System;

namespace LibraryManagementCore.BookManagement.Models
{
    public class Author
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
    }
}
