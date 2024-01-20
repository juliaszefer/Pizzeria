using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Jezyk
{
    public int IdJezyk { get; set; }

    public string Kod { get; set; } = null!;

    public virtual ICollection<DodatekTlumaczenie> DodatekTlumaczenies { get; set; } = new List<DodatekTlumaczenie>();

    public virtual ICollection<NapojTlumaczenie> NapojTlumaczenies { get; set; } = new List<NapojTlumaczenie>();

    public virtual ICollection<PizzaTlumaczenie> PizzaTlumaczenies { get; set; } = new List<PizzaTlumaczenie>();

    public virtual ICollection<SkladnikTlumaczenie> SkladnikTlumaczenies { get; set; } = new List<SkladnikTlumaczenie>();
}
