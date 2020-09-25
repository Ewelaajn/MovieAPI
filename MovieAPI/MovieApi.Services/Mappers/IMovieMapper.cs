using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers
{
    public interface IMovieMapper
    {
        Task<MovieDto> MovieToDtoMapper(Movie movie);
    }
}
