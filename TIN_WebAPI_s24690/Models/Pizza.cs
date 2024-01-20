using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Pizza
{
    public int IdPizza { get; set; }

    public string Nazwa { get; set; } = null!;

    public double Cena { get; set; }

    public virtual ICollection<PizzaSkladnik> PizzaSkladniks { get; set; } = new List<PizzaSkladnik>();

    public virtual ICollection<PizzaTlumaczenie> PizzaTlumaczenies { get; set; } = new List<PizzaTlumaczenie>();

    public virtual ICollection<ZamowieniePizza> ZamowieniePizzas { get; set; } = new List<ZamowieniePizza>();
}
