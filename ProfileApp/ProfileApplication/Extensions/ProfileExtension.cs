using ProfileApplication.DTO.request;
using ProfileApplication.DTO.response;
using DomainProfile = ProfileDomain.Models.Profile;
using ProfileDomain.Models;
namespace ProfileApplication.Extensions;

public static class ProfileExtension
{
    public static Profile ToDomain(this ProfileRequest profileRequest)
    => new Profile
    {
        UserId = profileRequest.UserId,
        FirstName = profileRequest.FirstName,
        LastName = profileRequest.LastName,
        Headline = profileRequest.Headline,
        Summary = profileRequest.Summary,
        Location = profileRequest.Location,
        Email = profileRequest.Email,
        PhoneNumber = profileRequest.PhoneNumber,
        ResumeUrl = profileRequest.ResumeUrl,

        Skills = profileRequest.Skills?
            .Select(x => new Skill
            {
                Name = x.Name,
                Level = x.Level
            }).ToList() ?? new List<Skill>(),

        Experiences = profileRequest.Experiences?
            .Select(x => new Experience
            {
                Company = x.Company,
                Position = x.Position,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList() ?? new List<Experience>(),

        Projects = profileRequest.Projects?
            .Select(x => new Project
            {
                Title = x.Title,
                Description = x.Description
            }).ToList() ?? new List<Project>(),

        Educations = profileRequest.Educations?
            .Select(x => new Education
            {
                School = x.School,
                Degree = x.Degree
            }).ToList() ?? new List<Education>(),

        SocialLinks = profileRequest.SocialLinks?
            .Select(x => new SocialLink
            {
                Platform = x.Platform,
                Url = x.Url
            }).ToList() ?? new List<SocialLink>(),

        Certifications = profileRequest.Certifications?
            .Select(x => new Certification
            {
                CredentialUrl = x.CredentialUrl
            }).ToList() ?? new List<Certification>()
    };

    public static void UpdateFromRequest(this Profile profile, ProfileRequest request)
    {
        // Scalar fields (safe to overwrite)
        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.Headline = request.Headline;
        profile.Summary = request.Summary;
        profile.Location = request.Location;
        profile.Email = request.Email;
        profile.PhoneNumber = request.PhoneNumber;
        profile.ResumeUrl = request.ResumeUrl;

        // 🔥 Collections (simple replace strategy)

        profile.Skills.Clear();
        if (request.Skills != null)
        {
            profile.Skills = request.Skills
                .Select(x => new Skill
                {
                    Name = x.Name,
                    Level = x.Level
                }).ToList();
        }

        profile.Experiences.Clear();
        if (request.Experiences != null)
        {
            profile.Experiences = request.Experiences
                .Select(x => new Experience
                {
                    Company = x.Company,
                    Position = x.Position,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }).ToList();
        }

        profile.Projects.Clear();
        if (request.Projects != null)
        {
            profile.Projects = request.Projects
                .Select(x => new Project
                {
                    Title = x.Title,
                    Description = x.Description
                }).ToList();
        }

        profile.Educations.Clear();
        if (request.Educations != null)
        {
            profile.Educations = request.Educations
                .Select(x => new Education
                {
                    School = x.School,
                    Degree = x.Degree
                }).ToList();
        }

        profile.SocialLinks.Clear();
        if (request.SocialLinks != null)
        {
            profile.SocialLinks = request.SocialLinks
                .Select(x => new SocialLink
                {
                    Platform = x.Platform,
                    Url = x.Url
                }).ToList();
        }

        profile.Certifications.Clear();
        if (request.Certifications != null)
        {
            profile.Certifications = request.Certifications
                .Select(x => new Certification
                {
                    CredentialUrl = x.CredentialUrl
                }).ToList();
        }
    }

    public static ProfileResponse ToProfileResponse(this Profile profile)
    => new ProfileResponse
    {
        Id = profile.Id,
        UserId = profile.UserId,
        FirstName = profile.FirstName,
        LastName = profile.LastName,
        Headline = profile.Headline,
        Summary = profile.Summary,
        Location = profile.Location,
        Email = profile.Email,
        PhoneNumber = profile.PhoneNumber,
        ResumeUrl = profile.ResumeUrl,

        Skills = profile.Skills?
            .Select(x => new SkillResponse
            {
                Id = x.Id,
                Name = x.Name,
                Level = x.Level
            }).ToList() ?? new List<SkillResponse>(),

        Experiences = profile.Experiences?
            .Select(x => new ExperienceResponse
            {
                Id = x.Id,
                Company = x.Company,
                Position = x.Position,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList() ?? new List<ExperienceResponse>(),

        Projects = profile.Projects?
            .Select(x => new ProjectResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToList() ?? new List<ProjectResponse>(),

        Educations = profile.Educations?
            .Select(x => new EducationResponse
            {
                Id = x.Id,
                School = x.School,
                Degree = x.Degree
            }).ToList() ?? new List<EducationResponse>(),

        SocialLinks = profile.SocialLinks?
            .Select(x => new SocialLinkResponse
            {
                Id = x.Id,
                Platform = x.Platform,
                Url = x.Url
            }).ToList() ?? new List<SocialLinkResponse>(),

        Certifications = profile.Certifications?
            .Select(x => new CertificationResponse
            {
                CredentialUrl = x.CredentialUrl
            }).ToList() ?? new List<CertificationResponse>()
    };
}
