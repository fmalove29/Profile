namespace ProfileApplication.DTO.request;

public class EducationRequest : BaseRequest
{

    public string School { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

}
