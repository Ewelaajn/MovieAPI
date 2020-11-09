using System.Collections.Generic;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy.Parsers
{
    public interface IPersonParser
    {
        List<Person> ParsePerson(string people);
    }
}