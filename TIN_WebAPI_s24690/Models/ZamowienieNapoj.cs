using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class ZamowienieNapoj
{
    public int IdZamowienie { get; set; }

    public int IdNapoj { get; set; }

    public int Ilosc { get; set; }

    public virtual Napoj IdNapojNavigation { get; set; } = null!;

    public virtual Zamowienie IdZamowienieNavigation { get; set; } = null!;
}
