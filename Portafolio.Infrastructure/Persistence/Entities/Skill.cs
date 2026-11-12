namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Skill
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public Guid SkillCategoryId { get; set; }

    public Guid? FatherId { get; set; }

    public string? Icon { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AdditionalSkill> AdditionalSkills { get; set; } = new List<AdditionalSkill>();

    public virtual ICollection<ExperienceSkill> ExperienceSkills { get; set; } = new List<ExperienceSkill>();

    public virtual Skill? Father { get; set; }

    public virtual ICollection<Skill> InverseFather { get; set; } = new List<Skill>();

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();

    public virtual SkillsCategory SkillCategory { get; set; } = null!;
}
