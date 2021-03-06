﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers
{
    public class MovieMapper : IMovieMapper
    {
        /*private readonly IMovieMapperStrategy _movieMapperStrategy;

        public MovieMapper(IMovieMapperStrategy movieMapperStrategy)
        {
            _movieMapperStrategy = movieMapperStrategy;
        }*/

        public async Task<MovieDto> MovieToDtoMapper(Movie movie)
        {
            var movieDto = new MovieDto
            {
                Title = movie.Title,
                Year = await ParseYear(movie.Year),
                Rated = movie.Rated,
                Released = await ParseStringToDateTime(movie.Released),
                RuntimeInMinutes = await ParseRuntime(movie.Runtime),
                Genres = await ParseGenre(movie.Genre),
                Director = await ParsePerson(movie.Director),
                Writers = await ParsePerson(movie.Writer),
                Actors = await ParsePerson(movie.Actors),
                Languages = await ParseStringToEnumerable(movie.Language),
                Countries = await ParseStringToEnumerable(movie.Country),
                Awards = movie.Awards,
                Ratings = movie.Ratings,
                Metascore = await ParseMetascore(movie.Metascore),
                ImdbRating = movie.ImdbRating,
                ImdbVotes = await ParseImdbVotes(movie.ImdbVotes),
                ImdbId = movie.ImdbId,
                DVD = await ParseStringToDateTime(movie.DVD),
                Production = movie.Production
            };

            return movieDto;

            /*return await _movieMapperStrategy.Process(movie);*/
        }

        private Task<int?> ParseRuntime(string value)
        {
            var minutesInString = value.Split(' ')[0];

            if (int.TryParse(minutesInString, out var minutes)) return Task.FromResult<int?>(minutes);

            return Task.FromResult<int?>(null);
        }

        private Task<IEnumerable<string>> ParseGenre(string genreString)
        {
            var genres = genreString.Split(',');

            return Task.FromResult(genres.Select(genre => genre.Trim()));
        }

        private Task<IEnumerable<Person>> ParsePerson(string personString)
        {
            var people = personString.Split(',');
            var peopleList = people.Select(person =>
            {
                var result = person.Trim().Split(' ')
                    .Select(singleName => singleName.Trim()).ToList();
                if (result.Count <= 2 || result[2].StartsWith("("))
                    return new Person
                    {
                        FirstName = result[0],
                        LastName = result[1]
                    };
                return new Person
                {
                    FirstName = string.Join(" ", result[0], result[1]),
                    LastName = result[2]
                };
            });

            return Task.FromResult(peopleList);
        }

        private Task<IEnumerable<string>> ParseStringToEnumerable(string longString)
        {
            var enumerableString = longString.Split(',')
                .Select(name => name.Trim());

            return Task.FromResult(enumerableString);
        }

        private Task<int?> ParseMetascore(string metascoreString)
        {
            if (int.TryParse(metascoreString, out var metascore))
                return Task.FromResult<int?>(metascore);

            return Task.FromResult<int?>(null);
        }

        private Task<int?> ParseYear(string yearString)
        {
            if (int.TryParse(yearString, out var year))
                return Task.FromResult<int?>(year);

            return Task.FromResult<int?>(null);
        }

        private Task<int?> ParseImdbVotes(string votesString)
        {
            var votesAsString = votesString.Replace(",", string.Empty);

            if (int.TryParse(votesAsString, out var votes))
                return Task.FromResult<int?>(votes);

            return Task.FromResult<int?>(null);
        }

        private Task<DateTime?> ParseStringToDateTime(string dateString)
        {
            if (DateTime.TryParse(dateString, out var date))
                return Task.FromResult<DateTime?>(date);

            return Task.FromResult<DateTime?>(null);
        }
    }
}