using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Formula> Formulas { get; set; } = new List<Formula>();
}
