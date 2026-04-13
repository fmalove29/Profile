namespace ProfileDomain.Models;

public class Experience : BaseEntity
{
    public Guid ProfileId { get; set; }

    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool IsCurrent { get; set; }

    public Profile? Profile { get; set; }
}
