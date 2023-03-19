using System;
using System.Collections.Generic;

namespace EFCoreAcad;

public partial class Addrese
{
    public long Id { get; set; }

    public string City { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Street { get; set; } = null!;

    public long HouseNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; } = new List<Class>();

    public virtual ICollection<Professor> Professors { get; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
