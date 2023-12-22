using AutoMapper;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Villa, VillaDto>(); //CREAR AUTOMAPPERS PASO 1) Luego de instarlos los nugets, creamos los caminos de mapeos (idas y vueltas)
            CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap(); //ReverseMap hace lo mismo que lo de arriba , osea ida y vuelta
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            CreateMap<NumberVilla, NumberVillaDto>().ReverseMap();
            CreateMap<NumberVilla, NumberVillaCreateDto>().ReverseMap();
            CreateMap<NumberVilla, NumberVillaUpdateDto>().ReverseMap();
        }


    }
}
