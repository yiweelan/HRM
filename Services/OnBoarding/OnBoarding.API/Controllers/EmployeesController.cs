using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emps = await _employeeService.GetAllEmployees();

            if (!emps.Any())
            {
                // no employees exists, then 404
                return NotFound(new { error = "No open Employees found, please try later" });
            }
            return Ok(emps);
        }

        [Route("{id:int}", Name = "GetEmployeeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var emp = await _employeeService.GetEmployeeById(id);

            if (emp == null)
            {
                return NotFound(new { errorMessage = "No Employee found for this id" });
            }

            return Ok(emp);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }
            var emp = await _employeeService.AddEmployee(model);
            return CreatedAtAction("GetEmployeeDetails", new { controller = "Employees", id = emp }, "Employee Created");
        }

        [Route("")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId = await _employeeService.DeleteEmployee(id);
            return Ok(deletedId);
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if(id != employee.Id)
            {
                return BadRequest(new { errorMessage = "Mismatch id" });
            }

            var updated = await _employeeService.UpdateEmployee(employee);
            return Ok(updated);
        }
    }
}
