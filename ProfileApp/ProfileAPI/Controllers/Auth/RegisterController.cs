using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.DTO.request;
using ProfileApplication.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _authService;
        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var register = await _authService.Register(registerRequest);

            return Ok(register);
        }

    }
}
