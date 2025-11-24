using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int Rol { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Formula> FormulaIdusuarioActualizacionNavigations { get; set; } = new List<Formula>();

    public virtual ICollection<Formula> FormulaIdusuarioCreacionNavigations { get; set; } = new List<Formula>();

    public virtual Rol RolNavigation { get; set; } = null!;
}
