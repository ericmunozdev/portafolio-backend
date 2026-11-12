namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class AdditionalSkill
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public Guid SkillId { get; set; }

    public string? Content { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
