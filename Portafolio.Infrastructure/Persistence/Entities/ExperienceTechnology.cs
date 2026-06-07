namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class ExperienceTechnology
{
    public Guid Id { get; set; }

    public Guid ExperienceId { get; set; }

    public short SkillId { get; set; }

    public bool IsActive { get; set; }

    public virtual Experience Experience { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
