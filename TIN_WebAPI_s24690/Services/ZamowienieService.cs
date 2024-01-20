using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public class ZamowienieService : IZamowienieService
{
    private readonly PizzeriaDbContext _context;

    public ZamowienieService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Zamowienie>> GetZamowieniasByOsobaIdAsync(int id)
    {
        List<Zamowienie> zamowienies =
            await (from zamowienie in _context.Zamowienies 
                    where zamowienie.IdOsoba == id select zamowienie).ToListAsync();
        return zamowienies;
    }

    public async Task<IList<ZamowienieProduktDto>> GetZamowienieNapojByIdAsync(int id)
    {
        List<ZamowienieProduktDto> napoje = await (from zamowienieNapoj in _context.ZamowienieNapojs
            join napoj in _context.Napojs on zamowienieNapoj.IdNapoj equals napoj.IdNapoj
            where zamowienieNapoj.IdZamowienie == id
            select new ZamowienieProduktDto
            {
                Nazwa = napoj.Nazwa,
                Cena = napoj.Cena,
                Ilosc = zamowienieNapoj.Ilosc
            }).ToListAsync();
        return napoje;
    }

    public async Task<IList<ZamowienieProduktDto>> GetZamowienieDodatekByIdAsync(int id)
    {
        List<ZamowienieProduktDto> dodatki = await (from zamowienieDodatek in _context.ZamowienieDodateks
            join dodatek in _context.Dodateks on zamowienieDodatek.IdDodatek equals dodatek.IdDodatek
            where zamowienieDodatek.IdZamowienie == id
            select new ZamowienieProduktDto
            {
                Nazwa = dodatek.Nazwa,
                Cena = dodatek.Cena,
                Ilosc = zamowienieDodatek.Ilosc
            }).ToListAsync();
        return dodatki;
    }

    public async Task<IList<ZamowienieProduktDto>> GetZamowieniePizzaByIdAsync(int id)
    {
        List<ZamowienieProduktDto> pizze = await (from zamowieniePizza in _context.ZamowieniePizzas
            join pizza in _context.Pizzas on zamowieniePizza.IdPizza equals pizza.IdPizza
            where zamowieniePizza.IdZamowienie == id
            select new ZamowienieProduktDto
            {
                Nazwa = pizza.Nazwa,
                Cena = pizza.Cena,
                Ilosc = zamowieniePizza.Ilosc
            }).ToListAsync();
        return pizze;
    }
}