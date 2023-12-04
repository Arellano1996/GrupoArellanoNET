using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoArellano.Persistence.Entities
{
  public class Artista
  {
    public Guid ArtistaId { get; set; }
    public string Nombre { get; set; }
  }
}
