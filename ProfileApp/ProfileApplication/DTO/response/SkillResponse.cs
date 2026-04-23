namespace ProfileApplication.DTO.response;

public class SkillResponse : BaseResponse
{
    public Guid ProfileId { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }

    // public ProfileResponse? Profile { get; set; }
}
