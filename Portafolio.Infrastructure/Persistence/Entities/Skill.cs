using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Skill
{
    public short Id { get; set; }

    public short SkillCategoryId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public bool IsVisibleGral { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AdditionalTechnology> AdditionalTechnologies { get; set; } = new List<AdditionalTechnology>();

    public virtual ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = new List<ExperienceTechnology>();

    public virtual SkillCategory SkillCategory { get; set; } = null!;
}
