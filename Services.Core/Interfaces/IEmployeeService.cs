using Services.Core.DTOs;
using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployees(int id);

        Task InsertEmployees(Employee entity);

        Task ModificarEmployees(Employee entity);

        Task<bool> EliminarEmployees(int id);

        Task<IEnumerable<string>> ConsultarPorNombre(string nombre);
        // Consulta empleados por departamento
        Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId);

        //Cálculo del salario total de un departamento
        Task<decimal> GetTotalSalaryByDepartmentAsync(int departmentId);

    }
}
