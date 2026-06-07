namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Experience
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Code { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ExperienceResponsibility> ExperienceResponsibilities { get; set; } = new List<ExperienceResponsibility>();

    public virtual ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = new List<ExperienceTechnology>();

    public virtual Profile Profile { get; set; } = null!;
}
