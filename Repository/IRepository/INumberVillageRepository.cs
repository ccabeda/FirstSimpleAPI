using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface INumberVillageRepository : IRepositoryGeneric<NumberVilla> //repositorio especifico para las villas
    { 
        Task<NumberVilla> Actualizar(NumberVilla entidad); 
    }
}
