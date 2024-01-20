using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Osoba
{
    public int IdOsoba { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public string NrTelefonu { get; set; } = null!;

    public int IdAdres { get; set; }

    public string Email { get; set; } = null!;

    public int? IdUzytkownik { get; set; }

    public int IdRola { get; set; }

    public virtual Adres IdAdresesNavigation { get; set; } = null!;

    public virtual Rola IdRolaNavigation { get; set; } = null!;

    public virtual Uzytkownik? IdUzytkownikNavigation { get; set; }

    public virtual ICollection<Zamowienie> Zamowienies { get; set; } = new List<Zamowienie>();
}
