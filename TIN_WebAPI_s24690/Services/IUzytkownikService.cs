using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IUzytkownikService
{
    public Task<Uzytkownik?> GetUzytkownikAsync(string login, string haslo);
    public Task<int> AddNewUzytkownik(UzytkownikDto uzytkownikDto);
}