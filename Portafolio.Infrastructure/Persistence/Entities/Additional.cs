using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class Additional
{
    public Guid Id { get; set; }

    public Guid ProfileId { get; set; }

    public string Code { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AdditionalTechnology> AdditionalTechnologies { get; set; } = new List<AdditionalTechnology>();

    public virtual Profile Profile { get; set; } = null!;
}
