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
        public Task<APIResponse> NewVillage([FromBody] VillaCreateDto CreatevillaDTO);
        public Task<APIResponse> DeleteVillage(int id);
        public Task<APIResponse> UpdateVillage(int id, [FromBody] VillaUpdateDto UpdatevillaDTO);
        public Task<APIResponse> PatchVillage(int id, JsonPatchDocument<VillaUpdateDto> patchVillaDTO);
    }
}
