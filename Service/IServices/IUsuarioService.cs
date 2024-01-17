using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Service.IServices
{
    public interface IUsuarioService
    {
        public Task<APIResponse> GetUsuarios();
        public Task<APIResponse> GetUsuario(int id);
        public Task<APIResponse> NewUsuario([FromBody] UsuarioCreateDto CreateUsuarioDTO);
        public Task<APIResponse> DeleteUsuario(int id);
        public Task<APIResponse> UpdateUsuario(int id, [FromBody] UsuarioUpdateDto UpdateUsuarioDTO);
        public Task<APIResponse> PatchUsuario(int id, JsonPatchDocument<UsuarioUpdateDto> patchUsuarioDTO);

        //metodo para generar token de autentificación
        public string GenerarTokendeLogin(Usuario usuario);
        public Task<APIResponse> LoginUsuario(UsuarioLoginDto usuario);
    }
}
