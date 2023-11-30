using GrupoArellano.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrupoArellano.Persistence
{
  public class GrupoArellanoDbContext : DbContext
  {
    public GrupoArellanoDbContext(DbContextOptions<GrupoArellanoDbContext> options) : base(options) { }

    public DbSet<Cancion> Canciones { get; set; }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Genero> Generos { get; set; }

  }

}
