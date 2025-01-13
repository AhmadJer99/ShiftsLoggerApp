namespace ShiftsLoggerUI.Services;

public interface IService
{
    public Task GetAll();
    public Task Find(int id);
    public Task Create(object newObject);
    public Task Update(int id, object updatedObject);
    public Task Delete(int id);

}
