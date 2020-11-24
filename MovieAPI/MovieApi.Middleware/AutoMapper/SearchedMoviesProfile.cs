using AutoMapper;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Middleware.AutoMapper
{
    public class SearchedMoviesProfile : Profile
    {
        public SearchedMoviesProfile()
        {
            CreateMap<SigleFoundItem, FoundMoviesDto>()
                .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Year,
                opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.ImdbID, 
                opt => opt.MapFrom(src => src.ImdbID))
                .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Poster,
                opt => opt.MapFrom(src => src.Poster));
        }
    }
}
