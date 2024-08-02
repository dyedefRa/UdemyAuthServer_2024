using UdemyAuthServer.Core.Configuration;
using UdemyAuthServer.Core.Dtos;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto ClientClientToken(Client client);
    }
}
