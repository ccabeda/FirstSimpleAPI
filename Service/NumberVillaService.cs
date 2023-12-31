using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository.IRepository;
using System.Net;

namespace MiPrimeraAPI.Service
{
    public class NumberVillaService : INumberVillaService
    {
        private readonly ILogger<NumberVillaService> _logger; //readonly unicamente para que se lea y no se cambie
        private readonly INumberVillageRepository _numberVillaRepositorio; //traemos el contexto a los controladores para usar con la base de datos
        private readonly IMapper _mapper; // traemos el mapper para utilizar aqui
        private readonly APIResponse _apiResponse; //el apirepsonse para que todos devuelvan lo mismo

        public NumberVillaService(ILogger<NumberVillaService> logger, INumberVillageRepository numberVillaRepositorio, IMapper mapper, APIResponse apiResponse)
        {
            _logger = logger;
            _numberVillaRepositorio = numberVillaRepositorio;
            _mapper = mapper;
            _apiResponse = apiResponse;
        }
        
        
        public async Task<APIResponse> DeleteNumberVillage(int id)
        {
            try
            {
                if (id == 0) //si es cero badrequest
                {
                    _logger.LogError("Error al encontrar el Numero Villa " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var numberVilla = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id); //esto hace que, en la variable villa, se guarde el objeto que queremos eliminar unicamente si se encuentra en la db
                                                                                               //si no se encuentra, guarda un null
                if (numberVilla == null)
                {
                    _logger.LogError("Los datos ingresados no coindicen con un numero villa registrada."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse;
                }
                await _numberVillaRepositorio.Eliminar(numberVilla); //borramos la villa de la db
                _logger.LogInformation("Numero Villa eliminada con exito.");
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse; //siempre en los DELETE retornar NoContent 
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar eliminar el numero villa: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> GetNumberVilla(int id)
        {
            try //manejo de excepciones 
            {
                if (id == 0)
                {
                    _logger.LogError("Error al trae el Number Villa " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest; //almacenamos el estado
                    return _apiResponse; //si el id ingresado es 0, nos dara el error              
                }
                var numberVillage = await _numberVillaRepositorio.Obtener(x => x.VillaNo == id); //que revise en la base de datos, y agarre la que ocntenga el mismo Id
                if (numberVillage == null)
                {
                    _logger.LogWarning("Error al trae el Number Villa  " + id + "."); //logger de warning
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; //si el id que ingreso no esta (es null) que reciba not found
                }
                _logger.LogInformation("Información de las habitaciones de la villa solicitada.");
                _apiResponse.Result = _mapper.Map<NumberVillaDto>(numberVillage);
                _apiResponse.statusCode = HttpStatusCode.OK;
                return _apiResponse; //retornamos la villa mapeada a villadto
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al obtener la villa con ID: " + id + ". Detalles del error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> GetNumberVillas()
        {
            try
            {
                _logger.LogInformation("Lista de todas las habitaciones disponibles."); //logger de información
                IEnumerable<NumberVilla> lista_habitaciones = await _numberVillaRepositorio.ObtenerTodos();  //cargo la lista de villas
                _apiResponse.Result = _mapper.Map<IEnumerable<NumberVillaDto>>(lista_habitaciones); //almaceno el resultado en el APIResponse
                _apiResponse.statusCode = HttpStatusCode.OK; //Almacenamos el estado del code (este caso Ok)
                return _apiResponse; //seria como hacer (select * from villas). mapeo la lista a villaDTO
            }

            catch (Exception ex) //si ocurre un error
            {
                _logger.LogError("Ocurrió un error al obtener la lista de villas: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> NewNumberVillage([FromBody] NumberVillaCreateDto CreateNumbervillaDTO)
        {

            if (await _numberVillaRepositorio.Obtener(v => v.VillaNo == CreateNumbervillaDTO.VillaNo) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
                                                                                                               //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
            {
                _logger.LogError("La villa que intenta ingresar ya esta registrada.");
                _apiResponse.isExit = false;
                _apiResponse.statusCode = HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            if (CreateNumbervillaDTO == null) //si la villa esta vacia retorna error 400
            {
                _logger.LogWarning("Error al ingresar los datos.");
                _apiResponse.isExit = false;
                _apiResponse.statusCode = HttpStatusCode.BadRequest;
                return _apiResponse; ;
            }
            NumberVilla modelo = _mapper.Map<NumberVilla>(CreateNumbervillaDTO); //mapeamos la villa a crear del dto enviado
            modelo.FechaDeCreación = DateTime.Now;
            modelo.FechaDeActualización = DateTime.Now;
            await _numberVillaRepositorio.Agregar(modelo); //la agregamos a la base de datos en la tabla correspondiente
            _apiResponse.Result = modelo.VillaNo;
            _apiResponse.statusCode = HttpStatusCode.Created;
            _logger.LogInformation("Agregando nueva villa...");
            return _apiResponse;
        }

        public async Task<APIResponse> PatchNumberVillage(int id, JsonPatchDocument<NumberVillaUpdateDto> patchNumberVillaDTO)
        {
            try
            {
                if (patchNumberVillaDTO == null || id == 0) //verifico que la id no sea 0 o que el json sea null
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var Numbervillage = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id); //guardamos el objeto que queremos actualizar o un null
                if (Numbervillage == null) //si la id no esta registrada
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                NumberVillaUpdateDto numberVillaDTO = _mapper.Map<NumberVillaUpdateDto>(Numbervillage); //pasamos de villa a villaDTO
                patchNumberVillaDTO.ApplyTo(numberVillaDTO); //aplicamos los cambios del json al objeto
                _mapper.Map(numberVillaDTO, Numbervillage); //mapeo los datos del dto a la villa 
                Numbervillage.FechaDeActualización = DateTime.Now;
                await _numberVillaRepositorio.Actualizar(Numbervillage); //acutalizo y guardo
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse;
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar actualizar la villa de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> UpdateNumberVillage(int id, [FromBody] NumberVillaUpdateDto UpdateNumberVillaDTO)
        {
            try
            {
                if (UpdateNumberVillaDTO == null || id != UpdateNumberVillaDTO.VillaNo)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }

                var numberVillage = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id, tracked: false); //buscamos si hay una villa con el mismo id en la db pero sin trackearla (**sin tracked:false NO FUNCIONA**)
                if (numberVillage == null)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; // Retorna NotFound si el ID no existe en la base de datos
                }
                // Si existe id a actualizar, mapeamos el modelo con los datos del villaDTO
                NumberVilla modelo = _mapper.Map<NumberVilla>(UpdateNumberVillaDTO);
                modelo.FechaDeActualización = DateTime.Now;
                await _numberVillaRepositorio.Actualizar(modelo); // Actualizamos la villa existente en el contexto
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse;
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar actualizar el numero villa: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }
    }
}
