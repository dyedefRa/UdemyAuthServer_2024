using SharedLibrary.Dtos;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Dtos;

namespace UdemyAuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<AppUserDto>> GetUserByNameAsync(string userName);
    }
}
