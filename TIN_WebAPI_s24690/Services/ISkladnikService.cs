using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface ISkladnikService
{
    public Task<IList<Skladnik>> GetSkladniksAsync();
    public Task<int> AddNewSkladnikAsync(SkladnikDto skladnikDto);
}