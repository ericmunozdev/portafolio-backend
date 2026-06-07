namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Profile
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Additional> Additionals { get; set; } = new List<Additional>();

    public virtual ICollection<Condition> Conditions { get; set; } = new List<Condition>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<SkillCategory> SkillCategories { get; set; } = new List<SkillCategory>();

    public virtual ICollection<Summary> Summaries { get; set; } = new List<Summary>();
}
