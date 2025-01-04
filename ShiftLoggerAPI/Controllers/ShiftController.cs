using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;
using ShiftsLoggerAPI.Repository;

namespace ShiftsLoggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftController : ControllerBase
{
    private readonly IShiftRepository? _shiftRepository;

    public ShiftController(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Shift>))]
    public async Task<ActionResult<ICollection<Shift>>> GetShiftsAsync()
    {
        var shifts = await _shiftRepository.GetShiftsAsync();

        if (shifts == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(shifts);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Shift))]
    public async Task<ActionResult<Shift>> FindShiftAsync(int id)
    {
        var shift = await _shiftRepository.FindShiftAsync(id);

        if (shift == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(shift);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Shift))]
    public async Task<ActionResult<Shift>> CreateShiftAsync(Shift shift)
    {
        var newShift = await _shiftRepository.CreateShiftAsync(shift);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(newShift);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(string))]
    public async Task<ActionResult<string>> DeleteShiftAsync(int id)
    {
        var deleteResult = await _shiftRepository.DeleteShiftAsync(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (deleteResult == null)
            return NotFound();
        return Ok(deleteResult);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(Shift))]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Shift updatedShift)
    {
        var shift = await _shiftRepository.UpdateShiftAsync(id, updatedShift);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (shift == null)
            return NotFound();
        return Ok(shift);
    }
}