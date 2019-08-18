using System;
using System.Collections.Generic;
using LibraryManagementCore.Models;
using LiteDB;
using Newtonsoft.Json;

namespace LibraryManagementCore.API
{
    public class GoogleRootObject
    {
        public int totalItems { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        [JsonProperty("VolumeInfo")]
        public GoogleBookModel GoogleBookModel { get; set; }
    }

    [JsonObject(Title = "VolumeInfo")]
    public class GoogleBookModel : IBook
    {
        [BsonIgnore]
        public string[] authors { get; set; }

        [BsonIgnore]
        public string publishedDate { get; set; }

        [BsonIgnore]
        public Industryidentifier[] industryIdentifiers { get; set; }

        [BsonIgnore]
        public Imagelinks imageLinks { get; set; }

        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string[] categories { get; set; }
        public float AverageRating { get; set; }
        public string MaturityRating { get; set; }
        public string Language { get; set; }

        public string ID { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<Author> Authors { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }

    public class Industryidentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public class Saleinfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
    }
}
