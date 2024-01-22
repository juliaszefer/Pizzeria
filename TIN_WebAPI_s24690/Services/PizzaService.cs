using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzeriaDbContext _context;

    public PizzaService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<PizzaDto>> GetPizzaAsync()
    {
        var pizze = await _context.Pizzas.ToListAsync();
        List<PizzaDto> pizzaDtos = new List<PizzaDto>();

        foreach (var pizza in pizze)
        {
            List<Skladnik> skladniks = await (from piza in _context.Pizzas
                join pizaskladnik in _context.PizzaSkladniks on piza.IdPizza equals pizaskladnik.IdPizza
                join skladnik in _context.Skladniks on pizaskladnik.IdSkladnik equals skladnik.IdSkladnik
                where piza.IdPizza == pizza.IdPizza
                select skladnik).ToListAsync();

            PizzaDto pizzaDto = new PizzaDto
            {
                Nazwa = pizza.Nazwa,
                Cena = pizza.Cena,
                Skladniks = skladniks
            };
            
            pizzaDtos.Add(pizzaDto);
        }
        
        return pizzaDtos;
    }

    public async Task<IList<PizzaDto>> GetPizzaTlumaczenieAsync()
    {
        var pizze = await (from pizza in _context.Pizzas
            join pizzaEn in _context.PizzaTlumaczenies on pizza.IdPizza equals pizzaEn.IdPizza
            where pizzaEn.IdJezyk == 2
            select new Pizza
            {
                IdPizza = pizza.IdPizza,
                Nazwa = pizzaEn.Tlumaczenie,
                Cena = pizza.Cena
            }).ToListAsync();
        
        List<PizzaDto> pizzaDtos = new List<PizzaDto>();

        foreach (var pizza in pizze)
        {
            List<Skladnik> skladniks = await (from piza in _context.Pizzas
                join pizaskladnik in _context.PizzaSkladniks on piza.IdPizza equals pizaskladnik.IdPizza
                join skladnik in _context.Skladniks on pizaskladnik.IdSkladnik equals skladnik.IdSkladnik
                join skladnikTlumaczenie in _context.SkladnikTlumaczenies on skladnik.IdSkladnik equals skladnikTlumaczenie.IdSkladnik
                where piza.IdPizza == pizza.IdPizza && skladnikTlumaczenie.IdJezyk == 2
                select new Skladnik
                {
                    IdSkladnik = skladnik.IdSkladnik,
                    Nazwa = skladnikTlumaczenie.Tlumaczenie
                }).ToListAsync();

            PizzaDto pizzaDto = new PizzaDto
            {
                Nazwa = pizza.Nazwa,
                Cena = pizza.Cena,
                Skladniks = skladniks
            };
            
            pizzaDtos.Add(pizzaDto);
        }

        return pizzaDtos;
    }

    public async Task<int> AddNewPizzaAsync(NewItemDto newItemDto)
    {
        int id = await _context.Pizzas.MaxAsync(e => e.IdPizza) + 1;

        Pizza pizza = new Pizza
        {
            IdPizza = id,
            Nazwa = newItemDto.Nazwa,
            Cena = newItemDto.Cena
        };

        PizzaTlumaczenie pizzaTlumaczenie = new PizzaTlumaczenie
        {
            IdJezyk = 2,
            IdPizza = id,
            Tlumaczenie = newItemDto.Tlumaczenie
        };

        await _context.Pizzas.AddAsync(pizza);
        await _context.PizzaTlumaczenies.AddAsync(pizzaTlumaczenie);

        await _context.SaveChangesAsync();

        return id;
    }
}