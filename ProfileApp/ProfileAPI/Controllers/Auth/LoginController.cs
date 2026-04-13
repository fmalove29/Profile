using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.DTO.request;
using ProfileApplication.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRquest)
        {
            var log = await _authService.Login(loginRquest);
            return Ok(log);
        }
    }
}
