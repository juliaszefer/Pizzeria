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
}