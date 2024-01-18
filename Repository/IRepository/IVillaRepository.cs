using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepositoryGeneric<Villa> //repositorio especifico para las villas
    { 
        Task<Villa> Actualizar(Villa entidad); 
    }
}
