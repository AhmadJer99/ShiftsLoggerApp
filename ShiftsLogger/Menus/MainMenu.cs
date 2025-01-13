using ShiftsLoggerUI.Services;
using Spectre.Console;

namespace ShiftsLoggerUI.Menus;

internal class MainMenu : BaseMenu
{
    private readonly SeedingService _seedingService;

    public MainMenu(SeedingService seedingService)
    {
        _seedingService = seedingService;
    }

    private enum MenuOptions
    {
        Employees,
        Shifts,
        Seed,
        Exit
    }

    public override async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            var selectedOption = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("[teal]Main Menu[/]")
            .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (selectedOption)
            {
                case MenuOptions.Employees:
                    EmployeeMenu usersMenu = new();
                    await usersMenu.ShowMenuAsync();
                    break;
                case MenuOptions.Shifts:
                    ShiftsMenu shiftsMenu = new();
                    await shiftsMenu.ShowMenuAsync();
                    // Redirect to shifts menu
                    break;
                case MenuOptions.Seed:
                    var rows = AnsiConsole.Ask<int>("How many rows would you like to seed?");
                    await _seedingService.SeedDbAsync(rows);
                    break;
                case MenuOptions.Exit:
                    AnsiConsole.MarkupLine("[Green]Cya![/]");
                    return;
            }
        }
    }
}