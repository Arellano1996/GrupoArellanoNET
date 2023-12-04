using GrupoArellano.Domain.Features.Canciones.AgregarCancion;
using GrupoArellano.Persistence.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNetCoreWebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpPost]
    public async Task<string> AgregarCancion(AgregarCancionCommand command)
    {
      var cancion = new Cancion()
      {
        Id = Guid.NewGuid(),
        Nombre = "Diamantes",
        Artistas = new List<Artista>()
        {
          new Artista()
          {
            Id = Guid.NewGuid(),
            Nombre = "Natanael"
          }
        },
        Generos = new List<Genero>()
        {
          new Genero()
          {
            Id = Guid.NewGuid(),
            Nombre = "Corrido Tumbado"
          }
        },
        Acordes = "A",
        Letra = "Traigo la muñeca bien repleta de diamantes"
      };

      command.cancion = cancion;

      var model = await _mediator.Send(new AgregarCancionCommand { cancion = command.cancion });

      return "";
    }

  }
}
