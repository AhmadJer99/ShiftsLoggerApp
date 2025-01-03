using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Interfaces;

public interface IEmployeeRepository
{
    Task<ICollection<Employee>> GetEmployeesAsync();
    Task<Employee> CreateEmployeeAsync(Employee employee);
}
