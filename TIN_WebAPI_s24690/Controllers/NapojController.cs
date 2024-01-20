using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class NapojController : Controller
{
    private readonly INapojService _napojService;

    public NapojController(INapojService napojService)
    {
        _napojService = napojService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNapoje()
    {
        var napoje = await _napojService.GetNapojeAsync();
        return Ok(napoje);
    }
}