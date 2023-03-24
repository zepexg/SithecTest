using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SithecBusiness.HumanoProcess;
using SithecBusiness.OperacionesProcess;
using SithecData;
using SithecData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HumanoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<HumanoBusiness>();
builder.Services.AddScoped<OperacionesBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Swagger Sithec Test",
            Version = "v1",
            Description = "Prueba tecnica para posicion Desarrollador Full Stack Sithec",
            Contact = new OpenApiContact
            {
                Name = "Pedro Guiusepe Vargas Medina",
                Email = "pvm.zpex@gmail.com"
            }
        });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<HumanoContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al crear la BD.");
    }
}

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
