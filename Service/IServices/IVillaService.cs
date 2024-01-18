using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Service
{
    public interface IVillaService
    {
        public Task<APIResponse> GetVillas();
        public Task<APIResponse> GetVilla(int id);
        public Task<APIResponse> NewVilla([FromBody] VillaCreateDto CreateVillaDTO);
        public Task<APIResponse> DeleteVilla(int id);
        public Task<APIResponse> UpdateVilla(int id, [FromBody] VillaUpdateDto UpdateVillaDTO);
        public Task<APIResponse> PatchVilla(int id, JsonPatchDocument<VillaUpdateDto> patchVillaDTO);
    }
}