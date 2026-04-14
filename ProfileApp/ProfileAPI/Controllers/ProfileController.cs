using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.Interfaces;
using ProfileApplication.DTO.request;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileRequest profileRequest)
        {
            return Ok("Logged");
        }
    }
}
