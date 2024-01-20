using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class ZamowieniePizza
{
    public int IdZamowienie { get; set; }

    public int IdPizza { get; set; }

    public int Ilosc { get; set; }

    public virtual Pizza IdPizzaNavigation { get; set; } = null!;

    public virtual Zamowienie IdZamowienieNavigation { get; set; } = null!;
}
