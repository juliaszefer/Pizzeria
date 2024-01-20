namespace TIN_WebAPI_s24690.Models.DTO;

public class AdresDto
{
    public string Kraj { get; set; } = null!;

    public string Miasto { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public int NrUlicy { get; set; }

    public int? NrMieszkania { get; set; }
}