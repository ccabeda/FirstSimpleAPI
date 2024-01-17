using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository.IRepository;
using System.Net;
using System.Security.Claims;

namespace MiPrimeraAPI.Service
{
    public class VillaService : IVillaService //pasamos toda la logica del conrtoler al service
    {

        private readonly ILogger<VillaService> _logger; //readonly unicamente para que se lea y no se cambie
        private readonly IVillageRepository _villaRepositorio; //traemos el contexto a los controladores para usar con la base de datos
        private readonly IMapper _mapper; // traemos el mapper para utilizar aqui
        private readonly APIResponse _apiResponse; //el apirepsonse para que todos devuelvan lo mismo
        private readonly IValidator<VillaCreateDto> _villaCreateValidator; //fluent validator
        private readonly IValidator<VillaUpdateDto> _villaUpdateValidator;


        public VillaService(ILogger<VillaService> logger, IVillageRepository villaRepositorio, IMapper mapper, APIResponse apiResponse, IValidator<VillaCreateDto> villaCreateValidator,
            IValidator<VillaUpdateDto> villaUpdateValidator)
        {
            _logger = logger;
            _villaRepositorio = villaRepositorio;
            _mapper = mapper;
            _apiResponse = apiResponse;
            _villaCreateValidator = villaCreateValidator;
            _villaUpdateValidator = villaUpdateValidator;

        }

        public async Task<APIResponse> GetVillas()
        {
            try
            {
                _logger.LogInformation("Lista de todas las villas disponibles."); //logger de información
                IEnumerable<Villa> lista_villas = await _villaRepositorio.ObtenerTodos();  //cargo la lista de villas
                _apiResponse.Result = _mapper.Map<IEnumerable<VillaDto>>(lista_villas); //almaceno el resultado en el APIResponse
                _apiResponse.statusCode = HttpStatusCode.OK; //Almacenamos el estado del code (este caso Ok)
                return (_apiResponse); //seria como hacer (select * from villas). mapeo la lista a villaDTO
            }

            catch (Exception ex) //si ocurre un error
            {
                _logger.LogError("Ocurrió un error al obtener la lista de villas: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }
        public async Task<APIResponse> DeleteVillage(int id)
        {
            try
            {
                if (id == 0) //si es cero badrequest
                {
                    _logger.LogError("No es posible encontrar la villa de id " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var villa = await _villaRepositorio.Obtener(v => v.Id == id); //esto hace que, en la variable villa, se guarde el objeto que queremos eliminar unicamente si se encuentra en la db
                                                                              //si no se encuentra, guarda un null
                if (villa == null)
                {
                    _logger.LogError("Los datos ingresados no coindicen con una villa registrada."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse;
                }
                await _villaRepositorio.Eliminar(villa); //borramos la villa de la db
                _logger.LogInformation("Villa eliminada con exito.");
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse; //siempre en los DELETE retornar NoContent 
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar eliminar la villa de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> GetVilla(int id)
        {
            try //manejo de excepciones 
            {
                if (id == 0)
                {
                    _logger.LogError("No es posible encontrar la villa de id " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest; //almacenamos el estado
                    return _apiResponse; //si el id ingresado es 0, nos dara el error              
                }
                var village = await _villaRepositorio.Obtener(x => x.Id == id); //que revise en la base de datos, y agarre la que ocntenga el mismo Id
                if (village == null)
                {
                    _logger.LogWarning("No es posible encontrar la villa de id " + id + "."); //logger de warning
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; //si el id que ingreso no esta (es null) que reciba not found
                }
                _logger.LogInformation("Información de la villa solicitada.");
                _apiResponse.Result = _mapper.Map<VillaDto>(village);
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

        public  async Task<APIResponse> NewVillage([FromBody] VillaCreateDto CreatevillaDTO)
        {
            try
            {
                var fluent_validation = await _villaCreateValidator.ValidateAsync(CreatevillaDTO); //uso de fluent validations

                if (!fluent_validation.IsValid)
                {
                    var errors = fluent_validation.Errors.Select(error => error.ErrorMessage).ToList();
                    _logger.LogError("Error al validar los datos de entrada.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _apiResponse.ErrorList = errors;
                    return _apiResponse;

                }
                if (await _villaRepositorio.Obtener(v => v.Nombre.ToUpper() == CreatevillaDTO.Nombre.ToUpper()) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
                                                                                                                         //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
                { 
                    _logger.LogError("La villa que intenta ingresar ya esta registrada.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;            
                    return _apiResponse;

                }
                if (CreatevillaDTO == null) //si la villa esta vacia retorna error 400
                {
                    _logger.LogWarning("Error al ingresar los datos.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                Villa modelo = _mapper.Map<Villa>(CreatevillaDTO); //mapeamos la villa a crear del dto enviado
                modelo.FechaDeCreación = DateTime.Now;
                modelo.FechaDeActualización = DateTime.Now;
                await _villaRepositorio.Agregar(modelo); //la agregamos a la base de datos en la tabla correspondiente
                _apiResponse.Result = modelo.Id;
                _apiResponse.statusCode = HttpStatusCode.Created;
                _logger.LogInformation("Agregando nueva villa...");
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al crear la villa: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }
    

        public async Task<APIResponse> PatchVillage(int id, JsonPatchDocument<VillaUpdateDto> patchVillaDTO)
        {
            try
            {
                if (patchVillaDTO == null || id == 0) //verifico que la id no sea 0 o que el json sea null
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var village = await _villaRepositorio.Obtener(v => v.Id == id); //guardamos el objeto que queremos actualizar o un null
                if (village == null) //si la id no esta registrada
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                VillaUpdateDto villaDTO = _mapper.Map<VillaUpdateDto>(village); //pasamos de villa a villaDTO
                patchVillaDTO.ApplyTo(villaDTO); //aplicamos los cambios del json al objeto
                _mapper.Map(villaDTO, village); //mapeo los datos del dto a la villa 
                village.FechaDeActualización = DateTime.Now;
                await _villaRepositorio.Actualizar(village); //acutalizo y guardo
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
    

        public async Task<APIResponse> UpdateVillage(int id, [FromBody] VillaUpdateDto UpdatevillaDTO)
        {
            try
            {
                var fluent_validation = await _villaUpdateValidator.ValidateAsync(UpdatevillaDTO); //uso de fluent validations

                if (!fluent_validation.IsValid)
                {
                    var errors = fluent_validation.Errors.Select(error => error.ErrorMessage).ToList();
                    _logger.LogError("Error al validar los datos de entrada.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _apiResponse.ErrorList = errors;
                    return _apiResponse;

                }
                if (id != UpdatevillaDTO.Id)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _logger.LogError("El ide no se encuentra registrado.");
                    return _apiResponse;
                }

                var village = await _villaRepositorio.Obtener(v => v.Id == id, tracked: false); //buscamos si hay una villa con el mismo id en la db pero sin trackearla (**sin tracked:false NO FUNCIONA**)
                if (village == null)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; // Retorna NotFound si el ID no existe en la base de datos
                }
                // Si existe id a actualizar, mapeamos el modelo con los datos del villaDTO
                Villa modelo = _mapper.Map<Villa>(UpdatevillaDTO);
                await _villaRepositorio.Actualizar(modelo); // Actualizamos la villa existente en el contexto
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

    }
}
