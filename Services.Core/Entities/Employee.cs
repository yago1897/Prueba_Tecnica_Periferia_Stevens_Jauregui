using Services.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }

        public int IdDepartament { get; set; }

        public virtual Department? IdDepartamentNavigation { get; set; } 
    }
}
