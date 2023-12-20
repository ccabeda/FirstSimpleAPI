using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Repository.IRepository;

namespace MiPrimeraAPI.Repository
{
    public class VillageRepository : RepositoryGeneric<Villa>, IVillageRepository
    {
        private readonly AplicationDbContext _db;

        public VillageRepository(AplicationDbContext db) : base(db) //Al llamar base(db), estás pasando el contexto de base de datos (AplicationDbContext) a la clase
        {                                                           //base RepositoryGeneric<Villa>, lo que permite inicializar correctamente la clase base y evitar el
                                                                    //error que mencionabas anteriormente.
            _db = db;
        }

        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaDeActualización = DateTime.Now; //actualizamos la fecha
            _db.villas.Update(entidad); //updateamos la entidad
            await _db.SaveChangesAsync(); //guardamos los cmabios
            return entidad; //retornamos la villa 
        }
    }
}
