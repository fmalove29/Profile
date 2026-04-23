namespace ProfileApplication.DTO.response;

public class ProfileResponse : BaseResponse
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

    public ICollection<SkillResponse>? Skills { get; set; }
    public ICollection<ExperienceResponse>? Experiences { get; set; }
    public ICollection<ProjectResponse>? Projects { get; set; }
    public ICollection<EducationResponse>? Educations { get; set; }
    public ICollection<SocialLinkResponse>? SocialLinks { get; set; }
    public ICollection<CertificationResponse>? Certifications { get; set; }
}
