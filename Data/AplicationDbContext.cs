using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Data
{
    public class AplicationDbContext : DbContext //CONECTAR CON ENTITY A UNA DB. PASO 1) Creamos el contexto
    {
        // Constructor de la clase AplicationDbContext que recibe las opciones de configuración para el contexto de base de datos
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            // Este constructor inicializa el contexto de la base de datos con las opciones proporcionadas
        }

        public DbSet<Villa> villas { get; set; } //creamos la tabla de villas con DbSet

        public DbSet<NumberVilla> NumeroVillas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        //Funcion de Entity para crear datos precargados en la Db a la hora de crearla o hacer la migración, asi no comienza la Db vacia.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa { Id = 1, Nombre = "Edificio en la ciudad", Ciudad = "Buenos Aires", Pais = "Argentina", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now },
                new Villa { Id = 2, Nombre = "Casa en la playa", Ciudad = "Ibiza", Pais = "España", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now },
                new Villa { Id = 3, Nombre = "Cabaña en las montañas", Ciudad = "Mendoza", Pais = "Argentina", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario {Id = 1,UserName= "pperez_", Nombre = "Rodrigo", Apellido = "Pérez", Contraseña= "123.@",Gmail= "rperez@gmail.com", Rol= "Administrador", FechaDeCreación = DateTime.Now, FechaDeActualización= DateTime.Now }
                );
        }
    }
}
