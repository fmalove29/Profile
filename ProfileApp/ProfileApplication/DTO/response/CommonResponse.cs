namespace ProfileApplication.DTO.response;

public class CommonResponse
{
    public bool? IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;

    public string? CostumString { get; set; }

}
