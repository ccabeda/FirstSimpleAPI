using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MiPrimeraAPI.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly AplicationDbContext _db; //traemos el contexto a los controladores para usar con la base de datos
        internal DbSet<T> dbSet; //Conversión del tipo <T> a entidad

        public RepositoryGeneric(AplicationDbContext db) //constructor
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task Agregar(T entidad) //metodo generico para crear
        {
            await dbSet.AddAsync(entidad);
            await Guardar();
        }

        public async Task Eliminar(T entidad) //metodo generico para eliminar
        {
            dbSet.Remove(entidad);
            await Guardar();
        }

        public async Task Guardar() //metodo generico para guardar
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true) //metodo para obtener 1 villa
        {
            IQueryable<T> query = dbSet;
            if(!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filtro !=null)
            {
                query = query.Where(filtro);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null) //metodo para obtener lista de villas
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }


        //***LOS METODOS DE ACTUALIZAR NO SON GENERICOS, VAN EN LOS REPOS ESPECIFICOS
    }
}
