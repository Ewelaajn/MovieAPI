using Autofac;
using MovieApi.Repositories.Interfaces;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests.GenreRepository
{
    [TestFixture]
    public class GenreRepositoryTests : RepositoryTest
    {
        [SetUp]
        public void SetUp()
        {
            GenreRepository = Container.Resolve<IGenreRepository>();
        }
    }
}