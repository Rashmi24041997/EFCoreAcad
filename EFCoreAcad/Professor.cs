using System;
using System.Collections.Generic;

namespace EFCoreAcad;

public partial class Professor
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long AddressId { get; set; }

    public virtual Addrese Address { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; } = new List<Class>();
}
