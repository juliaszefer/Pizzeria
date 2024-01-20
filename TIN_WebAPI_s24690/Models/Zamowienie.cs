using System;
using System.Collections.Generic;

namespace TIN_WebAPI_s24690.Models;

public partial class Zamowienie
{
    public int IdZamowienie { get; set; }

    public DateTime DataZlozenia { get; set; }

    public int IdOsoba { get; set; }

    public string Status { get; set; } = null!;

    public virtual Osoba IdOsobaNavigation { get; set; } = null!;

    public virtual ICollection<ZamowienieDodatek> ZamowienieDodateks { get; set; } = new List<ZamowienieDodatek>();

    public virtual ICollection<ZamowienieNapoj> ZamowienieNapojs { get; set; } = new List<ZamowienieNapoj>();

    public virtual ICollection<ZamowieniePizza> ZamowieniePizzas { get; set; } = new List<ZamowieniePizza>();
}
