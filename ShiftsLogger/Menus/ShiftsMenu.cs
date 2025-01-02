using Spectre.Console;

namespace ShiftsLoggerUI.Menus;

internal class ShiftsMenu : BaseMenu
{
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
}