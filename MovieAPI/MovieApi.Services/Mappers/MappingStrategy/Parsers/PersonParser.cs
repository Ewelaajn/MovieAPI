using System.Collections.Generic;
using System.Linq;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy.Parsers
{
    public class PersonParser : IPersonParser
    {
        public List<Person> ParsePerson(string people)
        {
            var splitedPeople = people.Split(',')
                .Select(person => person.Trim());

            var splitedNames = splitedPeople
                .Select(names => names.Split(' ')
                    .Select(name => name.Trim()));

            var newPeople = splitedNames
                .Select(names => names
                    .Where(name => !name.StartsWith("(")).ToList())
                .Select(names =>
                {
                    if (names.Count == 3)
                        return new Person
                        {
                            FirstName = names[0],
                            LastName = names[2]
                        };
                    return new Person
                    {
                        FirstName = names[0],
                        LastName = names[1]
                    };
                }).ToList();

            return newPeople;
        }
    }
}