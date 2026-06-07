using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class SkillCategory
{
    public short Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public bool IsActive { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
