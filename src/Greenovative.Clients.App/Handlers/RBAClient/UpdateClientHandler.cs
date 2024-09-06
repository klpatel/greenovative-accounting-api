using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Models;
using Greenovative.Clients.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Handlers.RBAClient;

public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
{
    private readonly ILogger<UpdateClientHandler> logger;
    private readonly IMapper mapper;
    private readonly IClientRepository clientRepository;

    public UpdateClientHandler(ILogger<UpdateClientHandler> logger, IMapper mapper, IClientRepository clientRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.clientRepository = clientRepository;
    }

    public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var client = mapper.Map<Client>(request.Client);
        clientRepository.Update(client);

        return new UpdateClientResponse();
    }

}

public class UpdateClientRequest : IRequest<UpdateClientResponse>
{
    public RBAClientViewModel Client { get; set; }
    public int UserId { get; set; }
}

public class UpdateClientResponse
{

}
