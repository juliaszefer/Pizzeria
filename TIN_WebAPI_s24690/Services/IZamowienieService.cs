using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IZamowienieService
{
    public Task<IList<Zamowienie>> GetZamowieniasByOsobaIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowienieNapojByIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowienieDodatekByIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowieniePizzaByIdAsync(int id);

}