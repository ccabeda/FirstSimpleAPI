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
        public Task<APIResponse> NewNumberVilla([FromBody] NumberVillaCreateDto CreatevillaDTO);
        public Task<APIResponse> DeleteNumberVilla(int id);
        public Task<APIResponse> UpdateNumberVilla(int id, [FromBody] NumberVillaUpdateDto UpdatevillaDTO);
        public Task<APIResponse> PatchNumberVilla(int id, JsonPatchDocument<NumberVillaUpdateDto> patchVillaDTO);
    }
}