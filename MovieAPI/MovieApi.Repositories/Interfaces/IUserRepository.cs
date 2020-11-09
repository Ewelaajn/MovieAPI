using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<string> FetchPassword(string mail);
        Task<bool> IsMailTaken(string mail);
    }
}