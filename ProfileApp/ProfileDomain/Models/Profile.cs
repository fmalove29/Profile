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

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
    public virtual ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();
}
