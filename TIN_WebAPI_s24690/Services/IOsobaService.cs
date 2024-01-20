using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public interface IOsobaService
{
    public Task<Osoba?> GetOsobaByIdAsync(int id);
}