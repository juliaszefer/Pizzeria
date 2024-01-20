using Microsoft.AspNetCore.Mvc;
using TIN_WebAPI_s24690.Services;

namespace TIN_WebAPI_s24690.Controllers;

[ApiController]
[Route("[controller]")]
public class RolaController : Controller
{
    private readonly IRolaService _rolaService;

    public RolaController(IRolaService rolaService)
    {
        _rolaService = rolaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRolaById(int id)
    {
        var rola = await _rolaService.GetRolaByIdAsync(id);
        if (rola == null)
        {
            return NotFound("Rola nie została znaleziona.");
        }

        return Ok(rola);
    }
}