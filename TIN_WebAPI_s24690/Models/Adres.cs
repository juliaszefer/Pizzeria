using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Adres
{
    public int IdAdres { get; set; }

    public string Kraj { get; set; } = null!;

    public string Miasto { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public int NrUlicy { get; set; }

    public int? NrMieszkania { get; set; }

    public virtual ICollection<Osoba> Osobas { get; set; } = new List<Osoba>();
}
