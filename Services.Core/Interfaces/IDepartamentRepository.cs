using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IDepartamentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);

        Task Add(Department entity);

        Task Update(Department entity);
        Task Delete(int id);

        Task<IEnumerable<string>> GetByName(string nombre);
    }
}
