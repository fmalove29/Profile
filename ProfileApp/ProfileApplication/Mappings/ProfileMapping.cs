using AutoMapper;
using ProfileApplication.DTO;
using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
using DomainProfile = ProfileDomain.Models.Profile;
using ProfileDomain.Models;

namespace ProfileApplication.Mappings
{
    public class ProfileMapping : AutoMapper.Profile
    {
        public ProfileMapping()
        {
            CreateMap<ProfileRequest, DomainProfile>();
            CreateMap<SkillRequest, Skill>();
            CreateMap<ExperienceRequest, Experience>();
            CreateMap<ProjectRequest, Project>();
            CreateMap<EducationRequest, Education>();
            CreateMap<SocialLinkRequest, SocialLink>();
            CreateMap<CertificationRequest, Certification>();


            CreateMap<DomainProfile, ProfileResponse>();
            CreateMap<Skill, SkillResponse>();
            CreateMap<Experience, ExperienceResponse>();
            CreateMap<Project, ProjectResponse>();
            CreateMap<Education, EducationResponse>();
            CreateMap<SocialLink, SocialLinkResponse>();
            CreateMap<Certification, CertificationResponse>();
        }
    }
}