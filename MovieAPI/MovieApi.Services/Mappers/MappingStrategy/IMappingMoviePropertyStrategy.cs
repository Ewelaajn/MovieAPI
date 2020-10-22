using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy
{
    public interface IMappingMoviePropertyStrategy<Ti,To>
    {
        To Process(Ti property);
    }
}
