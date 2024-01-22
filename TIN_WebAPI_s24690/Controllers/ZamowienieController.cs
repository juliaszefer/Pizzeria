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

    [HttpPost("Zamowienie")]
    public async Task<IActionResult> AddNewZamowienie(int idOsoba)
    {
        var id = await _zamowienieService.AddNewZamowienieAsync(idOsoba);
        return Ok(id);
    }

    [HttpPut("ZamowienieStatus")]
    public async Task<IActionResult> UpdateStatusZamowienia(int id, string status)
    {
        var idZamowienia = await _zamowienieService.UpdateStatusZamowieniaAsync(id, status);
        if (idZamowienia == -1)
        {
            return BadRequest("Takie zamowienie nie istnieje");
        }
        return Ok(idZamowienia);
    }

    [HttpPost("ZamowienieDodatek")]
    public async Task<IActionResult> AddNewZamowienieDodatek(int idZamowienie, int idDodatek, int ilosc)
    {
        var id = await _zamowienieService.AddNewZamowienieDodatekAsync(idZamowienie, idDodatek, ilosc);
        return Ok(id);
    }

    [HttpPost("ZamowienieNapoj")]
    public async Task<IActionResult> AddNewZamowienieNapoj(int idZamowienie, int idNapoj, int ilosc)
    {
        var id = await _zamowienieService.AddNewZamowienieNapojAsync(idZamowienie, idNapoj, ilosc);
        return Ok(id);
    }

    [HttpPost("ZamowieniePizza")]
    public async Task<IActionResult> AddNewZamowieniePizza(int idZamowienie, int idPizza, int ilosc)
    {
        var id = await _zamowienieService.AddNewZamowieniePizzaAsync(idZamowienie, idPizza, ilosc);
        return Ok(id);
    }
    
}