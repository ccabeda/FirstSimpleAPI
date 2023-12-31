using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Service
{
    public interface INumberVillaService
    {
        public Task<APIResponse> GetNumberVillas();
        public Task<APIResponse> GetNumberVilla(int id);
        public Task<APIResponse> NewNumberVillage([FromBody] NumberVillaCreateDto CreatevillaDTO);
        public Task<APIResponse> DeleteNumberVillage(int id);
        public Task<APIResponse> UpdateNumberVillage(int id, [FromBody] NumberVillaUpdateDto UpdatevillaDTO);
        public Task<APIResponse> PatchNumberVillage(int id, JsonPatchDocument<NumberVillaUpdateDto> patchVillaDTO);
    }
}