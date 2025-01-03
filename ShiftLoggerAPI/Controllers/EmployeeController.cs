using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository? _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Employee>))]
    public async Task<ActionResult<ICollection<Employee>>> GetEmployeesAsync()
    {
        var emps = await _employeeRepository.GetEmployeesAsync();

        if (emps == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(emps);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<Employee>> CreateEmployeeAsync(Employee employee)
    {
        return Ok(await _employeeRepository.CreateEmployeeAsync(employee)); 
    }
}