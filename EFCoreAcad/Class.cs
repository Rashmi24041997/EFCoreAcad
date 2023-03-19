using System;
using System.Collections.Generic;

namespace EFCoreAcad;

public partial class Class
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long ProfessorId { get; set; }

    public long? AddressId { get; set; }

    public long? ClassId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual Addrese? Address { get; set; }

    public virtual Class? ClassNavigation { get; set; }

    public virtual ICollection<Class> InverseClassNavigation { get; } = new List<Class>();

    public virtual Professor Professor { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
