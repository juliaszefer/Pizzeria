using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Rola
{
    public int IdRola { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Osoba> Osobas { get; set; } = new List<Osoba>();
}
