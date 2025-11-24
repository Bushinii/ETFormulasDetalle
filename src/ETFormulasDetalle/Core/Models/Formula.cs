using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Formula
{
    public int Idformula { get; set; }

    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdusuarioCreacion { get; set; }

    public int? IdusuarioActualizacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<FormulaDetalle> FormulaDetalles { get; set; } = new List<FormulaDetalle>();

    public virtual Producto IdproductoNavigation { get; set; } = null!;

    public virtual Usuario? IdusuarioActualizacionNavigation { get; set; }

    public virtual Usuario IdusuarioCreacionNavigation { get; set; } = null!;
}
