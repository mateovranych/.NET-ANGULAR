using CLASE_ORM.Context;
using CLASE_ORM.Interfaces;
using CLASE_ORM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>
    (options =>options.UseSqlServer( builder.Configuration.GetConnectionString("Con"))
);

builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Para empezar a usar el ORM EntityFrameworkCore.SqlServer, tienen que instalarlo desde el administrador de paquetes Nuget
// esta en Herramientas => Administrador de paquetes Nuget => Administrar paquetes Nuget.
//Son dos cosas es EntityFrameworkCore.SqlServer y EntityFrameworkCore.Tools.
//tiene que coincidir con la versión de .NET que eligieron, no instalen la 10 o superior si están usando en su propia solución la version 8.


app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
