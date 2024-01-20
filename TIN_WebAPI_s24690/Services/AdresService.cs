using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

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

    public async Task<int> AddNewAdressAsync(AdresDto adresDto)
    {
        int id = await _context.Adres.MaxAsync(e => e.IdAdres) + 1;

        Adres adres = new Adres
        {
            IdAdres = id,
            Kraj = adresDto.Kraj,
            Miasto = adresDto.Miasto,
            NrMieszkania = adresDto.NrMieszkania,
            NrUlicy = adresDto.NrUlicy,
            Ulica = adresDto.Ulica
        };
        
        await _context.Adres.AddAsync(adres);
        await _context.SaveChangesAsync();

        return id;
    }
}