using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository.IRepository;

namespace MiPrimeraAPI.Repository
{
    public class UsuarioRepository : RepositoryGeneric<Usuario>, IUsuarioRepository
    {
        private readonly AplicationDbContext _db;

        public UsuarioRepository(AplicationDbContext db) : base(db) //Al llamar base(db), estás pasando el contexto de base de datos (AplicationDbContext) a la clase
        {                                                           //base RepositoryGeneric<Usuario>, lo que permite inicializar correctamente la clase base y evitar el
                                                                    //error que mencionabas anteriormente.
            _db = db;
        }

        public async Task<Usuario> Actualizar(Usuario entidad)
        {
            entidad.FechaDeActualización = DateTime.Now; //actualizamos la fecha
            _db.Usuarios.Update(entidad); //updateamos la entidad
            await _db.SaveChangesAsync(); //guardamos los cmabios
            return entidad; //retornamos el usuario 
        }

        public async Task<Usuario> Autenticar(UsuarioLoginDto entidad)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.UserName == entidad.UserName && u.Contraseña == entidad.Contraseña); //verificar login
        }
    }  
}
