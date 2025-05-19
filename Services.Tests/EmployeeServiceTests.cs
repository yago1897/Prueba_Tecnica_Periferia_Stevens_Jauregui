using Moq;
using Services.Core.Entities;
using Services.Core.Enums;
using Services.Core.Interfaces;
using Services.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepository;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            var employee = new Employee
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Salary = 5000,
                Position = JobPosition.Developer
            };

            _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync(employee);

            var result = await _employeeService.GetEmployees(1);

            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Name);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            _mockRepository.Setup(r => r.GetById(999)).ReturnsAsync((Employee)null);

            var result = await _employeeService.GetEmployees(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllEmployees_ShouldReturnListOfEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Email = "john@example.com", Salary = 5000, Position = JobPosition.Developer },
                new Employee { Id = 2, Name = "Jane", Email = "jane@example.com", Salary = 6000, Position = JobPosition.Manager }
            };

            _mockRepository.Setup(r => r.GetAll()).ReturnsAsync(employees);

            var result = await _employeeService.GetEmployees();

            Assert.NotNull(result);
            
        }

        [Fact]
        public async Task AddEmployee_ShouldCallAddMethodOfRepository()
        {
            var newEmployee = new Employee
            {
                Id = 3,
                Name = "New Employee",
                Email = "new@example.com",
                Salary = 4000,
                Position = JobPosition.Sales
            };

            await _employeeService.InsertEmployees(newEmployee);

            _mockRepository.Verify(r => r.Add(newEmployee), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployee_ShouldCallUpdateMethodOfRepository()
        {
            var existingEmployee = new Employee
            {
                Id = 1,
                Name = "Updated Employee",
                Email = "updated@example.com",
                Salary = 7500,
                Position = JobPosition.HR
            };

            await _employeeService.ModificarEmployees(existingEmployee);

            _mockRepository.Verify(r => r.Update(existingEmployee), Times.Once);
        }

        [Fact]
        public async Task DeleteEmployee_ShouldCallDeleteMethodOfRepository()
        {
            var employeeId = 1;

            await _employeeService.EliminarEmployees(employeeId);

            _mockRepository.Verify(r => r.Delete(employeeId), Times.Once);
        }
    }
}
