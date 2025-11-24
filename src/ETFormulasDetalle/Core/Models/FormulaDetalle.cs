using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class FormulaDetalle
{
    public int Idformula { get; set; }

    public int Linea { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public virtual Formula IdformulaNavigation { get; set; } = null!;
}
