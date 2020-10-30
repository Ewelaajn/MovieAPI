using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<bool> AuthenticateUser(User user);
    }
}
