namespace ProfileDomain.Models;

public class Profile : BaseEntity
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

    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Education> Educations { get; set; } = new List<Education>();
    public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();
}
