using System.Threading.Tasks;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Services.Exceptions;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;

namespace MovieApi.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // BCrypt has "Verify" method
        public async Task<UserDto> SignUp(UserSignUpDto user)
        {
            if (!user.Password.Equals(user.PasswordConfirmation))
                throw new IncorrectPasswordConfirmationException("Passwords are different!");

            var isMailTaken = await _userRepository.IsMailTaken(user.Mail);

            if (!isMailTaken)
            {
                var userDb = new User
                {
                    NickName = user.NickName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mail = user.Mail,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                };

                var result = await _userRepository.CreateUser(userDb);

                return new UserDto
                {
                    NickName = result.NickName,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Mail = result.Mail
                };
            }

            throw new MailTakenException("This mail is already in database!");
        }
    }
}