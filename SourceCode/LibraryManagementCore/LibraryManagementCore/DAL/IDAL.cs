using LibraryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.DAL
{
    public interface IDAL
    {
        void AddBook(IBook book);
        void UpdateBook(IBook book);
        void DeleteBook(string isbn);
        IBook FindBookByISBN(string book);
        IBook FindBookByTitle(string title);

        void AddAuthor(Author author);
        Author FindAuthor(string name);
    }
}
