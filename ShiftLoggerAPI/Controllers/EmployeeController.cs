using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;
using AutoMapper;
using ShiftsLoggerAPI.Dto;

namespace ShiftsLoggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository? _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Employee>))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<ICollection<Employee>>> GetEmployeesAsync()
    {
        var emps = _mapper.Map<List<EmployeeDto>>(await _employeeRepository.GetEmployeesAsync());

        if (emps == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(emps);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Employee))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<ICollection<Employee>>> FindEmployeeAsync(int id)
    {
        var emp = _mapper.Map<EmployeeDto>(await _employeeRepository.FindEmployeeAsync(id));

        if (emp == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(emp);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<Employee>> CreateEmployeeAsync([FromBody] Employee employee)
    {
        return Ok(_mapper.Map<EmployeeDto>(await _employeeRepository.CreateEmployeeAsync(employee)));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(string))]
    public async Task<ActionResult<string>> DeleteEmployeeAsync(int id)
    {
        return Ok(_mapper.Map<EmployeeDto>(await _employeeRepository.DeleteEmployeeAsync(id)));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Employee))]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, [FromBody] Employee updatedEmployee)
    {
        return Ok(_mapper.Map<EmployeeDto>(await _employeeRepository.UpdateEmployeeAsync(id, updatedEmployee)));
    }
}