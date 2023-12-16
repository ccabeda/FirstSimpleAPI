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
    }
}
