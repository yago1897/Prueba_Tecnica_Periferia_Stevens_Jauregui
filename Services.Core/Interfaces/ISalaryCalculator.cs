using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface ISalaryCalculator
    {
        // Reglas de negocio para calcular el salario:Developers: salario base + 10% de bono. Managers: salario base + 20% de bono.HR y Sales: salario fijo.  
        decimal CalculateSalary(Employee employee);
    }
}
