namespace ProfileApplication.DTO.request;

public class SkillRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
}
