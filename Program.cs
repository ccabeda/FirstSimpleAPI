using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiPrimeraAPI;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository;
using MiPrimeraAPI.Repository.IRepository;
using MiPrimeraAPI.Service;
using MiPrimeraAPI.Service.IServices;
using MiPrimeraAPI.Validations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(); //agregamos el NuGet para patch 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//configurar swagger para autentication, si usas postman no influye
builder.Services.AddSwaggerGen(c =>
{
    //Titulo y dise�o
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Village API", Version = "V2" });
    //boton de autorizaci�n
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
      }
    });
});
        
//PASO 3: "Mezclo" el contexto con las settings 

//Entity framework
builder.Services.AddDbContext<AplicationDbContext>(option => //Aqu� se establece c�mo el contexto de la base de datos se conectar� a la base de datos,
                                                             //qu� proveedor de base de datos se utilizar� y otra configuraci�n relacionada con la conexi�n.
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//automapper
builder.Services.AddAutoMapper(typeof(AutomapperConfig)); //PASO 2 AUTOMAPPER. Agregar la configuracion de la clase automapper al servicio.

//SCOPED: Se crean cada vez que se necesitan y se destruyen
//SINGLETON: Una vez que se crea una instancia se utiliza esa para siempre
//TRANSITED: Servicios transitorios. Se crean cada vez que se necesitan.

//Repositorios
builder.Services.AddScoped<IVillaRepository, VillaRepository>(); //agregamos al servicio tanto la interfaz como el repositorio de las villas 
builder.Services.AddScoped<INumberVillaRepository, NumberVillaRepository>(); //agregamos al servicio tanto la interfaz como el repositorio de las numbervillas
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();

//Validators villa
builder.Services.AddScoped<IValidator<VillaCreateDto>, VillaCreateValidator>();
builder.Services.AddScoped<IValidator<VillaUpdateDto>, VillaUpdateValidator>();
builder.Services.AddScoped<IValidator<UsuarioCreateDto>, UsuarioCreateValidator>();
builder.Services.AddScoped<IValidator<UsuarioUpdateDto>, UsuarioUpdateValidator>();

//services
builder.Services.AddScoped<IVillaService, VillaService>();
builder.Services.AddScoped<INumberVillaService, NumberVillaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolService, RolService>();

//APIResponse 
builder.Services.AddScoped<APIResponse>();

//Configuration TOKEN
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => //esquema de autenticaci�n
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters //parametros de validaci�n del token
    {
        ValidateIssuer = true, //validaci�n del emisor
        ValidateAudience = true, //validaci�n de la audicencia
        ValidateLifetime = true, //validaci�n del tiempo de vida
        ValidateIssuerSigningKey = true, //validaci�n de la clave de firma
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //establece el valor del emisor
        ValidAudience = builder.Configuration["Jwt:Audience"], //establece el valor de la audicncia
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) //establece el valor de la clave de firma
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //agregar para autentificaci�n con token.

app.UseAuthorization();

app.MapControllers();

app.Run();
