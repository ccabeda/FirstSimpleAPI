using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface INumberVillaRepository : IRepositoryGeneric<NumberVilla> //repositorio especifico para las numerosvillas
    { 
        Task<NumberVilla> Actualizar(NumberVilla entidad); 
    }
}
