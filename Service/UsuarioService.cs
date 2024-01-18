using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Repository.IRepository;
using MiPrimeraAPI.Service.IServices;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MiPrimeraAPI.Service
{
    public class UsuarioService : IUsuarioService 
    {
        private readonly ILogger<UsuarioService> _logger; //readonly unicamente para que se lea y no se cambie
        private readonly IUsuarioRepository _usuarioRepositorio; //traemos el contexto a los controladores para usar con la base de datos
        private readonly IMapper _mapper; // traemos el mapper para utilizar aqui
        private readonly APIResponse _apiResponse; //el apirepsonse para que todos devuelvan lo mismo
        private readonly IValidator<UsuarioCreateDto> _usuarioCreateValidator; //fluent validator
        private readonly IValidator<UsuarioUpdateDto> _usuarioUpdateValidator;
        private readonly IConfiguration _config; //para token

        public UsuarioService(ILogger<UsuarioService> logger, IUsuarioRepository usuarioRepositorio, IMapper mapper, APIResponse apiResponse, IValidator<UsuarioCreateDto> usuarioCreateValidator,
            IValidator<UsuarioUpdateDto> usuarioUpdateValidator, IConfiguration config)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
            _apiResponse = apiResponse;
            _usuarioCreateValidator = usuarioCreateValidator;
            _usuarioUpdateValidator = usuarioUpdateValidator;
            _config = config;
        }

        public async Task<APIResponse> GetUsuarios()
        {
            try
            {
                _logger.LogInformation("Lista de todas los Usuarios disponibles."); //logger de información
                IEnumerable<Usuario> lista_usuarios = await _usuarioRepositorio.ObtenerTodos();  //cargo la lista de usuarios
                _apiResponse.Result = _mapper.Map<IEnumerable<UsuarioDto>>(lista_usuarios); //almaceno el resultado en el APIResponse
                _apiResponse.statusCode = HttpStatusCode.OK; //Almacenamos el estado del code (este caso Ok)
                return (_apiResponse); //seria como hacer (select * from usuario). mapeo la lista a usuarioDTO
            }

            catch (Exception ex) //si ocurre un error
            {
                _logger.LogError("Ocurrió un error al obtener la lista de usuarios: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> DeleteUsuario(int id)
        {
            try
            {
                if (id == 0) //si es cero badrequest
                {
                    _logger.LogError("No es posible encontrar el usuario de id " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                var usuario = await _usuarioRepositorio.Obtener(v => v.Id == id); //esto hace que, en la variable usuario, se guarde el objeto que queremos eliminar unicamente si se encuentra en la db
                                                                                               //si no se encuentra, guarda un null
                if (usuario == null)
                {
                    _logger.LogError("Los datos ingresados no coindicen con un usuario registrado."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse;
                }
                await _usuarioRepositorio.Eliminar(usuario); //borramos el usuario de la db
                _logger.LogInformation("Usuario eliminado con exito.");
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse; //siempre en los DELETE retornar NoContent 
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar eliminar el usuario de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> GetUsuario(int id)
        {
            try //manejo de excepciones 
            {
                if (id == 0)
                {
                    _logger.LogError("No es posible encontrar el usuario de id " + id + "."); //logger de error
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest; //almacenamos el estado
                    return _apiResponse; //si el id ingresado es 0, nos dara el error              
                }
                var usuario = await _usuarioRepositorio.Obtener(x => x.Id == id); //que revise en la base de datos, y agarre la que ocntenga el mismo Id
                if (usuario == null)
                {
                    _logger.LogWarning("No es posible encontrar el usuario de id " + id + "."); //logger de warning
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; //si el id que ingreso no esta (es null) que reciba not found
                }
                _logger.LogInformation("Información del usuario solicitada.");
                _apiResponse.Result = _mapper.Map<UsuarioDto>(usuario);
                _apiResponse.statusCode = HttpStatusCode.OK;
                return _apiResponse; //retornamos el usuario mapeado a usuariodto
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al obtener el usuario de Id: " + id + ". Detalles del error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> NewUsuario([FromBody] UsuarioCreateDto CreateUsuarioDTO)
        {
            try
            {
                var fluent_validation = await _usuarioCreateValidator.ValidateAsync(CreateUsuarioDTO); //uso de fluent validations
                if (!fluent_validation.IsValid)
                {
                    var errors = fluent_validation.Errors.Select(error => error.ErrorMessage).ToList();
                    _logger.LogError("Error al validar los datos de entrada.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _apiResponse.ErrorList = errors;
                    return _apiResponse;
                }
                if (await _usuarioRepositorio.Obtener(v => v.UserName.ToUpper() == CreateUsuarioDTO.UserName.ToUpper()) != null) //buscamos en la base de datos si hay un nombre igual al ingresado.
                                                                                                           //si el resultado de la busqueda es !null, significa que encontro un nombre igual.
                {
                    _logger.LogError("El usuario que intenta ingresar ya esta registrado.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                if (CreateUsuarioDTO == null) //si el usuario esta vacia retorna error 400
                {
                    _logger.LogWarning("Error al ingresar los datos.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                Usuario modelo = _mapper.Map<Usuario>(CreateUsuarioDTO); //mapeamos el usuario a crear del dto enviado
                modelo.FechaDeCreación = DateTime.Now;
                modelo.FechaDeActualización = DateTime.Now;
                modelo.RolId = 2; //simepre se crean con Rol Usuario (sin permisos)
                await _usuarioRepositorio.Agregar(modelo); //la agregamos a la base de datos en la tabla correspondiente
                _apiResponse.Result = modelo.Id;
                _apiResponse.statusCode = HttpStatusCode.Created;
                _logger.LogInformation("Agregando nuevo usuario...");
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al crear el usuario: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; //retorno el _apiResponse
        }

        public async Task<APIResponse> PatchUsuario(int id, JsonPatchDocument<UsuarioUpdateDto> patchUsuarioDTO)
        {
            try
            {
                if (patchUsuarioDTO == null || id == 0) //verifico que la id no sea 0 o que el json sea null
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                Usuario usuario = await _usuarioRepositorio.Obtener(v => v.Id == id); //guardamos el objeto que queremos actualizar o un null
                if (usuario == null) //si la id no esta registrada
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                UsuarioUpdateDto UsuarioDTO = _mapper.Map<UsuarioUpdateDto>(usuario); //pasamos de usuario a usuarioDto
                patchUsuarioDTO.ApplyTo(UsuarioDTO); //aplicamos los cambios del json al objeto
                _mapper.Map(UsuarioDTO, usuario); //mapeo los datos del dto a la usuario 
                usuario.FechaDeActualización = DateTime.Now;
                await _usuarioRepositorio.Actualizar(usuario); //acutalizo y guardo
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al intentar actualizar el usuario de Id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }

        public async Task<APIResponse> UpdateUsuario(int id, [FromBody] UsuarioUpdateDto UpdateUsuarioDTO)
        {
            try
            {
                var fluent_validation = await _usuarioUpdateValidator.ValidateAsync(UpdateUsuarioDTO); //uso de fluent validations

                if (!fluent_validation.IsValid)
                {
                    var errors = fluent_validation.Errors.Select(error => error.ErrorMessage).ToList();
                    _logger.LogError("Error al validar los datos de entrada.");
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _apiResponse.ErrorList = errors;
                    return _apiResponse;

                }
                if (id != UpdateUsuarioDTO.Id)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _logger.LogError("El ide no se encuentra registrado.");
                    return _apiResponse;
                }

                var usuario = await _usuarioRepositorio.Obtener(v => v.Id == id, tracked: false); //buscamos si hay una usuario con el mismo id en la db pero sin trackearla (**sin tracked:false NO FUNCIONA**)
                if (usuario == null)
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.NotFound;
                    return _apiResponse; // Retorna NotFound si el ID no existe en la base de datos
                }
                // Si existe id a actualizar, mapeamos el modelo con los datos del usuarioDTO
                Usuario modelo = _mapper.Map<Usuario>(UpdateUsuarioDTO);
                await _usuarioRepositorio.Actualizar(modelo); // Actualizamos la Usuario existente en el contexto
                _apiResponse.statusCode = HttpStatusCode.NoContent;
                return _apiResponse;
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error al intentar actualizar el usuario de id: " + id + ". Error: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse; 
        }

        public string GenerarTokendeLogin(Usuario usuario) //metodo para generar token
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); //creamos clave simetrica
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //creamos credenciales de firma
            //creamos las claims
            var claims = new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UserName),
                new Claim(ClaimTypes.Email, usuario.Gmail),
                new Claim(ClaimTypes.GivenName, usuario.Nombre),
                new Claim(ClaimTypes.Surname, usuario.Apellido),
                new Claim(ClaimTypes.Role, usuario.RolId.ToString()),
            };
            //creamos el token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credencial
                );
            return new JwtSecurityTokenHandler().WriteToken(token); //convertimos el token en string y retornamos
        }

        public async Task<APIResponse> LoginUsuario(UsuarioLoginDto usuario)
        {
            try
            {
                var user = await _usuarioRepositorio.Autenticar(usuario); //verifico si el usuario existe 
                if (user == null) //si es es null retorno
                {
                    _apiResponse.isExit = false;
                    _apiResponse.statusCode = HttpStatusCode.BadRequest;
                    _logger.LogInformation("usuario o contraseña incorrecta");
                    return _apiResponse;
                }
                var token = GenerarTokendeLogin(user); //sino creo el token
                _apiResponse.isExit = false;
                _apiResponse.statusCode = HttpStatusCode.OK;
                _apiResponse.token = token; //lo guardo en el api response
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error al intentar loguearse: " + ex.Message);
                _apiResponse.isExit = false;
                _apiResponse.ErrorList = new List<string> { ex.ToString() }; //creo una lista que almacene el error
            }
            return _apiResponse;
        }
    }
}

