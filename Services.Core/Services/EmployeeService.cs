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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetEmployees(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task InsertEmployees(Employee entity)
        {
            await _employeeRepository.Add(entity);
        }

        public async Task ModificarEmployees(Employee entity)
        {
            await _employeeRepository.Update(entity);

        }

        public async Task<bool> EliminarEmployees(int id)
        {
            await _employeeRepository.Delete(id);
            return true;
        }

        public async Task<IEnumerable<string>> ConsultarPorNombre(string nombre)
        {
            return await _employeeRepository.GetByName(nombre);
        }

        // Consulta empleados por departamento
        public async Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId)
        {
            return await _employeeRepository.GetByDepartmentIdAsync(departmentId);
        }

        //Cálculo del salario total de un departamento
        public async Task<decimal> GetTotalSalaryByDepartmentAsync(int departmentId)
        {
            var employees = await _employeeRepository.GetByDepartmentIdAsync(departmentId);

            decimal total = 0;

            foreach (var emp in employees)
            {
                switch (emp.Position)
                {
                    case JobPosition.Developer:
                        total += emp.Salary * 1.10m;
                        break;
                    case JobPosition.Manager:
                        total += emp.Salary * 1.20m;
                        break;
                    case JobPosition.HR:
                    case JobPosition.Sales:
                        total += emp.Salary;
                        break;
                }
            }

            return total;
        }

    }
}
