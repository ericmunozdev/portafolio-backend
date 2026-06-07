namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Contact
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? Icon { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
