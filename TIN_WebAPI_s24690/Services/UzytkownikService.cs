using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

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

    public async Task<int> AddNewUzytkownik(UzytkownikDto uzytkownikDto)
    {
        int id = await _context.Uzytkowniks.MaxAsync(e => e.IdUzytkownik) + 1;

        if (DoesLoginExist(uzytkownikDto.Login))
        {
            return -1;
        }

        Uzytkownik uzytkownik = new Uzytkownik
        {
            IdUzytkownik = id,
            DataUtworzeniaKonta = DateOnly.FromDateTime(DateTime.Now),
            Login = uzytkownikDto.Login,
            HasloHash = uzytkownikDto.HasloHash
        };

        await _context.Uzytkowniks.AddAsync(uzytkownik);
        await _context.SaveChangesAsync();

        return id;
    }
    
    private bool DoesLoginExist(string login)
    {
        return _context.Uzytkowniks.Any(p => p.Login == login);
    }
}