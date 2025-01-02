using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Data;

public class ShitftsLoggerDbContext : DbContext
{
    public ShitftsLoggerDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Shift>? Shifts { get; set; }
    //public DbSet<Employee>? Employees { get; set; }
}
