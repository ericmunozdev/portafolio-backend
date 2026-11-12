using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class SkillsCategory
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
