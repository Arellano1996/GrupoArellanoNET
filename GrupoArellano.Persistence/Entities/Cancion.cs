using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoArellano.Persistence.Entities
{
  public class Cancion
  {
    public Guid CancionId { get; set; }
    public string Nombre { get; set; }
    public string Letra { get; set; }
    public string Acordes { get; set; }
    public ICollection<LinkCancion> LinksCancion { get; set; }
    public virtual ICollection<Artista> Artistas { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }
  }
}
