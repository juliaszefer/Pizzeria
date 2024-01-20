using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class DodatekTlumaczenieController : Controller
{
    private readonly IDodatekService _dodatekService;

    public DodatekTlumaczenieController(IDodatekService dodatekService)
    {
        _dodatekService = dodatekService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDodatekTlumaczenie()
    {
        var dodatki = await _dodatekService.GetDodatkiTlumaczenieAsync();
        return Ok(dodatki);
    }
}