using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GrupoArellano.Persistence.Repository;

namespace GrupoArellano.Persistence
{
  public static class PersistenceServiceRegistration
  {
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<GrupoArellanoDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("GrupoArellanoConnectionString")));

      //Puedes agregar aquí otros servicios de persistencia según tus necesidades
      services.AddScoped<IAsyncRepository, AsyncRepository>();
      
    }
  }
}
