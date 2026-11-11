using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Profile
{
    public Guid Id { get; set; }

    public string WebTitle { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? WorkPosition { get; set; }

    public string Presentation { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AdditionalSkill> AdditionalSkills { get; set; } = new List<AdditionalSkill>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Other> Others { get; set; } = new List<Other>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<SkillsCategory> SkillsCategories { get; set; } = new List<SkillsCategory>();
}
