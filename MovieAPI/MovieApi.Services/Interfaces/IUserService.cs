using System.Threading.Tasks;
using MovieApi.Services.Models;

namespace MovieApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> SignUp(UserSignUpDto user);
    }
}