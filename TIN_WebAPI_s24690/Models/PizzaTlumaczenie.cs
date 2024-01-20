using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class PizzaTlumaczenie
{
    public int IdJezyk { get; set; }

    public int IdPizza { get; set; }

    public string Tlumaczenie { get; set; } = null!;

    public virtual Jezyk IdJezykNavigation { get; set; } = null!;

    public virtual Pizza IdPizzaNavigation { get; set; } = null!;
}
