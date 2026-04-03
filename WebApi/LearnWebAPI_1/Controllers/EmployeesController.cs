using LearnWebAPI_1.Data;
using LearnWebAPI_1.Models;
using LearnWebAPI_1.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnWebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var getAllEmployees = dbContext.Employees.ToList();

            return Ok(getAllEmployees);
        }

        [HttpGet]
        [Route ("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return StatusCode(404);
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmpDto addEmpDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmpDto.Name,
                Email = addEmpDto.Email,
                Phone = addEmpDto.Phone,
                Salary = addEmpDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(addEmpDto);

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, UpdateEmpDto updateEmpDto)
        {

            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return StatusCode(404);
            }

            employee.Name = updateEmpDto.Name;
            employee.Email = updateEmpDto.Email;
            employee.Phone = updateEmpDto.Phone;
            employee.Salary = updateEmpDto.Salary;
            
            dbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
