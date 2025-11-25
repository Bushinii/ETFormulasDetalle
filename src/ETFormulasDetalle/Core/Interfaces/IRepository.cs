using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {

        //READ
        //Obtener entidad por su llave
        Task<T?> GetByIdAsync(object id);

        //Obtener todos los registros de una entidad
        Task<IEnumerable<T>> GetAllAsync();

        //Obtener entidades con un filtro
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        //WRITE
        //Creación de entidad
        Task AddAsync(T item);

        //Añadir una colección de entidades
        Task AddRangeAsync(IEnumerable<T> items);

        //UPDATE
        //Actualizar una entidad existente
        void Update(T item);

        //Actualizar una colección de entidades
        void UpdateRange(IEnumerable<T> items);

        //Guarda los datos en la base de datos
        Task<int> SaveChangesAsync();
    }
}
