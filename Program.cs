using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Models.DTO;
using MiPrimeraAPI.Repository;
using MiPrimeraAPI.Repository.IRepository;
using MiPrimeraAPI.Service;
using MiPrimeraAPI.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(); //agregamos el NuGet para patch 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<IVillageRepository, VillageRepository>(); //agregamos al servicio tanto la interfaz como el repositorio de las villas 
builder.Services.AddScoped<INumberVillageRepository, NumberVillageRepository>(); //agregamos al servicio tanto la interfaz como el repositorio de las numbervillas 

//Validators villa
builder.Services.AddScoped<IValidator<VillaCreateDto>, VillaCreateValidator>();
builder.Services.AddScoped<IValidator<VillaUpdateDto>, VillaUpdateValidator>();

//services
builder.Services.AddScoped<IVillaService, VillaService>();
builder.Services.AddScoped<INumberVillaService, NumberVillaService>();

builder.Services.AddScoped<APIResponse>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
