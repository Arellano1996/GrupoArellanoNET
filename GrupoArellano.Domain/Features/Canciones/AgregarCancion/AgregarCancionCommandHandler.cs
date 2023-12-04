using GrupoArellano.Persistence.Repository;
using MediatR;

namespace GrupoArellano.Domain.Features.Canciones.AgregarCancion
{
  public class AgregarCancionCommandHandler : IRequestHandler<AgregarCancionCommand, AgregarCancionCommandResponse>
  {
    private readonly IAsyncRepository _repository;

    public AgregarCancionCommandHandler(IAsyncRepository repository)
    {
      _repository = repository;
    }

    public async Task<AgregarCancionCommandResponse> Handle(AgregarCancionCommand response, CancellationToken cancellationToken)
    {
      var agregarCancionCommandResponse = new AgregarCancionCommandResponse();

      var cancion = new Persistence.Entities.Cancion();

      cancion = response.cancion;

      await _repository.AddAsync(cancion);

      return agregarCancionCommandResponse;
    }

  }
}
