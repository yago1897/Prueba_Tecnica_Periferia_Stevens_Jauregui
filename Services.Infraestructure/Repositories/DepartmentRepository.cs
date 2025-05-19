using Microsoft.EntityFrameworkCore;
using Services.Core;
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
    public class DepartmentRepository : IDepartamentRepository
    {
        private readonly PruebaTecnicaAportesEnLineaContext _context;
        protected readonly DbSet<Department> _entities;

        public DepartmentRepository(PruebaTecnicaAportesEnLineaContext context)
        {
            _context = context;
            _entities = context.Departments;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }
        public async Task Add(Department entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Department entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            Department departamen = new Department();
            departamen = await GetById(id);
            _entities.Remove(departamen);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<string>> GetByName(string nombre)
        {
            List<string> usuario;
            usuario = await _context.Departments.Where(x => x.Name.StartsWith(nombre)).Select(e => e.Name).Distinct().ToListAsync();
            return usuario;
        }
    }
}
