using GrupoArellano.Persistence.Entities;
using MediatR;

namespace GrupoArellano.Domain.Features.Canciones.AgregarCancion
{
  public class AgregarCancionCommand : IRequest<AgregarCancionCommandResponse>
  {
    public Cancion cancion { get; set; }
  }
}
