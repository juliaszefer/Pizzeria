using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class AdresService : IAdresService
{
    private readonly PizzeriaDbContext _context;

    public AdresService(PizzeriaDbContext context)
    {
        _context = context;
    }
    
    public async Task<Adres?> GetAdresByIdAsync(int id)
    {
        var getAdres = await (from adres in _context.Adres 
            where adres.IdAdres == id select adres).FirstOrDefaultAsync();
        return getAdres;
    }
}