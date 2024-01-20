using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class NapojService : INapojService
{
    private readonly PizzeriaDbContext _context;

    public NapojService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Napoj>> GetNapojeAsync()
    {
        var napoje = await _context.Napojs.ToListAsync();
        return napoje;
    }
}