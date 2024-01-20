using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class NapojTlumaczenieController : Controller
{
    private readonly INapojService _napojService;

    public NapojTlumaczenieController(INapojService napojService)
    {
        _napojService = napojService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNapojTlumaczenie()
    {
        var napoje = await _napojService.GetNapojeTlumaczenieAsync();
        return Ok(napoje);
    }
}