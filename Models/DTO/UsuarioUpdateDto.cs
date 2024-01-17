namespace MiPrimeraAPI.Models.DTO
{
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Gmail { get; set; }
        public string Contraseña { get; set; }
    }
}
