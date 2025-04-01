using ShiftsLoggerUI.Models;
using ShiftsLoggerUI.Dto;
using Spectre.Console;
using ShiftsLoggerUI.Services;
using Newtonsoft.Json;

namespace ShiftsLoggerUI.Menus;

internal class ShiftsMenu : BaseMenu
{
    private readonly ShiftsService _shiftsService;

    public ShiftsMenu(ShiftsService shiftsService)
    {
        _shiftsService = shiftsService;
    }

    private List<string> _menuOptions =
        [
            "1.Add A Shift",
            "2.View All Shifts",
            "3.Delete A Shift",
            "4.Update A Shift",
            "5.Main Menu",
        ];
    public override async Task ShowMenuAsync()
    {
        while (true)
        {
            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[teal]Shifts Menu[/]")
                .AddChoices(_menuOptions));

            switch (selectedOption)
            {
                case string selection when selection.Contains("1."):
                    await AddShift();
                    break;
                case string selection when selection.Contains("2."):
                    break;
                case string selection when selection.Contains("3."):
                    break;
                case string selection when selection.Contains("4."):
                    break;
                case string selection when selection.Contains("5."):
                    return;
            }
        }
    }

    private async Task AddShift()
    {
        var newShift = new Shift()
        {
            EmpId = AnsiConsole.Ask<int>("Enter Employee Id: "),
            ShiftStartTime = AnsiConsole.Ask<DateTime>("Enter Shift Start Time: "),
            ShiftEndTime = AnsiConsole.Ask<DateTime>("Enter Shift End Time: ")
        };
        var createdShift = await _shiftsService.Create(newShift);
        Console.WriteLine(JsonConvert.SerializeObject(createdShift));
        PressAnyKeyToContinue();
    }

}