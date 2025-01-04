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

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<ICollection<Employee>>> FindEmployeeAsync(int id)
    {
        var emp = await _employeeRepository.FindEmployeeAsync(id);

        if (emp == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(emp);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<Employee>> CreateEmployeeAsync(Employee employee)
    {
        return Ok(await _employeeRepository.CreateEmployeeAsync(employee));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(string))]
    public async Task<ActionResult<string>> DeleteEmployeeAsync(int id)
    {
        return Ok(await _employeeRepository.DeleteEmployeeAsync(id));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee updatedEmployee)
    {
        return Ok(await _employeeRepository.UpdateEmployeeAsync(id, updatedEmployee));
    }
}