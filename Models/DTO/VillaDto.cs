using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAPI.Models.DTO
{   //Las clases DTO son para pasarle los atributos al controlador y que no tengan problemas con si hay atributos que no mostrar
    public class VillaDto
    {
        [Required] //obligamos a que sea requerido poner algo asino puede ser NULL.
        public int Id { get; set; } //PASO 3) Creamos el Dto para mostrar los atributos que queramos y no tener que mostrar todos. 
        [Required]
        [MaxLength(32)] //maximo 32 caracteres de nombre
        public required string Nombre { get; set; }
        [Required]
        public required string Ciudad { get; set; }
        [Required]
        public required string Pais { get; set; }
        public string? ImagenURL { get; set; }
        public string? Amenidad { get; set; }
    }
}
