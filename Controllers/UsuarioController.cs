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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //Agregar a los metodos asincronia con async task<> y delante de los metodos el await
        [HttpGet]//es una operacion GET
        [Authorize(Roles = "Administrador")] //autorize para pedir token
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        public async Task <ActionResult <APIResponse>> GetUsuarios() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
             var result = await _usuarioService.GetUsuarios();
            return Ok(result); 
        }

        [HttpGet(("{id}"), Name = "GetUsuario")] //otra peticion GET, agregamos el id para cambiarle la ruta. Ponemos nombre para el POST.
        [Authorize(Roles = "Administrador")]
        //Documentar estado de codigos: 
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        public async Task<ActionResult <APIResponse>> GetUsuario(int id) //buscamos una sola villa por id
        {
            var result = await _usuarioService.GetUsuario(id);
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
        public async Task <ActionResult<APIResponse>> NewUsuario([FromBody] UsuarioCreateDto CreateUsuarioDTO)
        {
            var result = await _usuarioService.NewUsuario(CreateUsuarioDTO);
            if (result.statusCode == HttpStatusCode.Created)
            {
                return CreatedAtRoute("GetUsuario", new { id = result.Result }, result); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete(("{id}"), Name = "DeleteUsuario")] //damos como ruta la id del get primero. delete para borrrar
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        public async Task <IActionResult> DeleteUsuario(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
           var result = await _usuarioService.DeleteUsuario(id);
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

        [HttpPut(("{id}"), Name = "UpdateUsuario")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        public async Task <ActionResult<APIResponse>> UpdateUsuario(int id, [FromBody] UsuarioUpdateDto UpdateUsuarioDTO)
        {
             var result = await _usuarioService.UpdateUsuario(id, UpdateUsuarioDTO);
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
        [HttpPatch(("{id}"), Name = "PatchUsuario")] //creamos el patch
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        public async Task <IActionResult> PatchUsuario(int id, JsonPatchDocument<UsuarioUpdateDto> patchUsuarioDTO) //pedimos el id y el objeto en JSON con lo que quiere actualizar
        {
            var result = await _usuarioService.PatchUsuario(id, patchUsuarioDTO);
             if (result.statusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        public async Task<ActionResult<APIResponse>> LoginUsuario(UsuarioLoginDto usuario) //metodo para logearse
        {
            var result = await _usuarioService.LoginUsuario(usuario); //creo el token de logeo o null si falla
            if (result.statusCode == HttpStatusCode.BadRequest) 
            {
                return BadRequest(result);   
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
