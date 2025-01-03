using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Data;
using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ShitftsLoggerDbContext _context;

    public EmployeeRepository(ShitftsLoggerDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        var newEmp = await _context.Employees.AddAsync(employee);
        _context.SaveChanges();
        return newEmp.Entity;
    }

    public async Task<ICollection<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.AsNoTracking().ToListAsync();
    }
}
