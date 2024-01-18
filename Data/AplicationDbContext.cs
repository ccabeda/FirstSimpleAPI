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
        public DbSet<Rol> Roles { get; set; }


        //Funcion de Entity para crear datos precargados en la Db a la hora de crearla o hacer la migración, asi no comienza la Db vacia.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa { Id = 1, Nombre = "Edificio en la ciudad", Ciudad = "Buenos Aires", Pais = "Argentina", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now },
                new Villa { Id = 2, Nombre = "Casa en la playa", Ciudad = "Ibiza", Pais = "España", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now },
                new Villa { Id = 3, Nombre = "Cabaña en las montañas", Ciudad = "Mendoza", Pais = "Argentina", ImagenURL = "", Amenidad = "", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Administrador", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 2, Nombre = "Usuario", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 3, Nombre = "SuperAdmin", FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 10, UserName = "pperez_", Nombre = "Lautaro", Apellido = "Pérez", Contraseña = "123.@", Gmail = "rperez@gmail.com", RolId = 1, FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 11, UserName = "jorgemessi", Nombre = "Leonel", Apellido = "Messi", Contraseña = "123.@", Gmail = "leo@gmail.com", RolId = 2, FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 12, UserName = "doblep", Nombre = "Pedro", Apellido = "Peña", Contraseña = "123.@", Gmail = "doblep@gmail.com", RolId = 3, FechaDeCreación = DateTime.Now, FechaDeActualización = DateTime.Now }
                );
        }
    }
}
