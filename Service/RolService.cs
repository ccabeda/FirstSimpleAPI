using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository.IRepository;
using MiPrimeraAPI.Validations;
using System.Net;

namespace MiPrimeraAPI.Service
{
    public class RolService : IRolService
    {
        private readonly ILogger<RolService> _logger; //readonly unicamente para que se lea y no se cambie
        private readonly IRolRepository _rolRepositorio; //traemos el contexto a los controladores para usar con la base de datos
        private readonly IMapper _mapper; // traemos el mapper para utilizar aqui
        private readonly APIResponse _apiResponse; //el apirepsonse para que todos devuelvan lo mismo

        public RolService(ILogger<RolService> logger, IRolRepository rolRepositorio, IMapper mapper, APIResponse apiResponse)
        {
            _logger = logger;
            _rolRepositorio = rolRepositorio;
            _mapper = mapper;
            _apiResponse = apiResponse;
        }

        public async Task<APIResponse> DeleteRol(int id)
        {
            try
            {
                if (id == 0) //si es cero badrequest
                {
                    _logger.LogError("No es posible encontrar el rol de id " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var rol = await _rolRepositorio.Obtener(v => v.Id == id); //esto hace que, en la variable usuario, se guarde el objeto que queremos eliminar unicamente si se encuentra en la db
                                                                                  //si no se encuentra, guarda un null
                if (rol == null)
                {
                    _logger.LogError("Los datos ingresados no coindicen con un usuario registrado."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse;
                }
                await _rolRepositorio.Eliminar(rol); //borramos el usuario de la db
                _logger.LogInformation("Rol eliminado con exito.");
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse; //siempre en los DELETE retornar NoContent 
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar eliminar el rol de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> GetRoles()
        {
            try
            {
                _logger.LogInformation("Lista de todas los roles disponibles."); //logger de información
                IEnumerable<Rol> lista_roles = await _rolRepositorio.ObtenerTodos();  //cargo la lista de usuarios
                _apiResponse.Result = _mapper.Map<IEnumerable<RolDto>>(lista_roles); //almaceno el resultado en el APIResponse
                _apiResponse.statusCode = HttpStatusCode.OK; //Almacenamos el estado del code (este caso Ok)
                return (_apiResponse); //seria como hacer (select * from usuario). mapeo la lista a rolDTO
            }

            catch (Exception ex) //si ocurre un error
            {
                _logger.LogError("Ocurrió un error al obtener la lista de roles: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> NewRol([FromBody] RolCreateDto CreateRolDTO)
        {
            try
            {
                if (await _rolRepositorio.Obtener(v => v.Nombre.ToUpper() == CreateRolDTO.Nombre.ToUpper()) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
                                                                                                                                 //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
                {
                    _logger.LogError("El rol que intenta ingresar ya esta registrado.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                if (CreateRolDTO == null) //si el usuario esta vacia retorna error 400
                {
                    _logger.LogWarning("Error al ingresar los datos.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                Rol modelo = _mapper.Map<Rol>(CreateRolDTO); //mapeamos el usuario a crear del dto enviado
                modelo.FechaDeCreación = DateTime.Now;
                modelo.FechaDeActualización = DateTime.Now;
                await _rolRepositorio.Agregar(modelo); //la agregamos a la base de datos en la tabla correspondiente
                _apiResponse.Result = modelo.Id;
                _apiResponse.statusCode = HttpStatusCode.Created;
                _logger.LogInformation("Agregando nuevo rol...");
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al crear el rol: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }
    }
}
