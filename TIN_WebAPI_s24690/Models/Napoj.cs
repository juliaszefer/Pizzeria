using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Napoj
{
    public int IdNapoj { get; set; }

    public string Nazwa { get; set; } = null!;

    public double Cena { get; set; }

    public virtual ICollection<NapojTlumaczenie> NapojTlumaczenies { get; set; } = new List<NapojTlumaczenie>();

    public virtual ICollection<ZamowienieNapoj> ZamowienieNapojs { get; set; } = new List<ZamowienieNapoj>();
}
