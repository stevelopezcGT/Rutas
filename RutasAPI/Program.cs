using Microsoft.EntityFrameworkCore;
using RutasAPI.Data;
using RutasAPI.Repositories.Implementacion;
using RutasAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Repository Interfaces*/
builder.Services.AddTransient<ICiudadesRepo, CiudadesRepo>();
builder.Services.AddTransient<IConductoresRepo, ConductoresRepo>();
builder.Services.AddTransient<IAutobusRepo, AutobusesRepo>();
builder.Services.AddTransient<IRutasRepo, RutasRepo>();
builder.Services.AddTransient<IAutobusRutaRepo, AutobusRutaRepo>();
builder.Services.AddTransient<IRecorridosRutaRepo, RecorridosRutasRepo>();

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
