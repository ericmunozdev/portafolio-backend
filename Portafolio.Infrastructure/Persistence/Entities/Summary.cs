namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Summary
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Content { get; set; } = null!;

    public int Position { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
