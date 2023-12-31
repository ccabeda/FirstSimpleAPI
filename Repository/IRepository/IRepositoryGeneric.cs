using System.Linq.Expressions;

namespace MiPrimeraAPI.Repository.IRepository
{ //interfaz generica para cualquier tipo de sistema
    public interface IRepositoryGeneric<TEntity> where TEntity : class //esto permite que t sea solo clases
    {
        Task Agregar(TEntity entidad); //funcion para crear uuna entiedad

        Task Eliminar(TEntity entidad); //eliminar

        Task<List<TEntity>> ObtenerTodos(Expression<Func<TEntity, bool>>? filtro = null); //obtiene la lista de elementos y puede ponerse un filtro, que es null por default

        Task<TEntity> Obtener(Expression<Func<TEntity, bool>>? filtro = null, bool tracked = true);

        Task Guardar(); //guardar cambios 
    }
} //se utiliza Task<T> cuando devuelve del tipo de la clase.
