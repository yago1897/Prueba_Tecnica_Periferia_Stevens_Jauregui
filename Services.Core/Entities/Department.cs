using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Entities
{
    public partial class Department
    {

        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public int IdDepartament { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
