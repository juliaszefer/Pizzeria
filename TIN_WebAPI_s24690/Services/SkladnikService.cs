using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Data;
using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public class SkladnikService : ISkladnikService
{
    private readonly PizzeriaDbContext _context;

    public SkladnikService(PizzeriaDbContext context)
    {
        _context = context;
    }
    public async Task<IList<Skladnik>> GetSkladniksAsync()
    {
        var skladniki = await _context.Skladniks.ToListAsync();
        return skladniki;
    }

    public async Task<int> AddNewSkladnikAsync(SkladnikDto skladnikDto)
    {
        int id = await _context.Skladniks.MaxAsync(e => e.IdSkladnik) + 1;

        Skladnik skladnik = new Skladnik
        {
            IdSkladnik = id,
            Nazwa = skladnikDto.Nazwa
        };

        SkladnikTlumaczenie skladnikTlumaczenie = new SkladnikTlumaczenie
        {
            IdJezyk = 2,
            IdSkladnik = id,
            Tlumaczenie = skladnikDto.Tlumaczenie
        };

        await _context.Skladniks.AddAsync(skladnik);
        await _context.SkladnikTlumaczenies.AddAsync(skladnikTlumaczenie);
        
        await _context.SaveChangesAsync();

        return id;
    }
}