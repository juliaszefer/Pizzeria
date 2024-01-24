namespace TIN_WebAPI_s24690.Models.DTO;

public class OsobaDto
{
    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string NrTelefonu { get; set; } = null!;

    public string Email { get; set; } = null!;
    public int IdAdres { get; set; }
}