namespace ProfileApplication.DTO.response;

public class CertificationResponse : BaseResponse
{
    public string? CredentialUrl { get; set; }

    public Guid ProfileId { get; set; }
    // public ProfileResponse? Profile { get; set; }
}
