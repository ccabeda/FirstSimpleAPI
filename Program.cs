using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(); //agregamos el NuGet para patch 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//PASO 3: "Mezclo" el contexto con las settings 

builder.Services.AddDbContext<AplicationDbContext>(option => //Aquí se establece cómo el contexto de la base de datos se conectará a la base de datos,
                                                             //qué proveedor de base de datos se utilizará y otra configuración relacionada con la conexión.
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
