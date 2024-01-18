using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAPI.Models.DTO
{
    public class NumberVillaDto
    {
        public int VillaNo { set; get; } 
        [Required]
        public int VillaId { set; get; }
        public int HabitacionesDisponibles { set; get; }
    }
}
