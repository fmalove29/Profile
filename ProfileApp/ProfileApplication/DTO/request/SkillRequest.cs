namespace ProfileApplication.DTO.request;

public class SkillRequest : BaseRequest
{
    public Guid ProfileId { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }

    public ProfileRequest? Profile { get; set; }
}
