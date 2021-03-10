using System;
using System.Threading.Tasks;
using Dapper;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;

namespace MovieApi.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            return await _dbContext.Connection.QueryFirstAsync<User>(UserQueries.CreateUser,
                new {user.NickName, user.FirstName, user.LastName, user.Mail, user.Password});
        }

        public async Task<User> GetUserByMail(string mail)
        {
            return await _dbContext.Connection
                .QueryFirstOrDefaultAsync<User>(UserQueries.GetUserByMail, new {mail});
        }

        public Task<string> FetchPassword(string mail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMailTaken(string mail)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<bool>
                (UserQueries.IsMailTaken, new {mail});
        }
    }
}