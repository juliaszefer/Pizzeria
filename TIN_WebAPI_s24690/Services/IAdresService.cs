using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IAdresService
{
    public Task<Adres?> GetAdresByIdAsync(int id);
    public Task<int> AddNewAdressAsync(AdresDto adresDto);
}