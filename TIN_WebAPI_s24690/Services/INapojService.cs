using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public interface INapojService
{
    public Task<IList<Napoj>> GetNapojeAsync();
    public Task<IList<Napoj>> GetNapojeTlumaczenieAsync();
}