using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Skladnik
{
    public int IdSkladnik { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<PizzaSkladnik> PizzaSkladniks { get; set; } = new List<PizzaSkladnik>();

    public virtual ICollection<SkladnikTlumaczenie> SkladnikTlumaczenies { get; set; } = new List<SkladnikTlumaczenie>();
}
