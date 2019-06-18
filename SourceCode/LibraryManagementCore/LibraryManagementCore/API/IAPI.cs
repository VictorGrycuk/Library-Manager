using LibraryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.API
{
    public interface IAPI
    {
        IBook GetBookDetailsFromISBN(string ISBN);
    }
}
