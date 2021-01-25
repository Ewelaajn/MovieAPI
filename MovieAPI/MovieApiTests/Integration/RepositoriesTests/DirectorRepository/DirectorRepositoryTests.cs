using Autofac;
using MovieApi.Repositories.Interfaces;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests.DirectorRepository
{
    [TestFixture]
    public class DirectorRepositoryTests : RepositoryTest
    {
        [SetUp]
        public void SetUp()
        {
            DirectorRepository = Container.Resolve<IDirectorRepository>();
        }
    }
}