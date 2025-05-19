using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);

        Task Add(Employee entity);

        Task Update(Employee entity);
        Task Delete(int id);
        Task<IEnumerable<string>> GetByName(string nombre);

        // Consulta empleados por departamento
        Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId);
    }
}
