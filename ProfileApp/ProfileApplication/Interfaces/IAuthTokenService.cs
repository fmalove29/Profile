using ProfileApplication.DTO.request;
namespace ProfileApplication.Interfaces;

public interface IAuthTokenService
{
    Task<string> CreateToken(JwtRequest jwtRequest);
}
