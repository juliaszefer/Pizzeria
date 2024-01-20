using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Uzytkownik
{
    public int IdUzytkownik { get; set; }

    public string Login { get; set; } = null!;

    public DateOnly DataUtworzeniaKonta { get; set; }

    public string HasloHash { get; set; } = null!;

    public virtual ICollection<Osoba> Osobas { get; set; } = new List<Osoba>();
}
