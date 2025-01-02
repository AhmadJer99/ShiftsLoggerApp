using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Data;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Repository;

internal class ShiftRepository : IShiftRepository
{
    private readonly ShitftsLoggerDbContext _context;

    public ShiftRepository(ShitftsLoggerDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Shift>> GetShiftsAsync()
    {
        return await _context.Shifts.AsNoTracking().ToListAsync();
    }

    public async Task<Shift> CreateShiftAsync(Shift shift)
    {
        var createdShift = await _context.Shifts.AddAsync(shift);
        _context.SaveChanges();
        return createdShift.Entity;
    }
}
