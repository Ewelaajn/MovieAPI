using System.ComponentModel;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;

namespace MovieApi.Omdb.Client
{
    public interface IOmdbClient
    {
        Task<SearchResult> SearchVideoByTitle(string title, int page=1, string type="movie");
        /*Task<Movie> GetMovieById(int id, string type="movie");*/
        Task<Movie> SingleMovieByTitle(string title, string type="movie");
    }
}