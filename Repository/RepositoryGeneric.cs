using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MiPrimeraAPI.Repository
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly AplicationDbContext _db; //traemos el contexto a los controladores para usar con la base de datos
        internal DbSet<TEntity> dbSet; //Conversión del tipo <T> a entidad

        public RepositoryGeneric(AplicationDbContext db) //constructor
        {
            _db = db;
            this.dbSet = _db.Set<TEntity>();
        }

        public async Task Agregar(TEntity entidad) //metodo generico para crear
        {
            await dbSet.AddAsync(entidad);
            await Guardar();
        }

        public async Task Eliminar(TEntity entidad) //metodo generico para eliminar
        {
            dbSet.Remove(entidad);
            await Guardar();
        }

        public async Task Guardar() //metodo generico para guardar
        {
            await _db.SaveChangesAsync();
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>>? filtro = null, bool tracked = true) //metodo para obtener 1 villa
        {
            IQueryable<TEntity> query = dbSet;
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

        public async Task<List<TEntity>> ObtenerTodos(Expression<Func<TEntity, bool>>? filtro = null) //metodo para obtener lista de villas
        {
            IQueryable<TEntity> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }


        //***LOS METODOS DE ACTUALIZAR NO SON GENERICOS, VAN EN LOS REPOS ESPECIFICOS
    }
}
