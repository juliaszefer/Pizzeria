using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

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

    public async Task<int> AddNewDodatekAsync(NewItemDto newItemDto)
    {
        int id = await _context.Dodateks.MaxAsync(e => e.IdDodatek) + 1;

        Dodatek dodatek = new Dodatek
        {
            IdDodatek = id,
            Nazwa = newItemDto.Nazwa,
            Cena = newItemDto.Cena
        };

        DodatekTlumaczenie dodatekTlumaczenie = new DodatekTlumaczenie
        {
            IdDodatek = id,
            IdJezyk = 2,
            Tlumaczenie = newItemDto.Tlumaczenie
        };

        await _context.Dodateks.AddAsync(dodatek);
        await _context.DodatekTlumaczenies.AddAsync(dodatekTlumaczenie);

        await _context.SaveChangesAsync();

        return id;
    }
}