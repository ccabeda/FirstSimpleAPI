using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimeraAPI.Models
{
    public class NumberVilla //nueva tabla para conectar uno a muchos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //sera la key pero no se sumara automaticamente
        public int VillaNo { set; get; } //habitaciones disponibles

        [Required]
        public int VillaId { set; get; }

        [ForeignKey("VillaId")]
        public Villa Villa { set; get; }

        public int HabitacionesDisponibles { set; get; }
        public DateTime FechaDeCreación { get; set; }
        public DateTime FechaDeActualización { get; set; }
    }
}
