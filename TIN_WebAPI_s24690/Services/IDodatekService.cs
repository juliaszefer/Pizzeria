using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IDodatekService
{
    public Task<IList<Dodatek>> GetDodatkiAsync();
    public Task<IList<Dodatek>> GetDodatkiTlumaczenieAsync();
    public Task<int> AddNewDodatekAsync(NewItemDto newItemDto);
}