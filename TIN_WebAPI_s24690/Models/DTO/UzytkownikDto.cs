namespace TIN_WebAPI_s24690.Models.DTO;

public class UzytkownikDto
{
    public string Login { get; set; } = null!;

    public DateOnly DataUtworzeniaKonta { get; set; }

    public string HasloHash { get; set; } = null!;
}