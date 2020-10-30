using System;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;
using System.Threading.Tasks;
using MovieApi.Repositories.Interfaces;

namespace MovieApi.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserDto> SignUp(UserSignUpDto user)
        {
            throw new NotImplementedException();
        }
    }
}
