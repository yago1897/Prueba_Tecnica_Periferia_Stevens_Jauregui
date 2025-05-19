using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core.DTOs;
using Services.Core.Entities;
using Services.Core.Interfaces;
using Services.Infraestructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly PruebaTecnicaAportesEnLineaContext _context;
        private readonly IDepartamentService _departamentService;
        private readonly IMapper _mapper;


        public DepartamentController(IDepartamentService departamentService, IMapper mapper, PruebaTecnicaAportesEnLineaContext context)
        {
            _departamentService = departamentService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [Route("GetDepartament")]
        public async Task<IActionResult> GetDepartament()
        {
            var departament = await _departamentService.GetDepartaments();
            var departamenDTO = _mapper.Map<IEnumerable<DepartamentDTO>>(departament);
            return Ok(departamenDTO);

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetDepartament(int id)
        {
            var departament = await _departamentService.GetDepartaments(id);
            var departamenDTO = _mapper.Map<DepartamentDTO>(departament);
            return Ok(departamenDTO);
        }



        [HttpGet("[action]/{term}")]
        public async Task<IActionResult> ConsultarPorNombre(string term)
        {


            //List<string> usuario; Department usu = new Autore();
            //usuario = await _context.Department.Where(x => x.Name.StartsWith(term)).Select(e => e.Name).Distinct().ToListAsync();
            //return Ok(usuario);
            Department departament = new Department();
            List<string> usuario = new List<string>();
            usuario = (List<string>)await _departamentService.ConsultarPorNombre(term);
            //var autorDTO = _mapper.Map<DepartamentDTO>(term);
            return Ok(usuario);

        }


        [HttpPost]
        public async Task<IActionResult> InsertDepartaments(DepartamentDTO departamenDTO)
        {
            var departament = _mapper.Map<Department>(departamenDTO);
            await _departamentService.InsertDepartaments(departament);
            return Ok(departament);

        }


        [HttpPut]
        public async Task<IActionResult> ModificarDepartaments(int id, DepartamentDTO departamenDTO)
        {
            var departament = _mapper.Map<Department>(departamenDTO);
            departament.IdDepartament = id;
            await _departamentService.ModificarDepartaments(departament);
            return Ok(departament);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDepartaments(int id)
        {

            var result = await _departamentService.EliminarDepartaments(id);
            return Ok(result);

        }

    }


}
