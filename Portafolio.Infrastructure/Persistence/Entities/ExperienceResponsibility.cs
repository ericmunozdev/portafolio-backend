using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class ExperienceResponsibility
{
    public Guid Id { get; set; }

    public Guid ExperienceId { get; set; }

    public string Content { get; set; } = null!;

    public int Position { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Experience Experience { get; set; } = null!;
}
