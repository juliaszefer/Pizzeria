using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class DodatekTlumaczenie
{
    public int IdJezyk { get; set; }

    public int IdDodatek { get; set; }

    public string Tlumaczenie { get; set; } = null!;

    public virtual Dodatek IdDodatekNavigation { get; set; } = null!;

    public virtual Jezyk IdJezykNavigation { get; set; } = null!;
}
