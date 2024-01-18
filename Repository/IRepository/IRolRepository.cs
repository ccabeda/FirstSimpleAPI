using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface IRolRepository : IRepositoryGeneric<Rol> //repositorio especifico para los roles
    {
        Task<Rol> Actualizar(Rol entidad);
    }
}
