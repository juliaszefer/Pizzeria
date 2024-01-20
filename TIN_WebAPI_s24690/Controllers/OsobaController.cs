using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class OsobaController : Controller
{
    private readonly IOsobaService _osobaService;

    public OsobaController(IOsobaService osobaService)
    {
        _osobaService = osobaService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOsobaById(int id)
    {
        var osoba = await _osobaService.GetOsobaByIdAsync(id);
        if (osoba == null)
        {
            return NotFound("Osoba nie została znaleziona.");
        }
        return Ok(osoba);
    }
}