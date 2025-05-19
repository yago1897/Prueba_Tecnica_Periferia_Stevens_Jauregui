using Microsoft.EntityFrameworkCore;
using Services.Core.Entities;
using Services.Core.Interfaces;
using Services.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PruebaTecnicaAportesEnLineaContext _context;
        protected readonly DbSet<Employee> _entities;

        public EmployeeRepository(PruebaTecnicaAportesEnLineaContext context)
        {
            _context = context;
            _entities = context.Employees;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            Employee employee = new Employee();
            employee = await GetById(id);
            _entities.Remove(employee);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<string>> GetByName(string nombre)
        {
            List<string> usuario;
            usuario = await _context.Employees.Where(x => x.Name.StartsWith(nombre)).Select(e => e.Name).Distinct().ToListAsync();
            return usuario;
        }

        // Consulta empleados por departamento
        public async Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.IdDepartament == departmentId)
                .ToListAsync();
        }
    }
}
