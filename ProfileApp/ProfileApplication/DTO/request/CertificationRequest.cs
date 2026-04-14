namespace ProfileApplication.DTO.request;

public class CertificationRequest : BaseRequest
{
    public string? CredentialUrl { get; set; }

    public Guid ProfileId { get; set; }
    public ProfileRequest? Profile { get; set; }
}
