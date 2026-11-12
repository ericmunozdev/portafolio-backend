namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class ProjectSkill
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid SkillId { get; set; }

    public short MonthsExperience { get; set; }

    public bool IsActive { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
