using ProfileApplication.DTO.request;
using ProfileDomain.Interfaces;
using ProfileApplication.Interfaces;
using ProfileDomain.Models;
using ProfileApplication.DTO.response;
namespace ProfileApplication.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    // public Task<IEnumerable<ApplicationUser>> GetAllAsync()
    // {

    // }

    public async Task<CommonResponse> Register(RegisterRequest registerRequest)
    {
        var register = await _authRepository.Register(registerRequest);

        var result = new CommonResponse
        {
            Message = register
        };

        return result;
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var log = await _authRepository.Login(loginRequest);

        var logResponse = new LoginResponse
        {
            Message = "Logged In successfully",
            Token = log.Token
        };

        return logResponse;
    }

    public async Task<string> CreateToken(JwtRequest jwtRequest)
    {
        var token = await _authRepository.CreateToken(jwtRequest);

        return token;
    }
}
