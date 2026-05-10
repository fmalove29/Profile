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
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileService _profileService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public ProfileController
        (
            ILogger<ProfileController> logger,
            IAuthService authService,
            IRepository<DomainProfile> repository,
            IProfileService profileService,
            IMapper mapper
        )
        {
            _logger = logger;
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
            _logger.LogInformation("UpdateProfile request received");
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);

                var userId = await _authService.GetUserIdByEmail(email);
                var userIdInGuid = Guid.Parse(userId);

                _logger.LogInformation("Updating profile for UserId {UserId}", userId);
                var existData = await _profileService.FindByIdWithConditionAsync(userId);

                if (existData == null)
                {
                    _logger.LogWarning("UpdateProfile failed: No data found for UserId {UserId}", userId);
                    return BadRequest("No Data Found");
                }

                existData.FirstName = profileRequest.FirstName;
                existData.LastName = profileRequest.LastName;
                existData.Headline = profileRequest.Headline;
                existData.Summary = profileRequest.Summary;
                existData.Location = profileRequest.Location;
                existData.Email = profileRequest.Email;
                existData.PhoneNumber = profileRequest.PhoneNumber;
                existData.ResumeUrl = profileRequest.ResumeUrl;

                //List Update
                if (profileRequest.Skills != null && profileRequest.Skills.Any())
                    foreach (var s in profileRequest.Skills)
                    {
                        if (s.Id == Guid.Empty)
                        {
                            existData.Skills.Add(new ProfileDomain.Models.Skill
                            {
                                Name = s.Name,
                                Level = s.Level
                            });
                        }
                        else
                        {
                            var existingSkills = existData.Skills.FirstOrDefault(skills => skills.Id == s.Id);
                            if (existingSkills != null)
                            {
                                existingSkills.Name = s.Name;
                                existingSkills.Level = s.Level;
                            }
                        }

                    }

                if (profileRequest.Experiences != null && profileRequest.Experiences.Any())
                    foreach (var ex in profileRequest.Experiences)
                    {
                        if (ex.Id == Guid.Empty)
                        {
                            existData.Experiences.Add(new ProfileDomain.Models.Experience
                            {
                                Company = ex.Company,
                                Position = ex.Position,
                                Description = ex.Description,
                                StartDate = ex.StartDate,
                                EndDate = ex.EndDate,
                                IsCurrent = ex.IsCurrent
                            });
                        }
                        else
                        {
                            var existExperience = existData.Experiences.FirstOrDefault(exp => exp.Id == ex.Id);
                            if (existExperience != null)
                            {
                                existExperience.Company = ex.Company;
                                existExperience.Position = ex.Position;
                                existExperience.Description = ex.Description;
                                existExperience.StartDate = ex.StartDate;
                                existExperience.EndDate = ex.EndDate;
                                existExperience.IsCurrent = ex.IsCurrent;
                            }
                        }
                    }

                if (profileRequest.Projects != null && profileRequest.Projects.Any())
                    foreach (var pr in profileRequest.Projects)
                    {
                        if (pr.Id == Guid.Empty)
                        {
                            existData.Projects.Add(new ProfileDomain.Models.Project
                            {
                                Title = pr.Title,
                                Description = pr.Description,
                                TechStack = pr.TechStack,
                                ProjectUrl = pr.ProjectUrl,
                                GithubUrl = pr.GithubUrl
                            });
                        }
                        else
                        {
                            var existProject = existData.Projects.FirstOrDefault(p => p.Id == pr.Id);
                            if (existProject != null)
                            {
                                existProject.Title = pr.Title;
                                existProject.Description = pr.Description;
                                existProject.TechStack = pr.TechStack;
                                existProject.ProjectUrl = pr.ProjectUrl;
                                existProject.GithubUrl = pr.GithubUrl;
                            }
                        }
                    }

                if (profileRequest.Educations != null && profileRequest.Educations.Any())
                    foreach (var ed in profileRequest.Educations)
                    {
                        if (ed.Id == Guid.Empty)
                        {
                            existData.Educations.Add(new ProfileDomain.Models.Education
                            {
                                School = ed.School,
                                Degree = ed.Degree,
                                StartDate = ed.StartDate,
                                EndDate = ed.EndDate
                            });
                        }
                        else
                        {
                            var existEducation = existData.Educations.FirstOrDefault(e => e.Id == ed.Id);
                            if (existEducation != null)
                            {
                                existEducation.School = ed.School;
                                existEducation.Degree = ed.Degree;
                                existEducation.StartDate = ed.StartDate;
                                existEducation.EndDate = ed.EndDate;
                            }
                        }
                    }

                if (profileRequest.SocialLinks != null && profileRequest.SocialLinks.Any())
                    foreach (var sl in profileRequest.SocialLinks)
                    {
                        if (sl.Id == Guid.Empty)
                        {
                            existData.SocialLinks.Add(new ProfileDomain.Models.SocialLink
                            {
                                Platform = sl.Platform,
                                Url = sl.Url
                            });
                        }
                        else
                        {
                            var existSocialLink = existData.SocialLinks.FirstOrDefault(s => s.Id == sl.Id);
                            if (existSocialLink != null)
                            {
                                existSocialLink.Platform = sl.Platform;
                                existSocialLink.Url = sl.Url;
                            }
                        }
                    }
                if (profileRequest.Certifications != null && profileRequest.Certifications.Any())
                    foreach (var crt in profileRequest.Certifications)
                    {
                        if (crt.Id == Guid.Empty)
                        {
                            existData.Certifications.Add(new ProfileDomain.Models.Certification
                            {
                                CredentialUrl = crt.CredentialUrl
                            });
                        }
                        else
                        {
                            var existCert = existData.Certifications.FirstOrDefault(c => c.Id == crt.Id);
                            if (existCert != null)
                            {
                                existCert.CredentialUrl = crt.CredentialUrl;
                            }
                        }

                    }

                await _profileService.Update(existData);
                await _profileService.SaveChangesAsync(userIdInGuid);
                return Ok(existData.ToProfileResponse());
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

           

            return Ok(profile.ToProfileResponse());
        }
    }
}
