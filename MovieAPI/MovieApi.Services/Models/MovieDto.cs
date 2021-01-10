using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MovieApi.Omdb.Client.Models;
using RestSharp.Deserializers;
using MovieApi.Repositories.Models;

namespace MovieApi.Services.Models
{
    public class MovieDto
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Rated { get; set; }

        [JsonConverter(typeof(JustDateNoTimeConverter))]
        public DateTime? Released { get; set; }

        public int? RuntimeInMinutes { get; set; }
        public List<string> Genres { get; set; }
        public List<Person> Director { get; set; }
        public List<Person> Writers { get; set; }
        public List<Person> Actors { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Countries { get; set; }
        public string Awards { get; set; }
        public List<Ratings> Ratings { get; set; }
        public int? Metascore { get; set; }
        [DeserializeAs(Name = "imdbRating")] public double? ImdbRating { get; set; }
        [DeserializeAs(Name = "imdbVotes")] public int? ImdbVotes { get; set; }
        [DeserializeAs(Name = "imdbID")] public string ImdbId { get; set; }

        [JsonConverter(typeof(JustDateNoTimeConverter))]
        public DateTime? DVD { get; set; }

        public string Production { get; set; }
        public string Poster { get; set; }
    }
}