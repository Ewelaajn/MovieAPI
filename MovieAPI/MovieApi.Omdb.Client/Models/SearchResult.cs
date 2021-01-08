using System.Collections.Generic;
using RestSharp.Deserializers;

namespace MovieApi.Omdb.Client.Models
{
    public class SearchResult
    {
        public List<SingleFoundItem> Search { get; set; }
    }

    public class SingleFoundItem
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        [DeserializeAs(Name = "imdbID")] public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}