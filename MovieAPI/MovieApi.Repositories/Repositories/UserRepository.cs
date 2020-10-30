using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;

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
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(Queries.UserQueries.CreateUser,
                new {user.NickName, user.FirstName, user.LastName, user.Mail, user.Password});
        }

        public async Task<bool> AuthenticateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
