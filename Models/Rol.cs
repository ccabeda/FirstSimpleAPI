using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAPI.Models
{
    public class Rol
    {
        [Key] //ponemos el id como key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Entity con sql server, para que aumente automaticamente el ID key.
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeCreación { get; set; }
        public DateTime FechaDeActualización { get; set; }
    }
}
