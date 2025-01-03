using ShiftsLoggerAPI.Interfaces;
using ShiftsLoggerAPI.Models;
using ShiftsLoggerAPI.Repository;

namespace ShiftsLoggerAPI.Data;

public class DbInitialiser
{
    private readonly ShitftsLoggerDbContext _context;
    private readonly Random _random = new();
    private const int DateRangeStart = -30;
    private const int DateRangeEnd = 1;
    public DbInitialiser(ShitftsLoggerDbContext context)
    {
        _context = context;
    }

    public async Task RunAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();

        //await SeedDbAsync();
    }

    private async Task SeedDbAsync(int randomShifts = 100)
    {
        IShiftRepository shiftsLoggerRepoistory = new ShiftRepository(_context);

        var empNames = new List<string> { "Ahmad", "Basil", "Chris", "Osama", "Hera" };
        for (int i = 0; i < randomShifts; i++)
        {
            var randIndex = _random.Next(0, empNames.Count); // gives index of the random name generated.
            var randShiftDate = RandomDate();
            var randStartTime = RandomTime(randShiftDate);
            var randEndTime = RandomTime(randShiftDate);
            while (randEndTime < randStartTime | randEndTime.Subtract(randStartTime).Hours == 0 | randEndTime.Subtract(randStartTime).Hours > 12)
            {
                randStartTime = RandomTime(randShiftDate);
                randEndTime = RandomTime(randShiftDate);
            }

            var randShift = new Shift
            {
                //EmployeeName = empNames[randIndex],
                StartDateTime = randStartTime,
                EndDateTime = randEndTime
            };

            await shiftsLoggerRepoistory.CreateShiftAsync(randShift);
        }
    }

    private DateTime RandomTime(DateTime shiftDate)
    {
        TimeSpan start = TimeSpan.FromHours(6);
        TimeSpan end = TimeSpan.FromHours(30);

        int maxMinutes = (int)((end - start).TotalMinutes);
        int minutes = _random.Next(maxMinutes);

        TimeSpan time = start.Add(TimeSpan.FromMinutes(minutes)); // 24 hr format
        DateTime timeOfDay = shiftDate.Add(time); // converts to 12hr AM/PM format due to database specifications

        return timeOfDay;
    }

    private DateTime RandomDate()
    {
        var randOffset = _random.Next(DateRangeStart, DateRangeEnd);
        return DateTime.Today.AddDays(randOffset); // random dates within the last month.
    }
}