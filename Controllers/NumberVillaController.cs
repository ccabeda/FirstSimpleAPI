using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Service;
using System.Net;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")] //PASO 2) Controlador de el endpoint. 
    [ApiController]
    public class NumberVillaController : ControllerBase
    {
        //creamos logger.
        private readonly INumberVillaService _numberVillaService;

        public NumberVillaController(ILogger<NumberVillaController> logger, INumberVillaService numberVillaService)
        {
            _numberVillaService = numberVillaService;
        }

        //Agregar a los metodos asincronia con async task<> y delante de los metodos el await

        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200

        public async Task <ActionResult <APIResponse>> GetNumberVillas() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
            var result = await _numberVillaService.GetNumberVillas();
            return Ok(result);
        }

        [HttpGet("id", Name = "GetNumberVilla")] //otra peticion GET, agregamos el id para cambiarle la ruta. Ponemos nombre para el POST. 
        //Documentar estado de codigos: 
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404

        public async Task<ActionResult <APIResponse>> GetNumberVilla(int id) //buscamos una sola villa por id
        {
            var result = await _numberVillaService.GetNumberVilla(id);
            if (result.statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            else if (result.statusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost] //peticion POST, para agregar una village
        [ProducesResponseType(StatusCodes.Status201Created)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //documentamos el estado 500

        public async Task <ActionResult<APIResponse>> NewNumberVillage([FromBody] NumberVillaCreateDto CreateNumberVillaDTO)
        {
            
            
                //validacion tradicional 
                if (!ModelState.IsValid) //al poner los [required] o [max.lenght] verificamos que se cumplan todos, sino error 400
                {
                ModelState.AddModelError("ModelIsNotValid.","El modelo del número de villa no es valido."); //creamos la validacion con su nombre y lo que queremos que aparezca
                return BadRequest(ModelState);
                }

                var result = await _numberVillaService.NewNumberVillage(CreateNumberVillaDTO);
                if (result.statusCode == HttpStatusCode.Created)
                {
                    return CreatedAtRoute("GetVilla", new { id = result.Result }, result); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
                }
                else
                {
                    return BadRequest(result);
                }
            }

        [HttpDelete("id", Name = "DeleteNumberVilla")] //damos como ruta la id del get primero. delete para borrrar
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public async Task <IActionResult> DeleteNumberVillage(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
            var result = await _numberVillaService.DeleteNumberVillage(id);
            if (result.statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            else if (result.statusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPut("id", Name = "UpdateNumberVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404

        public async Task <IActionResult> UpdateNumberVillage(int id, [FromBody] NumberVillaUpdateDto UpdateNumbervillaDTO)
        {
            var result = await _numberVillaService.UpdateNumberVillage(id, UpdateNumbervillaDTO);
            if (result.statusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            else if (result.statusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            else
            {
                return NoContent();
            }
        }

        //ACLARACIÓN: Para hacer un Patch se necesita un NuGet

        [HttpPatch("id", Name = "PatchNumberVilla")] //creamos el patch
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public async Task <IActionResult> PatchNumberVillage(int id, JsonPatchDocument<NumberVillaUpdateDto> patchNumberVillaDTO) //pedimos el id y el objeto en JSON con lo que quiere actualizar
        {
            var result = await _numberVillaService.PatchNumberVillage(id, patchNumberVillaDTO);
            if (result.statusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            else
            {
                return NoContent();
            }
        }














    }
}
