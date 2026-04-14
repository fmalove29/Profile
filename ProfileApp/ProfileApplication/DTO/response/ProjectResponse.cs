namespace ProfileApplication.DTO.response;

public class ProjectResponse : BaseResponse
{
    public Guid ProfileId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string TechStack { get; set; } = string.Empty;
    public string ProjectUrl { get; set; } = string.Empty;
    public string GithubUrl { get; set; } = string.Empty;

    public ProfileResponse? Profile { get; set; }
}
