using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IOsobaService
{
    public Task<Osoba?> GetOsobaByIdAsync(int id);
    public Task<int> AddNewOsoba(OsobaDto osobaDto, int idAdres);
    public Task<int> AddNewOsobaUzytkownik(OsobaDto osobaDto, int idAdres, int idUzytkownik);
    public Task<int> UpdateOsobaToUzytkownik(int id);
}