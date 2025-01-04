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
    public async Task<Shift> CreateShiftAsync(Shift shift)
    {
        var newShift = await _context.Shifts.AddAsync(shift);
        _context.SaveChanges();
        return newShift.Entity;
    }

    public async Task<string> DeleteShiftAsync(int id)
    {
        var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.ShiftId == id);

        if (shift == null)
            return null;

        _context.Remove(shift);
        await _context.SaveChangesAsync();
        return $"Successfully deleted shift with id: {id}";
    }

    public async Task<Shift> FindShiftAsync(int id)
    {
        var shift = await _context.Shifts.AsNoTracking().FirstOrDefaultAsync(s => s.ShiftId == id);

        if (shift == null)
            return null;

        return shift;
    }

    public async Task<ICollection<Shift>> GetShiftsAsync()
    {
        return await _context.Shifts.AsNoTracking().ToListAsync();
    }

    public async Task<Shift> UpdateShiftAsync(int id, Shift updatedShift)
    {
        var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.ShiftId == id);

        if (shift == null)
            return null;

        _context.Entry(shift).CurrentValues.SetValues(updatedShift);
        _context.SaveChanges();

        return shift;
    }
}
