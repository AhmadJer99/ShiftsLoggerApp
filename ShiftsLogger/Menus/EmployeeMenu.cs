﻿using Spectre.Console;

namespace ShiftsLoggerUI.Menus
{
    internal class EmployeeMenu : BaseMenu
    {
        private readonly List<string> _menuOptions =
            [
                "1.Search Employee",
                "2.New Employee",
                "3.All Employees",
                "4.Main Menu",
            ];

        public override async Task ShowMenuAsync()
        {
            while (true)
            {
                var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[teal]Users Menu[/]")
                    .AddChoices(_menuOptions));

                switch (selectedOption)
                {
                    case string selection when selection.Contains("1."):
                        // get a user name to search for it and display its stats , and add some options to edit values , or delete it.
                        break;
                    case string selection when selection.Contains("2."):
                        // Prompt the user to create a worker and prompt him with the appropriate Json values.
                        break;
                    case string selection when selection.Contains("3."):
                        // List all the workers for the users to see.
                        break;
                    case string selection when selection.Contains("4."):
                        return;

                }
            }
        }
    }
}
