namespace MiPrimeraAPI.Models.DTO
{
    public class UsuarioCreateDto
    {
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Gmail { get; set; }
        public string Contraseña { get; set; }
        //no poner rol ya que todos serán usuarios normales (podria hacer tabla RolUsuario pero no lo hare ya que es para practica)
    }
}
