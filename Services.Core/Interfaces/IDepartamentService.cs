using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IDepartamentService
    {
        Task<IEnumerable<Department>> GetDepartaments();
        Task<Department> GetDepartaments(int id);

        Task InsertDepartaments(Department entity);

        Task ModificarDepartaments(Department entity);

        Task<bool> EliminarDepartaments(int id);

        Task<IEnumerable<string>> ConsultarPorNombre(string nombre);
    }
}
