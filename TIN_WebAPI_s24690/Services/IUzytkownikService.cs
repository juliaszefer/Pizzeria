using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Services;

public interface IUzytkownikService
{
    public Task<Uzytkownik?> GetUzytkownikAsync(string login, string haslo);
}