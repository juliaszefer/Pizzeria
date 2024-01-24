using TIN_WebAPI_s24690.Models.DTO;

namespace TIN_WebAPI_s24690.Services;

public interface IPizzaService
{
    public Task<IList<PizzaDto>> GetPizzaAsync();
    public Task<IList<PizzaDto>> GetPizzaTlumaczenieAsync();
    public Task<int> AddNewPizzaAsync(NewItemDto newItemDto);
    public Task<int> AddPizzaSkladnikAsync(PizzaSkladnikDto pizzaSkladnikDto);
}