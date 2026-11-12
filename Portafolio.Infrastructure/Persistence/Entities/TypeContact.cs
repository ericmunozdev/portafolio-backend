using System;
using System.Collections.Generic;

namespace Portafolio.Infrastructure.Persistence.Entities;

public partial class TypeContact
{
    public Guid Id { get; set; }

    public string? Icon { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
