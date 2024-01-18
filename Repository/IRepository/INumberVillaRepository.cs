using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface INumberVillaRepository : IRepositoryGeneric<NumberVilla> //repositorio especifico para las villas
    { 
        Task<NumberVilla> Actualizar(NumberVilla entidad); 
    }
}
