using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class AdditionalTechnology
{
    public Guid Id { get; set; }

    public Guid AdditionalId { get; set; }

    public short SkillId { get; set; }

    public bool IsActive { get; set; }

    public virtual Additional Additional { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
