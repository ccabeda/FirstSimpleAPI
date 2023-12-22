using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MiPrimeraAPI.Models
{
    public class Villa //para crear endpoint
                       //PASO 1) creo los atributos de lo que quiero que se vea
    {
        [Key] //ponemos el id como key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Entity con sql server, para que aumente automaticamente el ID key.
        public int Id { get; set; } //GET Y SET para que puedan pedirse
        public required string Nombre { get; set; }
        public required string Ciudad { get; set; }
        public required string Pais { get; set; }
        public  string  ImagenURL { get; set; }
        public  string Amenidad { get; set; }   
        public DateTime FechaDeCreación { get; set; }
        public DateTime FechaDeActualización { get; set; }

        


    }
}
