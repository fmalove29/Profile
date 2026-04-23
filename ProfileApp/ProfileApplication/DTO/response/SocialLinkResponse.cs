namespace ProfileApplication.DTO.response;

public class SocialLinkResponse : BaseResponse
{
    public Guid ProfileId { get; set; }

    public string Platform { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    // public ProfileResponse? Profile { get; set; }
}
