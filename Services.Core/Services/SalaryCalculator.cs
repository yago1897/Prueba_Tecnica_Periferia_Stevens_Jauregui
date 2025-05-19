using Services.Core.Entities;
using Services.Core.Enums;
using Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Services
{
    public class SalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateSalary(Employee employee)
        {
            return employee.Position switch
            {
                JobPosition.Developer => employee.Salary * 1.10m,
                JobPosition.Manager => employee.Salary * 1.20m,
                JobPosition.HR => employee.Salary,
                JobPosition.Sales => employee.Salary,
                _ => throw new ArgumentOutOfRangeException("Unknown job position")
            };
        }

    }
}
