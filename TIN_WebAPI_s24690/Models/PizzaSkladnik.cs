using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class PizzaSkladnik
{
    public int IdPizzaSkladnik { get; set; }

    public int IdPizza { get; set; }

    public int IdSkladnik { get; set; }

    public virtual Pizza IdPizzaNavigation { get; set; } = null!;

    public virtual Skladnik IdSkladnikNavigation { get; set; } = null!;
}
