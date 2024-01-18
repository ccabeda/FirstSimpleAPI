using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAPI.Models
{
    public class Usuario
    {
        [Key] //ponemos el id como key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Entity con sql server, para que aumente automaticamente el ID key.
        public int Id { get; set; }
        public string UserName {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Gmail { get; set; }
        public string Contraseña { get; set; }
        public int RolId { set; get; }
        [ForeignKey("RolId")]
        public Rol Rol { set; get; }
        public DateTime FechaDeCreación { get; set; }
        public DateTime FechaDeActualización { get; set; }
    }
}
