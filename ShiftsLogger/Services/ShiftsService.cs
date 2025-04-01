using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShiftsLoggerUI.Models;
using Spectre.Console;
using System.Text;

namespace ShiftsLoggerUI.Services;

internal class ShiftsService : BaseService, IService<Shift>
{
    public ShiftsService(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Shift> Create(Shift newShift)
    {
        var createdShift = new Shift();
        try
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/Shift")
            {
                Content = new StringContent(JsonConvert.SerializeObject(newShift), Encoding.UTF8, "application/json")
            };
            using var response = await _client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(content);
                using var jsonReader = new JsonTextReader(streamReader);

                var serializer = new JsonSerializer();
                createdShift = serializer.Deserialize<Shift>(jsonReader);
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
        return createdShift;
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Shift> Find(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Shift>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Shift> Update(int id, Shift updatedObject)
    {
        throw new NotImplementedException();
    }
}
