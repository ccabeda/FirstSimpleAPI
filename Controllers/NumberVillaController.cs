using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository.IRepository;
using System.Net;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")] //PASO 2) Controlador de el endpoint. 
    [ApiController]
    public class NumberVillaController : ControllerBase
    {
        //creamos logger.
        private readonly ILogger<NumberVillaController> _logger; //readonly unicamente para que se lea y no se cambie
        private readonly IVillageRepository _villaRepositorio; //traemos el contexto a los controladores para usar con la base de datos
        private readonly INumberVillageRepository _numberVillaRepositorio;
        private readonly IMapper _mapper; // traemos el mapper para utilizar aqui 
        protected APIResponse _apiResponse;
        public NumberVillaController(ILogger<NumberVillaController> logger, IVillageRepository villaRepositorio, INumberVillageRepository numberVillaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _villaRepositorio = villaRepositorio;
            _numberVillaRepositorio = numberVillaRepositorio;
            _mapper = mapper;
            _apiResponse = new();
        }

        //Agregar a los metodos asincronia con async task<> y delante de los metodos el await

        [HttpGet]//es una operacion GET
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200

        public async Task <ActionResult <APIResponse>> GetNumberVillas() //Queremos que nos devuelva una lista de las villas
                                                                //ActionResult = para retornar el estado de codigo (404 not found, 200 ok, etc)
        {
            try
            {
                _logger.LogInformation("Lista de todas las habitaciones disponibles."); //logger de información
                IEnumerable<NumberVilla> lista_habitaciones = await _numberVillaRepositorio.ObtenerTodos();  //cargo la lista de villas
                _apiResponse.Result = _mapper.Map<IEnumerable<NumberVillaDto>>(lista_habitaciones); //almaceno el resultado en el APIResponse
                _apiResponse.statusCode = HttpStatusCode.OK; //Almacenamos el estado del code (este caso Ok)
                return Ok(_apiResponse); //seria como hacer (select * from villas). mapeo la lista a villaDTO
            }

            catch (Exception ex) //si ocurre un error
            {
                _logger.LogError("Ocurrió un error al obtener la lista de villas: " + ex.Message);
                _apiResponse.isExit = false; 
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        [HttpGet("id", Name = "GetNumberVilla")] //otra peticion GET, agregamos el id para cambiarle la ruta. Ponemos nombre para el POST. 
        //Documentar estado de codigos: 
        [ProducesResponseType(StatusCodes.Status200OK)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404

        public async Task<ActionResult <APIResponse>> GetNumberVilla(int id) //buscamos una sola villa por id
        {
            try //manejo de excepciones 
            {
                if (id == 0)
                {
                    _logger.LogError("Error al trae el Number Villa " + id + "."); //logger de error
                    _apiResponse.isExit=false; 
                    _apiResponse.statusCode = HttpStatusCode.BadRequest; //almacenamos el estado
                    return BadRequest(_apiResponse); //si el id ingresado es 0, nos dara el error              
                }
                var numberVillage = await _numberVillaRepositorio.Obtener(x => x.VillaNo == id); //que revise en la base de datos, y agarre la que ocntenga el mismo Id
                if (numberVillage == null)
                {
                    _logger.LogWarning("Error al trae el Number Villa  " + id + "."); //logger de warning
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse); //si el id que ingreso no esta (es null) que reciba not found
                }
                _logger.LogInformation("Información de las habitaciones de la villa solicitada.");
                _apiResponse.Result = _mapper.Map<NumberVillaDto>(numberVillage);
                _apiResponse.statusCode = HttpStatusCode.OK;
                return Ok(_apiResponse); //retornamos la villa mapeada a villadto
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al obtener la villa con ID: " + id + ". Detalles del error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        [HttpPost] //peticion POST, para agregar una village
        [ProducesResponseType(StatusCodes.Status201Created)] //documentamos el estado 200
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] //documentamos el estado 500

        public async Task <ActionResult<APIResponse>> NewNumberVillage([FromBody] NumberVillaCreateDto CreateNumbervillaDTO)
        {
            try
            {
                //validacion tradicional 
                if (!ModelState.IsValid) //al poner los [required] o [max.lenght] verificamos que se cumplan todos, sino error 400
                {
                    _logger.LogError("Error al ingresar los datos.");
                    return BadRequest(ModelState);
                }
                //validacion personalizada
                if (await _numberVillaRepositorio.Obtener(v => v.VillaNo == CreateNumbervillaDTO.VillaNo) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
                                                                                                                         //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
                {
                    ModelState.AddModelError("NameAlreadyExist.", "El número de villa ya esta registrado."); //creamos la validacion con su nombre y lo que queremos que aparezca
                    _logger.LogError("La villa que intenta ingresar ya esta registrada.");
                    return BadRequest(ModelState); //retornamos la validacion 
                }
                if (CreateNumbervillaDTO == null) //si la villa esta vacia retorna error 400
                {
                    _logger.LogWarning("Error al ingresar los datos.");
                    return BadRequest(CreateNumbervillaDTO);
                }
                //Villa modelo = new()              ***EN VEZ DE CREAR UNO X UNO LOS ATRIBUTOS ***
                //{ 
                //    Nombre = villa.Nombre,
                //    Ciudad = villa.Ciudad,
                //    Pais = villa.Pais,
                //    ImagenURL = villa.ImagenURL,
                //     Amenidad = villa.Amenidad
                //}; //creamos la villa

                NumberVilla modelo = _mapper.Map<NumberVilla>(CreateNumbervillaDTO); //mapeamos la villa a crear del dto enviado
                modelo.FechaDeCreación = DateTime.Now;
                modelo.FechaDeActualización = DateTime.Now;
                await _numberVillaRepositorio.Agregar(modelo); //la agregamos a la base de datos en la tabla correspondiente
                _apiResponse.Result = modelo;
                _apiResponse.statusCode = HttpStatusCode.Created;
                _logger.LogInformation("Agregando nueva villa...");
                return CreatedAtRoute("GetNumerVilla", new { id = modelo.VillaNo }, _apiResponse); //creamos la ruta para la nueva villa con el get anterior que recibia una id.
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al crear la villa: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        [HttpDelete("id", Name = "DeleteNumberVilla")] //damos como ruta la id del get primero. delete para borrrar
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public async Task <IActionResult> DeleteNumberVillage(int id)  //usamos la interfaz IActionResult para retornar Nocontent. Pedimos un ID para eliminar la village
        {
            try
            {
                if (id == 0) //si es cero badrequest
                {
                    _logger.LogError("Error al encontrar el Numero Villa " + id + "."); //logger de error
                    _apiResponse.isExit= false;
                    _apiResponse.statusCode= HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }
                var numberVilla = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id); //esto hace que, en la variable villa, se guarde el objeto que queremos eliminar unicamente si se encuentra en la db
                                                                              //si no se encuentra, guarda un null
                if (numberVilla == null)
                {
                    _logger.LogError("Los datos ingresados no coindicen con un numero villa registrada."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse);
                }
                await _numberVillaRepositorio.Eliminar(numberVilla); //borramos la villa de la db
                _logger.LogInformation("Numero Villa eliminada con exito.");
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return Ok(_apiResponse); //siempre en los DELETE retornar NoContent 
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar eliminar el numero villa: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return BadRequest(_apiResponse);

        }

        [HttpPut("id", Name = "UpdateNumberVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204
        [ProducesResponseType(StatusCodes.Status404NotFound)] //documentamos el estado 404

        public async Task <IActionResult> UpdateNumberVillage(int id, [FromBody] NumberVillaUpdateDto UpdateNumbervillaDTO)
        {
            try
            {
                if (UpdateNumbervillaDTO == null || id != UpdateNumbervillaDTO.VillaNo)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var numberVillage = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id, tracked: false); //buscamos si hay una villa con el mismo id en la db pero sin trackearla (**sin tracked:false NO FUNCIONA**)
                if (numberVillage == null)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_apiResponse); // Retorna NotFound si el ID no existe en la base de datos
                }
                // Si existe id a actualizar, mapeamos el modelo con los datos del villaDTO
                NumberVilla modelo = _mapper.Map<NumberVilla>(UpdateNumbervillaDTO);
                modelo.FechaDeActualización = DateTime.Now;
                await _numberVillaRepositorio.Actualizar(modelo); // Actualizamos la villa existente en el contexto
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar actualizar el numero villa: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return BadRequest(_apiResponse);
        }

        //ACLARACIÓN: Para hacer un Patch se necesita un NuGet

        [HttpPatch("id", Name = "PatchNumberVilla")] //creamos el patch
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //documentamos el estado 400
        [ProducesResponseType(StatusCodes.Status204NoContent)] //documentamos no content 204

        public async Task <IActionResult> PatchNumberVillage(int id, JsonPatchDocument<NumberVillaUpdateDto> patchNumbervillaDTO) //pedimos el id y el objeto en JSON con lo que quiere actualizar
        {
            try
            {
                if (patchNumbervillaDTO == null || id == 0) //verifico que la id no sea 0 o que el json sea null
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }
                var Numbervillage = await _numberVillaRepositorio.Obtener(v => v.VillaNo == id); //guardamos el objeto que queremos actualizar o un null
                if (Numbervillage == null) //si la id no esta registrada
                {
                    ModelState.AddModelError("IDNotExist.", "El ID del usuario que intenta actualizar no esta registrado en la lista."); //creamos la validacion con su nombre y lo que queremos que aparezca
                    return BadRequest(ModelState); //retornamos la validacion 
                }

                NumberVillaUpdateDto numberVillaDTO = _mapper.Map<NumberVillaUpdateDto>(Numbervillage); //pasamos de villa a villaDTO


                patchNumbervillaDTO.ApplyTo(numberVillaDTO, ModelState); //aplicamos los cambios del json al objeto
                if (!ModelState.IsValid) //si no es valido el modelo que siguio
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(numberVillaDTO, Numbervillage); //mapeo los datos del dto a la villa 
                Numbervillage.FechaDeActualización = DateTime.Now;
                await _numberVillaRepositorio.Actualizar(Numbervillage); //acutalizo y guardo
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar actualizar la villa de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return BadRequest(_apiResponse);
        }














    }
}
