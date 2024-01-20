using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class DodatekService : IDodatekService
{
    private readonly PizzeriaDbContext _context;

    public DodatekService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Dodatek>> GetDodatkiAsync()
    {
        var dodatki = await _context.Dodateks.ToListAsync();
        return dodatki;
    }

    public async Task<IList<Dodatek>> GetDodatkiTlumaczenieAsync()
    {
        var dodatki = await (from dodatek in _context.Dodateks
            join dodatekEn in _context.DodatekTlumaczenies on dodatek.IdDodatek equals dodatekEn.IdDodatek
            where dodatekEn.IdJezyk == 2
            select new Dodatek
            {
                IdDodatek = dodatek.IdDodatek,
                Nazwa = dodatekEn.Tlumaczenie,
                Cena = dodatek.Cena
            }).ToListAsync();

        return dodatki;
    }
}