namespace GrupoArellano.Persistence.Entities
{
  public class Cancion
  {
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Artista> Artista { get; set; }
    public ICollection<Genero> Genero { get; set; }
    public string Letra { get; set; }
    public string Acordes { get; set; }
    public ICollection<string> Link { get; set; }

  }
}
