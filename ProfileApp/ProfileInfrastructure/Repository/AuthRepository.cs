using ProfileApplication.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ProfileApplication.DTO.request;
using ProfileDomain.Models;
using ProfileInfrastructure.DataContext;
using ProfileApplication.DTO.request;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using ProfileApplication.DTO.response;


namespace ProfileInfrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    public AuthRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
        _configuration = configuration;
    }


    public async Task<string> Register(RegisterRequest registerRequest)
    {
        // return "Test";
        var user = new ApplicationUser
        {
            UserName = registerRequest.Email,
            Email = registerRequest.Email

        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
        {
            return string.Join(",", result.Errors.Select(e => e.Description));
        }

        return "Success";
    }
    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            return new LoginResponse
            {
                IsSuccess = false,
                Token = null
            };
        }

        var token = await CreateToken(new JwtRequest
        {
            Email = loginRequest.Email,
            Password = loginRequest.Password
        });

        return new LoginResponse
        {
            IsSuccess = true,
            Message = "Login successful",
            Token = token
        };
    }
    public async Task<string> CreateToken(JwtRequest jwtRequest)
    {
        var user = await _userManager.FindByEmailAsync(jwtRequest.Email);

        if (user == null)
            return "User not found";

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, jwtRequest.Password);

        if (!isPasswordValid)
            return "Invalid credentials";

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(100),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GetUserIdByEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user.Id;
    }
}
