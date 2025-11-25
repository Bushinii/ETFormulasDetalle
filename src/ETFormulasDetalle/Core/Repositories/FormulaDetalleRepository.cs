using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class FormulaDetalleRepository: IFormulaDetalleRepository 
    {
        private readonly ETFormulasDBContext _context;
        public FormulaDetalleRepository(ETFormulasDBContext context)
        {
            _context = context;
        }

        //Obtiene el detalle mediante el FormulaID
        public async Task<List<FormulaDetalle>> GetByFormulaIdAsync(int idFormula)
        {
            return await _context.FormulaDetalles
                .Where(d => d.Idformula == idFormula && d.Activo)
                .OrderBy(d => d.Linea)
                .ToListAsync();
        }

        //Agrega la lista de detalles 
        public async Task AddRangeAsync(IEnumerable<FormulaDetalle> detalles)
        {
            await _context.FormulaDetalles.AddRangeAsync(detalles);
        }

        //Actualiza un registro de la tabla
        public void UpdateDetalle(FormulaDetalle linea)
        {
            _context.FormulaDetalles.Update(linea);
        }

        //Actualiza varios registros de la tabla
        public void UpdateDetalles(IEnumerable<FormulaDetalle> detalles)
        {
            _context.FormulaDetalles.UpdateRange(detalles);
        }

        //Guarda los cambios en la base de datos
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
