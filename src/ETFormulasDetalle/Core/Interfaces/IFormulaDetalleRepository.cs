using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFormulaDetalleRepository 
    {
        //Obtiene el detalle mediante el FormulaID
        Task<List<FormulaDetalle>> GetByFormulaIdAsync(int idFormula);

        //Agrega la lista de detalles 
        Task AddRangeAsync(IEnumerable<FormulaDetalle> detalles);

        //Actualiza un registro de la tabla
        void UpdateDetalle(FormulaDetalle linea);

        //Actualiza varios registros de la tabla
        void UpdateDetalles(IEnumerable<FormulaDetalle> detalles);

        //Guarda los cambios en la base de datos
        Task<int> SaveChangesAsync();
    }
}
