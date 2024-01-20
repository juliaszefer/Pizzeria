using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class ZamowienieDodatek
{
    public int IdZamowienie { get; set; }

    public int IdDodatek { get; set; }

    public int Ilosc { get; set; }

    public virtual Dodatek IdDodatekNavigation { get; set; } = null!;

    public virtual Zamowienie IdZamowienieNavigation { get; set; } = null!;
}
