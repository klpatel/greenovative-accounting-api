using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Models;
using Greenovative.Clients.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Handlers.RBAClient;

public class GetClientHandler : IRequestHandler<GetClientRequest, GetClientResponse>
{
    private readonly ILogger<GetClientHandler> logger;
    private readonly IMapper mapper;
    private readonly IClientRepository clientRepository;

    public GetClientHandler(ILogger<GetClientHandler> logger, IMapper mapper, IClientRepository clientRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.clientRepository = clientRepository;
    }

    public async Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
    {

        var client = clientRepository.Queryable().Where<Client>(x => x.Id == request.Id).FirstOrDefault();
        var clientVM = mapper.Map<RBAClientViewModel>(client);
        return new GetClientResponse() { RBAClient = clientVM };
    }

}

public class GetClientRequest : IRequest<GetClientResponse>
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
}

public class GetClientResponse
{
    public RBAClientViewModel RBAClient { get; set; }
}
