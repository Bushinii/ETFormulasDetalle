using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Campos privados
        protected readonly ETFormulasDBContext _context;
        protected readonly DbSet<T> _dbSet;

        //Constructor
        public Repository(ETFormulasDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        #region READ
        //Obtener entidad por su llave
        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        //Obtener todos los registros de una entidad
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //Obtener entidades con un filtro
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }
        #endregion

        #region WRITE
        //WRITE
        //Creación de entidad
        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
        }

        //Añadir una colección de entidades
        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _dbSet.AddRangeAsync(items);
        }
        #endregion

        #region UPDATE
        //UPDATE
        //Actualizar una entidad existente
        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        //Actualizar una colección de entidades
        public void UpdateRange(IEnumerable<T> items)
        {
            _dbSet.UpdateRange(items);
        }
        #endregion

        //Guarda los datos en la base de datos
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
