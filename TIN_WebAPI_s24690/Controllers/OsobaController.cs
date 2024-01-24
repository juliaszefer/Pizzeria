using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Models.DTO;
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
    
    [HttpGet("idUzytkownik/{id}")]
    public async Task<IActionResult> GetOsobaById(int id)
    {
        var osoba = await _osobaService.GetOsobaByIdAsync(id);
        if (osoba == null)
        {
            return NotFound("Osoba nie została znaleziona.");
        }
        return Ok(osoba);
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetOsobaByEmail(string email)
    {
        var osoba = await _osobaService.GetOsobaByEmailAsync(email);
        if (osoba == null)
        {
            return NotFound("Osoba nie została znaleziona.");
        }

        return Ok(osoba);
    }

    [HttpPost("NewOsoba")]
    public async Task<IActionResult> AddNewOsoba([FromBody] OsobaDto osobaDto)
    {
        var id = await _osobaService.AddNewOsoba(osobaDto);
        if (id == -1)
        {
            return BadRequest("Podany e-mail jest już wykorzystywany w bazie danych");
        }

        return Ok(id);
    }
    
    [HttpPost("NewOsobaUzytkownik")]
    public async Task<IActionResult> AddNewOsobaUzytkownik([FromBody] OsobaDto osobaDto)
    {
        var id = await _osobaService.AddNewOsobaUzytkownik(osobaDto);
        if (id == -1)
        {
            return BadRequest("Podany e-mail jest już wykorzystywany w bazie danych");
        }

        return Ok(id);
    }

    [HttpPut("UpdateOsoba")]
    public async Task<IActionResult> UpdateOsoba(int id)
    {
        var idOs = await _osobaService.UpdateOsobaToUzytkownik(id);
        if (idOs == -1)
        {
            return BadRequest("Podana osoba nie istnieje");
        }

        return Ok(id);
    }
}