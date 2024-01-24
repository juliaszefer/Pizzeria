using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Models.DTO;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : Controller
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPizzas()
    {
        var pizze = await _pizzaService.GetPizzaAsync();
        return Ok(pizze);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPizza([FromBody] NewItemDto newItemDto)
    {
        var id = await _pizzaService.AddNewPizzaAsync(newItemDto);
        return Ok(id);
    }

    [HttpPost("PizzaSkladnik")]
    public async Task<IActionResult> AddNewPizzaSkladnik([FromBody] PizzaSkladnikDto pizzaSkladnikDto)
    {
        var id = await _pizzaService.AddPizzaSkladnikAsync(pizzaSkladnikDto);
        return Ok(id);
    }
}