using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAcad.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } = default;

        public string FirstName { get; set; } = default;

        public List<Class> Classes { get; set; } = default;

        public string LastName { get; set; } = default;


    }
}
