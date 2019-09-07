using System.Linq;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;

namespace LibraryManagementCore.BookManagement
{
    public class BookManagement
    {
        private readonly BookManagementDB bookCollection;
        private readonly Mapper mapper;

        public BookManagement(string connectionString)
        {
            bookCollection = new BookManagementDB(connectionString);
            mapper = new Mapper(bookCollection);
        }

        public Book GetBookFromApi(string isbn)
        {
            var googleBook = GoogleApi.FindBook(isbn);

            return mapper.ConvertModel<GoogleBookModel, Book>(googleBook);
        }

        public void AddBookToCollection(Book book)
        {
            bookCollection.Add(mapper.ConvertModel<Book, BookDB>(book));
        }

        public void AddAuthorToCollection(Author author)
        {
            bookCollection.Add(author);
        }

        public Book FindBookInCollection(string field, string value)
        {
            return mapper.ConvertModel<BookDB, Book>(bookCollection.Find<BookDB>(field, value).FirstOrDefault());
        }

        public Author FindAuthorInCollection(string field, string value)
        {
            return bookCollection.Find<Author>(field, value).FirstOrDefault();
        }

        public void RemoveBookFromCollection(Book book)
        {
            bookCollection.Delete(mapper.ConvertModel<Book, BookDB>(book));
        }

        public void RemoveAuthorFromCollection(Author author)
        {
            bookCollection.Delete(author);
        }

        public void Update(Author author)
        {
            bookCollection.Update(author);
        }

        public void Update(Book book)
        {
            bookCollection.Update(mapper.ConvertModel<Book, BookDB>(book));
        }

        public void Disconnect()
        {
            bookCollection.Close();
            mapper.Dispose();
        }
    }
}
