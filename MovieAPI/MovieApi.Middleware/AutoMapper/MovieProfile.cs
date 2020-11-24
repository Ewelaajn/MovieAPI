using AutoMapper;
using MovieApi.Middleware.MovieParsers;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApi.Middleware.AutoMapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            IBasePropertyParser propertyParser = new BasePropertyParser();
            IMovieParser movieParser = new MovieParser();
            CreateMap<Movie, MovieDto>()

                // PersonParser
                .ForMember(dest => dest.Actors,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToPerson(movie.Actors)))
                .ForMember(dest => dest.Director,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToPerson(movie.Director)))
                .ForMember(dest => dest.Writers,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToPerson(movie.Writer)))
                
                // IntParser
                .ForMember(dest => dest.Year,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToInt(movie.Year)))
                .ForMember(dest => dest.Metascore,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToInt(movie.Metascore)))
                .ForMember(dest => dest.ImdbVotes,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToInt(movie.ImdbVotes)))
                
                // StringToListParser
                .ForMember(dest => dest.Genres,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToList(movie.Genre)))
                .ForMember(dest => dest.Languages,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToList(movie.Language)))
                .ForMember(dest => dest.Countries,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToList(movie.Country)))
                
                // DateTimeParser
                .ForMember(dest => dest.Released,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToDateTime(movie.Released)))
                .ForMember(dest => dest.DVD,
                    opt => opt.MapFrom(movie => movieParser.ParseStringToDateTime(movie.DVD)))
                
                // RuntimeParser
                .ForMember(dest => dest.RuntimeInMinutes,
                    opt => opt.MapFrom(movie => movieParser.ParseRuntimeToInt(movie.Runtime)))

                // The same types in normal and dto model
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(movie => propertyParser.Parse(movie.Title)))
                .ForMember(dest => dest.Rated,
                    opt => opt.MapFrom(movie => propertyParser.Parse(movie.Rated)))
                .ForMember(dest => dest.Awards,
                    opt => opt.MapFrom(movie => propertyParser.Parse(movie.Awards)))
                .ForMember(dest => dest.ImdbId,
                    opt => opt.MapFrom(movie => propertyParser.Parse(movie.ImdbId)))
                .ForMember(dest => dest.Production,
                    opt => opt.MapFrom(movie => propertyParser.Parse(movie.Production)))
                .ForMember(dest => dest.Ratings,
                    opt => opt.MapFrom(movie => movie.Ratings))
                .ForMember(dest => dest.ImdbRating,
                    opt => opt.MapFrom(movie => movie.ImdbRating));
        }
    }
}