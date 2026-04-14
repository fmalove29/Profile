namespace ProfileApplication.DTO.request;

public class SocialLinkRequest : BaseRequest
{
    public Guid ProfileId { get; set; }

    public string Platform { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public ProfileRequest? Profile { get; set; }
}
