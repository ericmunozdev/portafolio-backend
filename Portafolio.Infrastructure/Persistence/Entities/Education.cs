using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Education
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Title { get; set; } = null!;

    public string Institution { get; set; } = null!;

    public short? GraduationYear { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
