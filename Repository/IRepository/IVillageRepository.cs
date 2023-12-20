using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface IVillageRepository : IRepositoryGeneric<Villa> //repositorio especifico para las villas
    { 
        Task<Villa> Actualizar(Villa entidad); 
    }
}
