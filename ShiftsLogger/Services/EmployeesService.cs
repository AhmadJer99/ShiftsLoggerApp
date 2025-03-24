using Microsoft.Extensions.Configuration;
using ShiftsLoggerUI.Models;
using Spectre.Console;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace ShiftsLoggerUI.Services;

public class EmployeesService : BaseService, IService<Employee>
{

    public EmployeesService(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Employee> Create(Employee newEmployee)
    {
        var createdEmployee = new Employee();
        try
        {
            using var response = await _client.PostAsJsonAsync("api/Employee", newEmployee);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(content);
                using var jsonReader = new JsonTextReader(streamReader);

                var serializer = new JsonSerializer();
                createdEmployee = serializer.Deserialize<Employee>(jsonReader);
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]{response.StatusCode}[/]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error: " + ex.Message);
        }
        return createdEmployee;
    }

    public Task<Employee> Delete(int id)
    {
        throw new NotImplementedException();
    }


    public async Task<Employee> Find(int id)
    {
        var employee = new Employee();
        try
        {
            using var response = await _client.GetAsync($"api/Employee/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(content);
                using var jsonReader = new JsonTextReader(streamReader);

                var serializer = new JsonSerializer();
                employee = serializer.Deserialize<Employee>(jsonReader);
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]{response.StatusCode}[/]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error: " + ex.Message);
        }

        return employee;
    }


    public async Task<List<Employee>> GetAll()
    {
        var employees = new List<Employee>();
        try
        {
            using var response = await _client.GetAsync("api/Employee");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(content);
                using var jsonReader = new JsonTextReader(streamReader);

                var serializer = new JsonSerializer();
                employees = serializer.Deserialize<List<Employee>>(jsonReader);

            }
            else
            {
                AnsiConsole.MarkupLine($"[red]{response.StatusCode}[/]");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error: " + ex.Message);
        }

        return employees;
    }

    public Task<Employee> Update(int id, object updatedObject)
    {
        throw new NotImplementedException();
    }
}
