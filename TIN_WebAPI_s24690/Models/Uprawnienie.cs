using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Uprawnienie
{
    public int IdUprawnienie { get; set; }

    public string Opis { get; set; } = null!;
}
