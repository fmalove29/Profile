namespace ProfileDomain.Models;

public class Skill : BaseEntity
{
    public Guid ProfileId { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }

    public Profile? Profile { get; set; }
}
