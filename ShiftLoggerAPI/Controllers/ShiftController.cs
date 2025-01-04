using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;

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
}
