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

    public async Task<string> DeleteEmployeeAsync(int id)
    {
        var emp = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmpId == id);

        if (emp == null)
            return null;

        _context.Employees.Remove(emp);
        await _context.SaveChangesAsync();

        return $"Employee With id={emp.EmpId} deleted successfully!";
    }

    public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(e => e.EmpId == id);

        if (emp == null)
            return null;

        _context.Entry(emp).CurrentValues.SetValues(updatedEmployee);
        _context.SaveChanges();

        return emp;
    }

    public async Task<Employee> FindEmployeeAsync(int id)
    {
        var emp = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmpId == id);

        if (emp == null)
            return null;

        return emp;
    }
}