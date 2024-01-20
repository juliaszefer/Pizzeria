using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;

namespace TIN_WebAPI_s24690.Services;

public class RolaService : IRolaService
{
    private readonly PizzeriaDbContext _context;

    public RolaService(PizzeriaDbContext context)
    {
        _context = context;
    }


    public async Task<string?> GetRolaByIdAsync(int id)
    {
        string? name = await (from rola in _context.Rolas 
            where rola.IdRola == id select rola.Nazwa).FirstOrDefaultAsync();
        return name;
    }
}