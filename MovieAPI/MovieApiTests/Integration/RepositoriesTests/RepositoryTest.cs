using Autofac;
using MovieApi.Repositories.Interfaces;
using MovieApiTests.Integration.DbManager;
using MovieApiTests.Integration.DbTools;
using MovieApiTests.Integration.RepositoriesTests.DirectorRepository;
using MovieApiTests.Integration.RepositoriesTests.GenreRepository;
using MovieApiTests.Integration.RepositoriesTests.MovieRepository;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests
{
    public class RepositoryTest
    {
        private readonly PostgresManager _postgresManager;
        protected readonly IContainer Container;
        protected readonly IDbContext DbContext;
        protected IDirectorRepository DirectorRepository;
        protected IGenreRepository GenreRepository;
        protected IMovieRepository MovieRepository;

        public RepositoryTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieRepositoryTests>()
                .As<IMovieRepository>();
            builder.RegisterType<DirectorRepositoryTests>()
                .As<IDirectorRepository>();
            builder.RegisterType<GenreRepositoryTests>()
                .As<IGenreRepository>();

            builder.RegisterType<TestDb>()
                .As<IDbContext>();

            builder.RegisterType<PostgresManager>();

            Container = builder.Build();

            DbContext = Container.Resolve<IDbContext>();
            _postgresManager = Container.Resolve<PostgresManager>();
        }

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
    }
}