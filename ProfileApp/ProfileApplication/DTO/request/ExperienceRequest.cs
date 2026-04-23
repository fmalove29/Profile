namespace ProfileApplication.DTO.request;

public class ExperienceRequest : BaseRequest
{

    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool IsCurrent { get; set; }

}
