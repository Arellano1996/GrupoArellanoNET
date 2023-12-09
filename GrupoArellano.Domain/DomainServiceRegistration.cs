using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GrupoArellano.Domain
{
  public static class DomainServiceRegistration
  {
    public static IServiceCollection AddDomainServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
      return services;
    }
  }
}
