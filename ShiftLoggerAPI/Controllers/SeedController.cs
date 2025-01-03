﻿using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Interfaces;

namespace ShiftsLoggerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly ISeedRepository _seedRepository;

    public SeedController(ISeedRepository seedRepository)
    {
        _seedRepository = seedRepository;
    }

    [HttpPut]
    [ProducesResponseType(200, Type = typeof(string))]
    public async Task<ActionResult> SeedEmployeesAsync()
    {
        await _seedRepository.SeedEmployeesAsync();

        return Ok("Seeded Successfully!");
    }

    [HttpPut("{randRowNumber:int}")]
    [ProducesResponseType(200, Type = typeof(string))]
    public async Task<ActionResult> SeedShiftsAsync(int randRowNumber)
    {
        await _seedRepository.SeedShiftsAsync(randRowNumber);

        return Ok("Seeded Successfully!");
    }
}
