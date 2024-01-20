using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class UzytkownikService : IUzytkownikService
{
    private readonly PizzeriaDbContext _context;

    public UzytkownikService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<Uzytkownik?> GetUzytkownikAsync(string login, string haslo)
    {
        var getUzytkownik = await (from uzytkownik in _context.Uzytkowniks
            where uzytkownik.Login == login && uzytkownik.HasloHash == haslo
            select uzytkownik).FirstOrDefaultAsync();
        return getUzytkownik;
    }
}