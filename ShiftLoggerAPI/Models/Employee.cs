namespace ShiftsLoggerAPI.Models;

public class Employee
{
    public int EmpId { get; set; }
    public string? EmpName { get; set; }
    public string? EmpPhone { get; set; }
    public ICollection<Shift>? EmpShifts { get; set; }
}
