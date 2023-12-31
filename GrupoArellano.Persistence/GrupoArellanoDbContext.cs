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
    public DbSet<LinkCancion> LinksCanciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Cancion>()
        //El método HasOne toma como argumento una expresión lambda que especifica la propiedad
        //de navegación en la entidad Cancion que representa esta relación.
        //.HasMany<Artista>(CancionSeRelacionaAArtistaPorElCampo => CancionSeRelacionaAArtistaPorElCampo.Artistas)
        .HasMany(e => e.Artistas)
        .WithMany()
        .UsingEntity(j => j.ToTable("CancionArtista"));

      modelBuilder.Entity<Cancion>()
        .HasMany<Genero>(e => e.Generos)
        .WithMany()
        .UsingEntity(j => j.ToTable("CancionGenero")); ;

      modelBuilder.Entity<Cancion>()
        .HasMany<LinkCancion>(e => e.LinksCancion)
        .WithMany()
        .UsingEntity(j => j.ToTable("CancionLinkCancion")); ;

    }
  }

}
