using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Data
{
    public static class Villa_Database //Simulando la base de datos, ya que no uso para el ejemplo
    {
        public  static List<VillaDto> Database_Villa = new List<VillaDto> //creo una lista de las villas
        {
            new VillaDto{Id = 1, Nombre= "Edificio en la ciudad", Ciudad= "Buenos Aires", Pais= "Argentina" },

            new VillaDto{Id = 2, Nombre= "Casa en la playa", Ciudad= "Ibiza", Pais= "España" },

            new VillaDto{Id = 3, Nombre= "Cabaña en las montañas", Ciudad= "Mendoza", Pais= "Argentina" },

            new VillaDto{Id = 4, Nombre= "Edificio en la ciudad", Ciudad= "Madrid", Pais= "España" },
        };
    }
}
