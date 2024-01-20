namespace TIN_WebAPI_s24690.Services;

public interface IRolaService
{
    public Task<string?> GetRolaByIdAsync(int id);
}