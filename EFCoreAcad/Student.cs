using System;
using System.Collections.Generic;

namespace EFCoreAcad;

public partial class Student
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long AddressId { get; set; }

    public long? StudentId { get; set; }

    public virtual Addrese Address { get; set; } = null!;

    public virtual ICollection<Student> InverseStudentNavigation { get; } = new List<Student>();

    public virtual Student? StudentNavigation { get; set; }

    public virtual ICollection<Class> Classes { get; } = new List<Class>();
}
