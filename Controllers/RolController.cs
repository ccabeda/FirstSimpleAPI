using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Service;
using MiPrimeraAPI.Service.IServices;
using System.Net;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")] //PASO 2) Controlador de el endpoint. 
    [ApiController]
    [Authorize(Roles = "3")] //SOLO EL SUPERADMIN PUEDE USAR ESTOS
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        //Agregar a los metodos asincronia con async task<> y delante de los metodos el await
        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        public async Task<ActionResult<APIResponse>> GetRoles() //Queremos que nos devuelva una lista de los usuarios
                                                                   //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
            var result = await _rolService.GetRoles();
            return Ok(result);
        }

        [HttpPost] //peticion POST, para agregar una rol
        [ProducesResponseType(StatusCodes.Status201Created)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> NewRol([FromBody] RolCreateDto CreateRolDTO)
        {
            var result = await _rolService.NewRol(CreateRolDTO);
            if (result.statusCode == HttpStatusCode.Created)
            {
                return Ok(result); //creamos la ruta para el nuevo usuario con el get anterior que recibia una id.
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete(("{id}"), Name = "DeleteRol")] //damos como ruta la id del get primero. delete para borrrar
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        public async Task<IActionResult> DeleteRol(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar el usuario
        {
            var result = await _rolService.DeleteRol(id);
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
    }
}
