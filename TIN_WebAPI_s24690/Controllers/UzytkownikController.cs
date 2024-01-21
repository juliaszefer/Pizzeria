using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Models.DTO;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class UzytkownikController : Controller
{
    private readonly IUzytkownikService _uzytkownikService;

    public UzytkownikController(IUzytkownikService uzytkownikService)
    {
        _uzytkownikService = uzytkownikService;
    }
    
    [HttpGet("{login}/{haslo}")]
    public async Task<IActionResult> GetUzytkownik(string login, string haslo)
    {
        var uzytkownik = await _uzytkownikService.GetUzytkownikAsync(login, haslo);
        if (uzytkownik == null)
        {
            return NotFound("Użytkownik nie został znaleziony.");
        }
        return Ok(uzytkownik);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewUzytkownik([FromBody] UzytkownikDto uzytkownikDto)
    {
        var id = await _uzytkownikService.AddNewUzytkownik(uzytkownikDto);
        if (id == -1)
        {
            return BadRequest("Login już istnieje w bazie danych");
        }
        return Ok(id);
    }
}