using TIN_WebAPI_s24690.Models;
using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IZamowienieService
{
    public Task<IList<Zamowienie>> GetZamowieniasByOsobaIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowienieNapojByIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowienieDodatekByIdAsync(int id);
    public Task<IList<ZamowienieProduktDto>> GetZamowieniePizzaByIdAsync(int id);
    public Task<int> AddNewZamowienieAsync(int idOsoba);
    public Task<int> UpdateStatusZamowieniaAsync(int id, string status);
    public Task<int> AddNewZamowieniePizzaAsync(int idZamowienie, int idPizza, int ilosc);
    public Task<int> AddNewZamowienieNapojAsync(int idZamowienie, int idNapoj, int ilosc);
    public Task<int> AddNewZamowienieDodatekAsync(int idZamowienie, int idDodatek, int ilosc);

}