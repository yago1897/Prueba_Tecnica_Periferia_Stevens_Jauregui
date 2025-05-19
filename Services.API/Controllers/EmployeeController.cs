using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Core.DTOs;
using Services.Core.Entities;
using Services.Core.Interfaces;
using Services.Core.Services;
using Services.Infraestructure.Data;

namespace Services.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly PruebaTecnicaAportesEnLineaContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly ISalaryCalculator _salaryCalculator;
        private readonly IMapper _mapper;


        public EmployeeController(IEmployeeService employeeService, ISalaryCalculator salaryCalculator, IMapper mapper, PruebaTecnicaAportesEnLineaContext context)
        {
            _employeeService = employeeService;
            _salaryCalculator = salaryCalculator;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var employee = await _employeeService.GetEmployees();
            var employeeDTO = _mapper.Map<IEnumerable<EmployeeDTOs>>(employee);
            return Ok(employeeDTO);

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployees(id);
            var employeeDTO = _mapper.Map<EmployeeDTOs>(employee);
            return Ok(employeeDTO);
        }



        [HttpGet("[action]/{term}")]
        public async Task<IActionResult> ConsultarPorNombre(string term)
        {


            //List<string> employee; Employee usu = new Employee();
            //usuario = await _context.Employee.Where(x => x.Name.StartsWith(term)).Select(e => e.Name).Distinct().ToListAsync();
            //return Ok(usuario);
            Employee usu = new Employee();
            List<string> usuario = new List<string>();
            usuario = (List<string>)await _employeeService.ConsultarPorNombre(term);
            //var autorDTO = _mapper.Map<DepartamentDTO>(term);
            return Ok(usuario);

        }


        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDTOs employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await _employeeService.InsertEmployees(employee);
            return Ok(employee);

        }


        [HttpPut]
        public async Task<IActionResult> ModificarEmployee(int id, EmployeeDTOs employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.Id = id;
            await _employeeService.ModificarEmployees(employee);
            return Ok(employee);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEmployee(int id)
        {

            var result = await _employeeService.EliminarEmployees(id);
            return Ok(result);

        }

        // Reglas de negocio para calcular el salario:Developers: salario base + 10% de bono. Managers: salario base + 20% de bono.HR y Sales: salario fijo.  
        [HttpGet("{id}/calculated-salary")]
        public async Task<IActionResult> GetCalculatedSalary(int id)
        {
            var employee = await _employeeService.GetEmployees(id);
            if (employee == null)
                return NotFound();

            var finalSalary = _salaryCalculator.CalculateSalary(employee);
            return Ok(new
            {
                employee.Id,
                employee.Name,
                Position = employee.Position.ToString(),
                BaseSalary = employee.Salary,
                FinalSalary = finalSalary
            });
        }

        // Consulta empleados por departamento
        [HttpGet("departments/{id}/employees")]
        public async Task<IActionResult> GetEmployeesByDepartment(int id)
        {
            var employees = await _employeeService.GetByDepartmentIdAsync(id);
            return Ok(employees);
        }

        //Cálculo del salario total de un departamento
        [HttpGet("departments/{id}/totalsalary")]
        public async Task<IActionResult> GetTotalSalary(int id)
        {
            var total = await _employeeService.GetTotalSalaryByDepartmentAsync(id);
            return Ok(new { DepartmentId = id, TotalSalary = total });
        }

    }
}
