using AutoMapper;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Library.Management.Core.Tests")]
namespace LibraryManagementCore.BookManagement
{
    internal class Mapper : IDisposable
    {
        private readonly BookManagementDB db;
        private readonly IMapper mapper;

        public Mapper(BookManagementDB dB)
        {
            db = dB;

            mapper = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<GoogleBookModel, Book>()
                .ForMember(destination => destination.PublishedDate, o => o.MapFrom(source => new DateTime(int.Parse(source.publishedDate), 1, 1)))
                .ForMember(destination => destination.Isbn, o => o.MapFrom(source => source.industryIdentifiers[0].identifier))
                .ForMember(destination => destination.Authors, o => o.MapFrom(source => GetGoogleBookAuthors(source.authors)));

                configuration.CreateMap<BookDB, Book>()
                .ForMember(destination => destination.Authors, o => o.MapFrom(source => GetAuthorsFromDB(source.Authors)));

                configuration.CreateMap<Book, BookDB>()
                .ForMember(destination => destination.Authors, o => o.MapFrom(source => source.Authors.Select(a => a.ID).ToList()));
            }).CreateMapper();
        }

        /// <summary>
        /// Convert from <see cref="GoogleBookModel"/> to <see cref="Book"/>,
        /// and back and forth between <see cref="Book"/> and <see cref="BookDB"/>.
        /// </summary>
        /// <typeparam name="Source">The source class type. Can be <see cref="GoogleBookModel"/>, <see cref="BookDB"/>, or <see cref="Book"/>.</typeparam>
        /// <typeparam name="Destination">The destination class type. Can be either <see cref="BookDB"/> or <see cref="Book"/>.</typeparam>
        /// <param name="origin"></param>
        /// <returns></returns>
        public Destination ConvertModel<Source, Destination>(Source origin) where Source : class, new()
        {
            return mapper.Map<Source, Destination>(origin);
        }

        private List<Author> GetGoogleBookAuthors(string[] authors)
        {
            var authorList = new List<Author>();

            foreach (var author in authors)
            {
                authorList.Add(GetAuthor("Name", author) ?? new Author { Name = author, ID = Guid.NewGuid() });
            }

            return authorList;
        }

        private List<Author> GetAuthorsFromDB(List<Guid> authors)
        {
            var authorList = new List<Author>();

            foreach (var author in authors)
            {
                authorList.Add(GetAuthor(author) ?? new Author { ID = Guid.NewGuid() });
            }

            return authorList;
        }

        private Author GetAuthor(string field, string value)
        {
            return db.Find<Author>(field, value).FirstOrDefault();
        }

        private Author GetAuthor(Guid value)
        {
            return db.Find<Author>(value);
        }

        public void Dispose()
        {
            db.Close();
        }
    }
}
