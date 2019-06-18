using LibraryManagementCore.API;
using LibraryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore
{
    public class Factory
    {
        private readonly IAPI api;

        public Factory(IAPI api)
        {
            this.api = api;
        }

        public IBook GetBookFromAPI(string ISBN)
        {
            return api.GetBookDetailsFromISBN(ISBN);
        }
    }
}
