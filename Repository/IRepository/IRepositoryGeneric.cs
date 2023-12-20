using System.Linq.Expressions;

namespace MiPrimeraAPI.Repository.IRepository
{ //interfaz generica para cualquier tipo de sistema
    public interface IRepositoryGeneric<T> where T : class //esto permite que t sea solo clases
    {
        Task Agregar(T entidad); //funcion para crear uuna entiedad

        Task Eliminar(T entidad); //eliminar

        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null); //obtiene la lista de elementos y puede ponerse un filtro, que es null por default

        Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true);

        Task Guardar(); //guardar cambios 
    }
} //se utiliza Task<T> cuando devuelve del tipo de la clase.
