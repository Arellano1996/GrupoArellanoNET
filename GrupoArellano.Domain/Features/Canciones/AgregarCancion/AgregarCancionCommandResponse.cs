using GrupoArellano.Persistence.Entities;
using GrupoArellano.Persistence.Responses;

namespace GrupoArellano.Domain.Features.Canciones.AgregarCancion
{
  public class AgregarCancionCommandResponse : BaseResponse
    {
    public AgregarCancionCommandResponse() : base()
    {
    }

    public Cancion cancion { get; set; }
    }
}
