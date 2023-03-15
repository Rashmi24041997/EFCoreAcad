using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAcad.Models
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = default;

        public string LastName { get; set; } = default;

        public List<Student> Students { get; set; } = default;

        public Address Address { get; set; } = default;


    }
}
