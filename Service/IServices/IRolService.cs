using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Service
{
    public interface IRolService
    {
        public Task<APIResponse> GetRoles();
        public Task<APIResponse> NewRol([FromBody] RolCreateDto CreateRolDTO);
        public Task<APIResponse> DeleteRol(int id);
    }
}