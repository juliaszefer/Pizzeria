namespace TIN_WebAPI_s24690.Models.DTO;

public class PizzaDto
{
    public int IdPizza { get; set; }
    public string Nazwa { get; set; } = null!;
    public double Cena { get; set; }
    public List<Skladnik> Skladniks { get; set; } = null!;
}