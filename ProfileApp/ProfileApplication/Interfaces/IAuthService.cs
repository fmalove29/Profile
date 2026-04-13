using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
namespace ProfileApplication.Interfaces;

public interface IAuthService
{
    public Task<CommonResponse> Register(RegisterRequest registerRequest);
    public Task<string> CreateToken(JwtRequest jwtRequest);

    public Task<LoginResponse> Login(LoginRequest loginRequest);
}
