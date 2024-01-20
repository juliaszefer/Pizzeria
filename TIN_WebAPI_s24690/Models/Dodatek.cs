using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Dodatek
{
    public int IdDodatek { get; set; }

    public string Nazwa { get; set; } = null!;

    public double Cena { get; set; }

    public virtual ICollection<DodatekTlumaczenie> DodatekTlumaczenies { get; set; } = new List<DodatekTlumaczenie>();

    public virtual ICollection<ZamowienieDodatek> ZamowienieDodateks { get; set; } = new List<ZamowienieDodatek>();
}
