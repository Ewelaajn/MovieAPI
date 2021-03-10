using Autofac;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Repositories;
using MovieApiTests.Integration.DbManager;
using MovieApiTests.Integration.DbTools;
using MovieApiTests.Integration.RepositoriesTests.DirectorRepository;
using MovieApiTests.Integration.RepositoriesTests.GenreRepository;
using NUnit.Framework;

namespace MovieApiTests.Integration
{
    [TestFixture]
    public class RepositoryTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _postgresManager.SetUpSchema();
        }

        [TearDown]
        public void TearDown()
        {
            _postgresManager.ResetSchema();
        }

        private readonly PostgresManager _postgresManager;
        protected readonly IContainer Container;
        protected readonly IDbContext DbContext;
        protected IDirectorRepository DirectorRepository;
        protected IGenreRepository GenreRepository;
        protected IMovieRepository MovieRepository;

        public RepositoryTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieRepository>()
                .As<IMovieRepository>();
            builder.RegisterType<DirectorRepository>()
                .As<IDirectorRepository>();
            builder.RegisterType<GenreRepository>()
                .As<IGenreRepository>();

            builder.RegisterType<TestDb>()
                .As<IDbContext>();

            builder.RegisterType<PostgresManager>();

            Container = builder.Build();

            DbContext = Container.Resolve<IDbContext>();
            _postgresManager = Container.Resolve<PostgresManager>();
        }
    }
}