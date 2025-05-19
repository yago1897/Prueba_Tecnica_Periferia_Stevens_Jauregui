using Services.Core.Entities;
using Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _departamentRepository;

        public DepartamentService(IDepartamentRepository departamentRepository)
        {
            _departamentRepository = departamentRepository;

        }

        public async Task<IEnumerable<Department>> GetDepartaments()
        {
            return await _departamentRepository.GetAll();
        }

        public async Task<Department> GetDepartaments(int id)
        {
            return await _departamentRepository.GetById(id);
        }

        public async Task InsertDepartaments(Department entity)
        {
            await _departamentRepository.Add(entity);
        }

        public async Task ModificarDepartaments(Department entity)
        {
            await _departamentRepository.Update(entity);

        }

        public async Task<bool> EliminarDepartaments(int id)
        {
            await _departamentRepository.Delete(id);
            return true;
        }

        public async Task<IEnumerable<string>> ConsultarPorNombre(string nombre)
        {
            return await _departamentRepository.GetByName(nombre);
        }
    }
}
