using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class AdresController : Controller
{
    private readonly IAdresService _adresService;

    public AdresController(IAdresService adresService)
    {
        _adresService = adresService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdresById(int id)
    {
        var adres = await _adresService.GetAdresByIdAsync(id);
        if (adres == null)
        {
            return NotFound("Adres nie został znaleziony.");
        }
        return Ok(adres);
    }
}