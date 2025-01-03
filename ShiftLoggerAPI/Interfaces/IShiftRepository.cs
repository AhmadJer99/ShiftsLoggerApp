using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Interfaces;

public interface IShiftRepository
{
    Task<ICollection<Shift>> GetShiftsAsync();
    Task<Shift> CreateShiftAsync(Shift shift);
}
