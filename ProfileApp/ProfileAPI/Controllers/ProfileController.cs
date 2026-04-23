using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.Interfaces;
using ProfileApplication.DTO.request;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ProfileDomain.Models;
using ProfileApplication.Mappings;
using DomainProfile = ProfileDomain.Models.Profile;
using AutoMapper;
using ProfileApplication.DTO.response;
using ProfileApplication.Extensions;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public ProfileController(IAuthService authService, IRepository<DomainProfile> repository, IProfileService profileService, IMapper mapper)
        {
            _authService = authService;
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProfile([FromBody] ProfileRequest profileRequest)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                var userId = await _authService.GetUserIdByEmail(email);
                var userIdInGuid = Guid.Parse(userId);


                var dataBind = profileRequest.ToDomain();
                var pr = await _profileService.Add(dataBind);
                await _profileService.SaveChangesAsync(userIdInGuid);

                return Ok(dataBind);



                return Ok(profileRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileRequest profileRequest)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                var userId = await _authService.GetUserIdByEmail(email);
                var userIdInGuid = Guid.Parse(userId);

                var r = await _profileService.FindByIdWithConditionAsync(userId);

                if (r == null)
                {
                    return BadRequest("No Data Found");
                }
                await _profileService.Update(profileRequest.ToDomain());
                await _profileService.SaveChangesAsync(userIdInGuid);
                return Ok(r);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetProfile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var userId = await _authService.GetUserIdByEmail(email);
            var userIdInGuid = Guid.Parse(userId);

            var profile = await _profileService.FindByIdWithConditionAsync(userId);

            return Ok(profile);
        }
    }
}
