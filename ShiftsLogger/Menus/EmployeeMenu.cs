using ShiftsLoggerUI.Services;
using ShiftsLoggerUI.Models;
using Spectre.Console;
using Newtonsoft.Json;

namespace ShiftsLoggerUI.Menus
{
    internal class EmployeeMenu : BaseMenu
    {
        private readonly EmployeesService _employeesService;

        public EmployeeMenu(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        private readonly List<string> _menuOptions =
            [
                "1.Search Employee",
                "2.New Employee",
                "3.All Employees",
                "4.Main Menu",
            ];

        private readonly List<string> _employeeOptions =
            [

                "1.Edit",
                "2.Delete",
                "3.Shifts",
                "4.Back"
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
                        await SearchEmployee();
                        break;
                    case string selection when selection.Contains("2."):
                        await AddNewEmployee();
                        break;
                    case string selection when selection.Contains("3."):
                        await GetAllEmployees();
                        break;
                    case string selection when selection.Contains("4."):
                        return;

                }
            }
        }

        private async Task GetAllEmployees()
        {
            var emps = await _employeesService.GetAll();
            if (emps.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No Employees Found![/]");
                PressAnyKeyToContinue();
                return;
            }
            var selectedEmployee = AnsiConsole.Prompt(
                    new SelectionPrompt<Employee>()
                    .Title("[teal]Select an employee to further operate on:[/]")
                    .UseConverter(b => $"{b.EmployeeName}")
                    .AddChoices(emps));

            await OperateOnEmployee(selectedEmployee);
            PressAnyKeyToContinue();
        }

        private async Task SearchEmployee()
        {
            Console.Clear();
            var employeeName = AnsiConsole.Ask<string>("Employee's Name: ");
            var employee = await _employeesService.Find(employeeName);
            if (employee.EmployeeId == 0)
            {
                AnsiConsole.MarkupLine("[red]Employee not found![/]");
                PressAnyKeyToContinue();
                return;
            }
            await OperateOnEmployee(employee);
            PressAnyKeyToContinue();
        }

        private async Task AddNewEmployee()
        {
            Console.Clear();

            var newEmployee = new Employee
            {
                EmployeeName = AnsiConsole.Ask<string>("Employee's Name: "),
                EmployeePhone = AnsiConsole.Ask<string>("\nEmployee's Phone Number: ")
            };
            Console.WriteLine(JsonConvert.SerializeObject(newEmployee));
            var createdEmployee = await _employeesService.Create(newEmployee);
            Console.WriteLine(createdEmployee);
            PressAnyKeyToContinue();
        }

        private async Task OperateOnEmployee(Employee employee)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[bold]Selected Employee:[/] ID({employee.EmployeeId})-{employee.EmployeeName}\t[bold]Phone Number:[/] {employee.EmployeePhone}");
            var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[teal]Employee Operations[/]")
                    .AddChoices(_employeeOptions));

            switch (selectedOption)
            {
                case string selection when selection.Contains("1."):
                    var updatedEmployee = new Employee
                    {
                        EmployeeName = AnsiConsole.Ask<string>("Employee's Name: "),
                        EmployeePhone = AnsiConsole.Ask<string>("\nEmployee's Phone Number: ")
                    };
                    await _employeesService.Update(employee.EmployeeId, updatedEmployee);
                    break;
                case string selection when selection.Contains("2."):
                    AnsiConsole.MarkupLine($"[red]{await _employeesService.Delete(employee.EmployeeId)}[/]");
                    break;
                case string selection when selection.Contains("3."):
                    // Show all the shifts affiliated with the selected employee
                    break;
                case string selection when selection.Contains("4."):
                    // return;
                    break;
            }
        }
    }
}