using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")] //PASO 2) Controlador de el endpoint. 
    [ApiController]
    public class VillaController : ControllerBase
    {
        //creamos logger.
        private readonly ILogger<VillaController> _logger; //readonly unicamente para que se lea y no se cambie
        public VillaController(ILogger<VillaController> logger)
        {
            _logger = logger;
        }



        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200

        public ActionResult <IEnumerable<VillaDto>> GetVillas() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
            _logger.LogInformation("Lista de todas las villas disponibles."); //logger de información
            return Ok(Villa_Database.Database_Villa); //llamo a la "database". Aqui retornamos el estado Ok ya que es lo correcto 
        }

        [HttpGet("id", Name = "GetVilla")] //otra peticion GET, agregamos el id para cambiarle la ruta. Ponemos nombre para el POST. 
        //Documentar estado de codigos: 
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404

        public ActionResult <VillaDto> GetVilla(int id) //buscamos una sola villa por id
        {
            if (id == 0) 
            {
                _logger.LogError("No es posible encontrar la villa de id " + id + "."); //logger de error
                return BadRequest(); //si el id ingresado es 0, nos dara el error             
            }
            var village = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id);// con la funcion LINQ y un lamda agarramos la villa con la id que ingrese
            if (village == null) 
            {
                _logger.LogWarning("No es posible encontrar la villa de id " + id + "."); //logger de warning
                return NotFound(); //si el id que ingreso no esta (es null) que reciba not found
            }
            _logger.LogInformation("Información de la villa solicitada.");
            return Ok(village); //retornamos la villa 
        }

        [HttpPost] //peticion POST, para agregar una village
        [ProducesResponseType(StatusCodes.Status201Created)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //documentamos el estado 500

        public ActionResult<VillaDto> NewVillage([FromBody] VillaDto villa)
        {
            //validacion tradicional 
            if(!ModelState.IsValid) //al poner los [required] o [max.lenght] verificamos que se cumplan todos, sino error 400
            {
                _logger.LogError("Error al ingresar los datos.");
                return BadRequest(ModelState);
            } 
            //validacion personalizada
            if (Villa_Database.Database_Villa.FirstOrDefault(v => v.Nombre.ToUpper() == villa.Nombre.ToUpper()) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
             //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
            {
                ModelState.AddModelError("NameAlreadyExist.", "El nombre que intenta ingresar ya esta registrado."); //creamos la validacion con su nombre y lo que queremos que aparezca
                _logger.LogError("La villa que intenta ingresar ya esta registrada.");
                return BadRequest(ModelState); //retornamos la validacion 
            }
            if (villa == null) //si la villa esta vacia retorna error 400
            {
                _logger.LogError("Error al ingresar los datos.");
                return BadRequest(villa);
            }
            if (villa.Id < 0 || villa.Id > 0) //si se le quiso agregar id (se agrega solo) error 500 interno
            {
                _logger.LogError("Error al ingresar los datos.No debe elegir el campo ID.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = Villa_Database.Database_Villa.OrderByDescending(v => v.Id).FirstOrDefault().Id+1; //obtenemos la id mas alta y le sumamos 1 para agregarla
            Villa_Database.Database_Villa.Add(villa); //la
            _logger.LogInformation("Agregando nueva villa...");
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
        }

        [HttpDelete("id", Name = "DeleteVilla")] //damos como ruta la id del get primero. delete para borrrar
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public IActionResult DeleteVillage(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
            if(id ==0) //si es cero badrequest
            {
                _logger.LogError("No es posible encontrar la villa de id " + id + "."); //logger de error
                return BadRequest();
            }
            var villa = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id); //esto hace que, en la variable villa, se guarde el objeto que queremos eliminar unicamente si se encuentra en la lista
            //si no se encuentra, guarda un null
            if (villa == null) 
            {
                _logger.LogError("Los datos ingresados no coindicen con una villa registrada."); //logger de error
                return NotFound();            
            }
            Villa_Database.Database_Villa.Remove(villa); //removemos la villa indicada por el id
            _logger.LogInformation("Villa eliminada con exito.");
            return NoContent(); //siempre en los DELETE retornar NoContent 


        }

        [HttpPut("id", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public IActionResult UpdateVillage(int id, [FromBody] VillaDto villa)
        {
            if (villa == null || id != villa.Id) //id que nos pasa diferente al del body que queremos borrar
            {
                return BadRequest();
            }
            var village = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id); //guardamos el objeto que queremos actualizar o un null
            if (village == null) //si agregaron un id inexistente, hacemos una personalizada
            {
                ModelState.AddModelError("IDNotExist.", "El ID del usuario que intenta actualizar no esta registrado en la lista."); //creamos la validacion con su nombre y lo que queremos que aparezca
                return BadRequest(ModelState); //retornamos la validacion 
            }
            village.Nombre = villa.Nombre;
            village.Ciudad = villa.Ciudad;
            village.Pais = villa.Pais; 
            return NoContent();
        }

        //ACLARACIÓN: Para hacer un Patch se necesita un NuGet

        [HttpPatch("id", Name = "PatchVilla")] //creamos el patch
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public IActionResult PatchVillage(int id, JsonPatchDocument<VillaDto> villa) //pedimos el id y el objeto en JSON con lo que quiere actualizar
        {
            if (villa == null || id == 0) //verifico que la id no sea 0 o que el json sea null
            {
                return BadRequest();
            }
            var village = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id); //guardamos el objeto que queremos actualizar o un null
            if (village == null) //si la id no esta registrada
            {
                ModelState.AddModelError("IDNotExist.", "El ID del usuario que intenta actualizar no esta registrado en la lista."); //creamos la validacion con su nombre y lo que queremos que aparezca
                return BadRequest(ModelState); //retornamos la validacion 
            }
            villa.ApplyTo(village, ModelState); //aplicamos los cambios del json al objeto
            if (!ModelState.IsValid) //si no es valido el modelo que siguio
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }














    }
}
