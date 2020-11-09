using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy
{
    public interface IMovieMapperStrategy
    {
        Task<MovieDto> Process(Movie movie);
    }
}