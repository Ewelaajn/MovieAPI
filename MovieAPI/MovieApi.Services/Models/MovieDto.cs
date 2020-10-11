using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

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
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<Person> Director { get; set; }
        public IEnumerable<Person> Writers { get; set; }
        public IEnumerable<Person> Actors { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public string Awards { get; set; }
        public List<Ratings> Ratings { get; set; }
        public int? Metascore { get; set; }
        [DeserializeAs(Name = "imdbRating")] public double? ImdbRating { get; set; }
        [DeserializeAs(Name = "imdbVotes")] public int? ImdbVotes { get; set; }
        [DeserializeAs(Name = "imdbID")] public string ImdbId { get; set; }

        [JsonConverter(typeof(JustDateNoTimeConverter))]
        public DateTime? DVD { get; set; }

        public string Production { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Ratings
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class JustDateNoTimeConverter : IsoDateTimeConverter
    {
        public JustDateNoTimeConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
        }
    }
}