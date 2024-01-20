using Microsoft.AspNetCore.Mvc;
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
}