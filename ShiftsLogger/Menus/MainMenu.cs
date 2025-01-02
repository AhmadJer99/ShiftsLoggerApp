using Spectre.Console;

namespace ShiftsLoggerUI.Menus;

internal class MainMenu : BaseMenu
{
    private enum MenuOptions
    {
        Users,
        Shifts,
        Seed,
        Exit
    }

    public override async Task ShowMenuAsync()
    {
        while (true)
        {
            var selectedOption = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("[teal]Main Menu[/]")
            .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (selectedOption)
            {
                case MenuOptions.Users:
                    UsersMenu usersMenu = new();
                    await usersMenu.ShowMenuAsync();
                    break;
                case MenuOptions.Shifts:
                    ShiftsMenu shiftsMenu = new();
                    await shiftsMenu.ShowMenuAsync();
                    // Redirect to shifts menu
                    break;
                case MenuOptions.Seed:
                    // Seed the database with N rows of random data
                    break;
                case MenuOptions.Exit:
                    AnsiConsole.MarkupLine("[Green]Cya![/]");
                    return;
            }
        }
    }
}