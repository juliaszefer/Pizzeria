using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class NapojTlumaczenie
{
    public int IdJezyk { get; set; }

    public int IdNapoj { get; set; }

    public string Tlumaczenie { get; set; } = null!;

    public virtual Jezyk IdJezykNavigation { get; set; } = null!;

    public virtual Napoj IdNapojNavigation { get; set; } = null!;
}
