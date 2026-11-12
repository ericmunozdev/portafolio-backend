namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class ExperienceSkill
{
    public Guid Id { get; set; }

    public Guid ExperienceId { get; set; }

    public Guid SkillId { get; set; }

    public short MonthsExperience { get; set; }

    public bool IsActive { get; set; }

    public virtual Experience Experience { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
