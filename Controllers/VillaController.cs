using Microsoft.AspNetCore.Http;
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
        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200

        public ActionResult <IEnumerable<VillaDto>> GetVillas() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
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
                return BadRequest(); //si el id ingresado es 0, nos dara el error             
            }
            var village = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id);// con la funcion LINQ y un lamda agarramos la villa con la id que ingrese
            if (village == null) 
            {
                return NotFound(); //si el id que ingreso no esta (es null) que reciba not found
            }
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
                return BadRequest(ModelState);
            } 
            //validacion personalizada
            if (Villa_Database.Database_Villa.FirstOrDefault(v => v.Nombre.ToUpper() == villa.Nombre.ToUpper()) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
             //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
            {
                ModelState.AddModelError("NameAlreadyExist.", "El nombre que intenta ingresar ya esta registrado."); //creamos la validacion con su nombre y lo que queremos que aparezca
                return BadRequest(ModelState); //retornamos la validacion 
            }
            if (villa == null) //si la villa esta vacia retorna error 400
            {
                return BadRequest(villa);
            }
            if (villa.Id < 0 || villa.Id > 0) //si se le quiso agregar id (se agrega solo) error 500 interno
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = Villa_Database.Database_Villa.OrderByDescending(v => v.Id).FirstOrDefault().Id+1; //obtenemos la id mas alta y le sumamos 1 para agregarla
            Villa_Database.Database_Villa.Add(villa); //la agregamos
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
        }

        [HttpDelete("id", Name = "DeleteVilla")] //damos como ruta la id del get primero
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public IActionResult DeleteVillage(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
            if(id ==0) //si es cero badrequest
            {
                return BadRequest();
            }
            var villa = Villa_Database.Database_Villa.FirstOrDefault(v => v.Id == id); //esto hace que, en la variable villa, se guarde el id del que queremos eliminar unicamente si se encuentra en la lista
            //si no se encuentra, guarda un null
            if (villa == null) 
            {
                return NotFound();            
            }
            Villa_Database.Database_Villa.Remove(villa); //removemos la villa indicada por el id
            return NoContent(); //siempre en los DELETE retornar NoContent 


        }













    }
}
