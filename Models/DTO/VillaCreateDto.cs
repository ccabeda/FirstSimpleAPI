using System.ComponentModel.DataAnnotations;


namespace MiPrimeraAPI.Models.DTO
{
    public class VillaCreateDto //separamos el dto para crear y actualizar
    {
        
        [MaxLength(32)] //ya no se pide id para crear, antes lo pedia y debia dejarse en 0. ahora ya no molestara. esto hace que los controladores de id dif a 0 no hagan falta
        public required string Nombre { get; set; }
    
        public required string Ciudad { get; set; }
    
        public required string Pais { get; set; }
        
        public string? ImagenURL { get; set; }
        public string? Amenidad { get; set; }
    }
}
