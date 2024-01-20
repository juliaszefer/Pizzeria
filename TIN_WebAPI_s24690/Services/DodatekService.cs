using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public class DodatekService : IDodatekService
{
    private readonly PizzeriaDbContext _context;

    public DodatekService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Dodatek>> GetDodatkiAsync()
    {
        var dodatki = await _context.Dodateks.ToListAsync();
        return dodatki;
    }
}