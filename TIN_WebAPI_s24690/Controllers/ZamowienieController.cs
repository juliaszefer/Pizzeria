using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class ZamowienieController : Controller
{
    private readonly IZamowienieService _zamowienieService;

    public ZamowienieController(IZamowienieService zamowienieService)
    {
        _zamowienieService = zamowienieService;
    }
    
    [HttpGet("Osoba/{id}")]
    public async Task<IActionResult> GetZamowieniasByOsobaId(int id)
    {
        var zamowienies = await _zamowienieService.GetZamowieniasByOsobaIdAsync(id);
        return Ok(zamowienies);
    }

    [HttpGet("ZamowienieNapoj/{id}")]
    public async Task<IActionResult> GetZamowienieNapojById(int id)
    {
        var napoje = await _zamowienieService.GetZamowienieNapojByIdAsync(id);
        return Ok(napoje);
    }
    
    [HttpGet("ZamowienieDodatek/{id}")]
    public async Task<IActionResult> GetZamowienieDodatekById(int id)
    {
        var dodatki = await _zamowienieService.GetZamowienieDodatekByIdAsync(id);
        return Ok(dodatki);
    }
    
    [HttpGet("ZamowieniePizza/{id}")]
    public async Task<IActionResult> GetZamowieniePizzaById(int id)
    {
        var pizze = await _zamowienieService.GetZamowieniePizzaByIdAsync(id);
        return Ok(pizze);
    }
}