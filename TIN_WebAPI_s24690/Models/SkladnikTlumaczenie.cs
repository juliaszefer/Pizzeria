using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class SkladnikTlumaczenie
{
    public int IdJezyk { get; set; }

    public int IdSkladnik { get; set; }

    public string Tlumaczenie { get; set; } = null!;

    public virtual Jezyk IdJezykNavigation { get; set; } = null!;

    public virtual Skladnik IdSkladnikNavigation { get; set; } = null!;
}
