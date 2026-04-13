namespace ProfileDomain.Models;

public class SocialLink : BaseEntity
{
    public Guid ProfileId { get; set; }

    public string Platform { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public Profile? Profile { get; set; }
}
