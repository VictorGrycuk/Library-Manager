﻿using AutoMapper;
using LibraryManagementCore.BookManagement.Api;
using LibraryManagementCore.BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Library.Management.Core.Tests")]
namespace LibraryManagementCore.BookManagement
{
    internal static class Mapper
    {
        /// <summary>
        /// Convert from <see cref="GoogleBookModel"/> to <see cref="Book"/>,
        /// and back and forth between <see cref="Book"/> and <see cref="BookDB"/>.
        /// </summary>
        /// <typeparam name="TSource">The source class type. Can be <see cref="GoogleBookModel"/>, <see cref="BookDB"/>, or <see cref="Book"/>.</typeparam>
        /// <typeparam name="TDestination">The destination class type. Can be either <see cref="BookDB"/> or <see cref="Book"/>.</typeparam>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static TDestination ConvertModel<TSource, TDestination>(TSource origin) where TSource : class, new()
        {
            return GetConfiguration(origin).Map<TSource, TDestination>(origin);
        }

        private static IMapper GetConfiguration<TSource>(TSource value) where TSource : class, new()
        {
            switch (value)
            {
                case GoogleBookModel _:
                    return GetGoogleMapper();
                case BookDB _:
                    return GetBookDbMapper();
                case Book _:
                    return GetBookMapper();
                default:
                    throw new ArgumentException(value.GetType() + " not supported.");
            }
        }

        private static IMapper GetGoogleMapper()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<GoogleBookModel, Book>()
                    .ForMember(dest => dest.PublishedDate,
                        o => o.MapFrom(sou => ParseDateTime(sou.publishedDate)))
                    .ForMember(dest => dest.Isbn, o => o.MapFrom(sou => sou.industryIdentifiers[0].identifier))
                    .ForMember(destination => destination.Authors,
                        o => o.MapFrom(source => source.authors.Select(author => new Author {Name = author}).ToList()))
                    .ForMember(dest => dest.Id, o => o.MapFrom(sou => Guid.NewGuid()))
                    .ForMember(dest => dest.Cover, o => o.MapFrom(sou => GetImageByteArray(sou.imageLinks.thumbnail)));
            }).CreateMapper();
        }

        private static DateTime ParseDateTime(string strDate)
        {
            return DateTime.TryParse(strDate, out var datetime)
                ? datetime
                : new DateTime(int.Parse(strDate), 1, 1);
        }

        private static IMapper GetBookDbMapper()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<BookDB, Book>()
                    .ForMember(destination => destination.Authors, o => o.MapFrom(source => new List<Author>()));
            }).CreateMapper();
        }

        private static IMapper GetBookMapper()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<Book, BookDB>()
                    .ForMember(destination => destination.Authors, o => o.MapFrom(source => new List<Guid>()));
            }).CreateMapper();
        }

        private static byte[] GetImageByteArray(string url)
        {
            byte[] image;
            using (var webClient = new WebClient())
            {
                image = webClient.DownloadData(url.Replace("zoom=1", "zoom=2")
                    .Replace("&source=gbs_api", string.Empty));
            }

            return image;
        }
    }
}
