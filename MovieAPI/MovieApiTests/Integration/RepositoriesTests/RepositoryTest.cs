using Autofac;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Repositories;
using MovieApiTests.Integration.DbManager;
using MovieApiTests.Integration.DbTools;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests
{
    public class RepositoryTest
    {
        private readonly PostgresManager _postgresManager;
        protected readonly IContainer Container;
        protected readonly IDbContext DbContext;

        protected IMovieRepository MovieRepository;

        public RepositoryTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieRepository>()
                .As<IMovieRepository>();

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