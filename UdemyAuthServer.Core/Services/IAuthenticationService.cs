using SharedLibrary.Dtos;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Dtos;

namespace UdemyAuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshAsync(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken);

        Task<Response<ClientTokenDto>> CreateClientTokenAsync(ClientTokenDto clientTokenDto);

    }
}
