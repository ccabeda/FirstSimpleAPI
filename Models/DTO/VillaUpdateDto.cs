using System.ComponentModel.DataAnnotations;


namespace MiPrimeraAPI.Models.DTO
{   //Las clases DTO son para pasarle los atributos al controlador y que no tengan problemas con si hay atributos que no mostrar
    public class VillaUpdateDto
    {
        [Required] 
        public int Id { get; set; } //para actualizar si pedimos id, ya que debemos saber cual es el id a actualizar

        [MaxLength(32)] //maximo 32 caracteres de nombre
        public required string Nombre { get; set; }
      
        public required string Ciudad { get; set; }

        public required string Pais { get; set; }
        public string? ImagenURL { get; set; }
        public string? Amenidad { get; set; }
    }
}
