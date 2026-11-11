using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Experience
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Company { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string Responsibility { get; set; } = null!;

    public bool Collapse { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ExperienceSkill> ExperienceSkills { get; set; } = new List<ExperienceSkill>();

    public virtual Profile Profile { get; set; } = null!;
}
