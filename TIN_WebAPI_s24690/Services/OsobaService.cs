using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

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

    public async Task<Osoba?> GetOsobaByEmailAsync(string email)
    {
        var getOsoba = await (from osoba in _context.Osobas 
            where osoba.Email == email select osoba).FirstOrDefaultAsync();
        return getOsoba;
    }

    public async Task<int> AddNewOsoba(OsobaDto osobaDto)
    {
        int id = await _context.Osobas.MaxAsync(e => e.IdOsoba) + 1;

        if (DoesEmailExist(osobaDto.Email))
        {
            return -1;
        }

        Osoba osoba = new Osoba
        {
            IdOsoba = id,
            Imie = osobaDto.Imie,
            Nazwisko = osobaDto.Nazwisko,
            NrTelefonu = osobaDto.NrTelefonu,
            Email = osobaDto.Email,
            IdAdres = osobaDto.IdAdres,
            IdRola = 3,
            IdUzytkownik = null
        };

        await _context.Osobas.AddAsync(osoba);
        await _context.SaveChangesAsync();

        return id;

    }

    public async Task<int> AddNewOsobaUzytkownik(OsobaDto osobaDto)
    {
        int id = await _context.Osobas.MaxAsync(e => e.IdOsoba) + 1;

        if (DoesEmailExist(osobaDto.Email))
        {
            return -1;
        }

        Osoba osoba = new Osoba
        {
            IdOsoba = id,
            Imie = osobaDto.Imie,
            Nazwisko = osobaDto.Nazwisko,
            NrTelefonu = osobaDto.NrTelefonu,
            Email = osobaDto.Email,
            IdAdres = osobaDto.IdAdres,
            IdRola = 2,
            IdUzytkownik = null
        };

        await _context.Osobas.AddAsync(osoba);
        await _context.SaveChangesAsync();

        return id;
    }

    public async Task<int> UpdateOsobaToUzytkownik(int id)
    {
        var osoba = await _context.Osobas.FindAsync(id);

        if (osoba == null)
        {
            return -1;
        }

        osoba.IdUzytkownik = id;
        osoba.IdRola = 2;

        await _context.SaveChangesAsync();

        return osoba.IdOsoba;
    }

    private bool DoesEmailExist(string email)
    {
        return _context.Osobas.Any(p => p.Email == email);
    }
}