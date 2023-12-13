using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MiPrimeraAPI.Models
{
    public class Villa //para crear endpoint
                       //PASO 1) creo los atributos de lo que quiero que se vea
    {
        public int Id { get; set; } //GET Y SET para que puedan pedirse

        public required string Nombre { get; set; }

        public required string Ciudad { get; set; }

        public required string Pais { get; set; }

        public DateTime FechaDeCareación { get; set; }

        


    }
}
