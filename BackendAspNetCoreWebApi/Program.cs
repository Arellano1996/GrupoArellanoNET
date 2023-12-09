using GrupoArellano.Domain;
using GrupoArellano.Persistence;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<GrupoArellanoDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("GrupoArellanoConnectionString") ));

// Agregar la configuración de servicios de otras librerias
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddDomainServiceRegistration(builder.Configuration);


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

