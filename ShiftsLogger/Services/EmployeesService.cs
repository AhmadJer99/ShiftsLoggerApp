using Microsoft.Extensions.Configuration;
using ShiftsLoggerUI.Models;

namespace ShiftsLoggerUI.Services;

public class EmployeesService : BaseService, IService
{

    public EmployeesService(IConfiguration configuration) : base(configuration)
    {
    }

    public Task Create(object newObject)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Find(int id)
    {
        throw new NotImplementedException();
    }

    public async Task GetAll()
    {
        //return await _client.GetAsync("api/Employee");
    }

    public Task Update(int id, object updatedObject)
    {
        throw new NotImplementedException();
    }
}
