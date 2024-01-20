using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
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
        Adres newAdres = await _adresService.GetAdresByIdAsync(id);
        return Ok(newAdres);
    }
}