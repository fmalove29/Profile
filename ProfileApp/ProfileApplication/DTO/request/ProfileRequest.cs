namespace ProfileApplication.DTO.request;

public class ProfileRequest : BaseRequest
{
    public string UserId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Headline { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string ResumeUrl { get; set; } = string.Empty;

    public ICollection<SkillRequest> Skills { get; set; }
    public ICollection<ExperienceRequest> Experiences { get; set; }
    public ICollection<ProjectRequest> Projects { get; set; }
    public ICollection<EducationRequest> Educations { get; set; }
    public ICollection<SocialLinkRequest> SocialLinks { get; set; }
    public ICollection<CertificationRequest> Certifications { get; set; }
}
