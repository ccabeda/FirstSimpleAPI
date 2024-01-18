using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Repository.IRepository
{
    public interface IUsuarioRepository : IRepositoryGeneric<Usuario> //repositorio especifico para los usuarios
    {
        Task<Usuario> Actualizar(Usuario entidad);
        Task<Usuario> Autenticar(UsuarioLoginDto entidad); //autenticar que el login es correcto
    }
}
