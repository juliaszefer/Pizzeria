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

    public async Task<int> AddNewZamowienieAsync(int idOsoba)
    {
        int id = await _context.Zamowienies.MaxAsync(e => e.IdZamowienie) + 1;

        Zamowienie zamowienie = new Zamowienie
        {
            IdZamowienie = id,
            IdOsoba = idOsoba,
            DataZlozenia = DateTime.Now,
            Status = "Przyjęte"
        };

        await _context.Zamowienies.AddAsync(zamowienie);
        await _context.SaveChangesAsync();

        return id;

    }

    public async Task<int> UpdateStatusZamowieniaAsync(int id, string status)
    {
        var zamowienie = await _context.Zamowienies.FindAsync(id);

        if (zamowienie == null)
        {
            return -1;
        }

        zamowienie.Status = status;

        await _context.SaveChangesAsync();
        return zamowienie.IdZamowienie;
    }

    public async Task<int> AddNewZamowieniePizzaAsync(int idZamowienie, int idPizza, int ilosc)
    {
        ZamowieniePizza zamowieniePizza = new ZamowieniePizza
        {
            IdZamowienie = idZamowienie,
            IdPizza = idPizza,
            Ilosc = ilosc
        };

        await _context.ZamowieniePizzas.AddAsync(zamowieniePizza);
        await _context.SaveChangesAsync();

        return idZamowienie;
    }

    public async Task<int> AddNewZamowienieNapojAsync(int idZamowienie, int idNapoj, int ilosc)
    {
        ZamowienieNapoj zamowienieNapoj = new ZamowienieNapoj
        {
            IdZamowienie = idZamowienie,
            IdNapoj = idNapoj,
            Ilosc = ilosc
        };

        await _context.ZamowienieNapojs.AddAsync(zamowienieNapoj);
        await _context.SaveChangesAsync();

        return idZamowienie;
    }

    public async Task<int> AddNewZamowienieDodatekAsync(int idZamowienie, int idDodatek, int ilosc)
    {
        ZamowienieDodatek zamowienieDodatek = new ZamowienieDodatek
        {
            IdZamowienie = idZamowienie,
            IdDodatek = idDodatek,
            Ilosc = ilosc
        };

        await _context.ZamowienieDodateks.AddAsync(zamowienieDodatek);
        await _context.SaveChangesAsync();

        return idZamowienie;
    }
}