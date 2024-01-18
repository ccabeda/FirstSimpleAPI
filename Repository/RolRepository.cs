using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Repository.IRepository;

namespace MiPrimeraAPI.Repository
{
    public class RolRepository : RepositoryGeneric<Rol>, IRolRepository
    {
        private readonly AplicationDbContext _db;

        public RolRepository(AplicationDbContext db) : base(db) //Al llamar base(db), estás pasando el contexto de base de datos (AplicationDbContext) a la clase
        {                                                           //base RepositoryGeneric<NumberVilla>, lo que permite inicializar correctamente la clase base y evitar el
                                                                    //error que mencionabas anteriormente.
            _db = db;
        }

        public async Task<Rol> Actualizar(Rol entidad)
        {
            entidad.FechaDeActualización = DateTime.Now; //actualizamos la fecha
            _db.Roles.Update(entidad); //updateamos la entidad
            await _db.SaveChangesAsync(); //guardamos los cmabios
            return entidad; //retornamos el número de villa
        }
    }
}
