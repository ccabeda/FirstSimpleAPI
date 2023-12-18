using System.ComponentModel.DataAnnotations;


namespace MiPrimeraAPI.Models.DTO
{
    public class VillaCreateDto //separamos el dto para crear y actualizar
    {
        [Required]
        [MaxLength(32)] //ya no se pide id para crear, antes lo pedia y debia dejarse en 0. ahora ya no molestara. esto hace que los controladores de id dif a 0 no hagan falta
        public required string Nombre { get; set; }
        [Required]
        public required string Ciudad { get; set; }
        [Required]
        public required string Pais { get; set; }
        [Required]
        public string ImagenURL { get; set; }
        public string Amenidad { get; set; }
    }
}
