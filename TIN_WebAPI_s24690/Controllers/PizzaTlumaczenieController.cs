using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaTlumaczenieController : Controller
{
    private readonly IPizzaService _pizzaService;

    public PizzaTlumaczenieController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPizzasTlumaczenie()
    {
        var pizze = await _pizzaService.GetPizzaTlumaczenieAsync();
        return Ok(pizze);
    }
}