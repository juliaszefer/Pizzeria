using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IOsobaService
{
    public Task<Osoba?> GetOsobaByIdAsync(int id);
    public Task<Osoba?> GetOsobaByEmailAsync(string email);
    public Task<int> AddNewOsoba(OsobaDto osobaDto);
    public Task<int> AddNewOsobaUzytkownik(OsobaDto osobaDto);
    public Task<int> UpdateOsobaToUzytkownik(int idOsoba, int idUzytkownik);
}