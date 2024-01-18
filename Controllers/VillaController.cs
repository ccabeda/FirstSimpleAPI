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
    public class VillaController : ControllerBase
    {
        private readonly IVillaService _villaService;
        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        //Agregar a los metodos asincronia con async task<> y delante de los metodos el await
        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        public async Task <ActionResult <APIResponse>> GetVillas() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
             var result = await _villaService.GetVillas();
            return Ok(result); 
        }

        [HttpGet(("{id}"), Name = "GetVilla")] //otra peticion GET, agregamos el id para cambiarle la ruta. Ponemos nombre para el POST. 
        //Documentar estado de codigos: 
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        public async Task<ActionResult <APIResponse>> GetVilla(int id) //buscamos una sola villa por id
        {
            var result = await _villaService.GetVilla(id);
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

        [HttpPost()] //peticion POST, para agregar una village
        [ProducesResponseType(StatusCodes.Status201Created)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        public async Task <ActionResult<APIResponse>> NewVilla([FromBody] VillaCreateDto CreatevillaDTO)
        {
            var result = await _villaService.NewVilla(CreatevillaDTO);
            if (result.statusCode == HttpStatusCode.Created)
            {
                return CreatedAtRoute("GetVilla", new { id = result.Result }, result); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete(("{id}"), Name = "DeleteVilla")] //damos como ruta la id del get primero. delete para borrrar
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        public async Task <IActionResult> DeleteVilla(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
           var result = await _villaService.DeleteVilla(id);
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

        [HttpPut(("{id}"), Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        public async Task <ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDto UpdatevillaDTO)
        {
             var result = await _villaService.UpdateVilla(id, UpdatevillaDTO);
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
        [HttpPatch(("{id}"), Name = "PatchVilla")] //creamos el patch
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        public async Task <IActionResult> PatchVilla(int id, JsonPatchDocument<VillaUpdateDto> patchVillaDTO) //pedimos el id y el objeto en JSON con lo que quiere actualizar
        {
            var result = await _villaService.PatchVilla(id, patchVillaDTO);
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
