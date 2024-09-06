using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Models;
using Greenovative.Clients.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Handlers.RBAClient;

public class AddNewClientHandler : IRequestHandler<AddNewClientRequest, AddNewClientResponse>
{
    private readonly ILogger<AddNewClientHandler> logger;
    private readonly IMapper mapper;
    private readonly IClientRepository clientRepository;

    public AddNewClientHandler(ILogger<AddNewClientHandler> logger, IMapper mapper, IClientRepository clientRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.clientRepository = clientRepository;
    }

    public async Task<AddNewClientResponse> Handle(AddNewClientRequest request, CancellationToken cancellationToken)
    {
        var client = mapper.Map<Client>(request.Client);
        clientRepository.Insert(client);

        return new AddNewClientResponse();
    }

}

public class AddNewClientRequest : IRequest<AddNewClientResponse>
{
    public RBAClientViewModel Client { get; set; }
    public int UserId { get; set; }
}

public class AddNewClientResponse
{

}
