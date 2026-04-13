namespace ProfileDomain.Models;

public class Education : BaseEntity
{
    public Guid ProfileId { get; set; }

    public string School { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Profile? Profile { get; set; }
}
