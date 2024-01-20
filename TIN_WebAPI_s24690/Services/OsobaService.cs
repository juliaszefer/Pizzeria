using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class OsobaService : IOsobaService
{
    private readonly PizzeriaDbContext _context;

    public OsobaService(PizzeriaDbContext context)
    {
        _context = context;
    }
    
    public async Task<Osoba?> GetOsobaByIdAsync(int id)
    {
        var getOsoba = await (from osoba in _context.Osobas 
            where osoba.IdUzytkownik == id select osoba).FirstOrDefaultAsync();
        return getOsoba;
    }
}