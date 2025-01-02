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
}
