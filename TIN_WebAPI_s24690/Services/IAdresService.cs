using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public interface IAdresService
{
    public Task<Adres?> GetAdresByIdAsync(int id);
}