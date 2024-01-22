using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Models.DTO;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class SkladnikController : Controller
{
    private readonly ISkladnikService _skladnikService;

    public SkladnikController(ISkladnikService skladnikService)
    {
        _skladnikService = skladnikService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSkladniks()
    {
        var skladniki = await _skladnikService.GetSkladniksAsync();
        return Ok(skladniki);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewSkladnik(SkladnikDto skladnikDto)
    {
        var id = await _skladnikService.AddNewSkladnikAsync(skladnikDto);
        return Ok(id);
    }
}