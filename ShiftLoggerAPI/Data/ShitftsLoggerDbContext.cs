using Microsoft.EntityFrameworkCore;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Data;

public class ShitftsLoggerDbContext : DbContext
{
    public ShitftsLoggerDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Shift>? Shifts { get; set; }
    public DbSet<Employee>? Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(pc => pc.EmpId);

        modelBuilder.Entity<Employee>()
            .HasIndex(pc => pc.EmpName)
            .IsUnique();

        //modelBuilder.Entity<Employee>()
        //    .HasMany(pc => pc.EmpShifts);

        //modelBuilder.Entity<Shift>()
        //    .HasOne(pc => pc.Employee);

        
    }
}
