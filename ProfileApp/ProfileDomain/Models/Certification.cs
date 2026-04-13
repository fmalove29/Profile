namespace ProfileDomain.Models;

public class Certification : BaseEntity
{
    public string? CredentialUrl { get; set; }

    public Guid ProfileId { get; set; }
    public Profile? Profile { get; set; }
}
