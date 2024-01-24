using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Models.DTO;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class DodatekController : Controller
{
    private readonly IDodatekService _dodatekService;

    public DodatekController(IDodatekService dodatekService)
    {
        _dodatekService = dodatekService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDodatki()
    {
        var dodatki = await _dodatekService.GetDodatkiAsync();
        return Ok(dodatki);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewDodatek([FromBody] NewItemDto newItemDto)
    {
        var id = await _dodatekService.AddNewDodatekAsync(newItemDto);
        return Ok(id);
    }
}