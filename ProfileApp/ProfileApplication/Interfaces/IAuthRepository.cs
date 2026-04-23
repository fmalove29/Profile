using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
namespace ProfileApplication.Interfaces;

public interface IAuthRepository
{
    public Task<string> Register(RegisterRequest registerRequest);
    public Task<string> CreateToken(JwtRequest jwtRequest);

    public Task<LoginResponse> Login(LoginRequest loginRequest);

    public Task<string> GetUserIdByEmail(string Email);
}
