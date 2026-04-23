namespace ProfileApplication.DTO.request;

public class SocialLinkRequest : BaseRequest
{
    public string Platform { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
