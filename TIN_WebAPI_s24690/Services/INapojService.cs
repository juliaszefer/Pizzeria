using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface INapojService
{
    public Task<IList<Napoj>> GetNapojeAsync();
    public Task<IList<Napoj>> GetNapojeTlumaczenieAsync();
    public Task<int> AddNewNapojAsync(NewItemDto newItemDto);
}