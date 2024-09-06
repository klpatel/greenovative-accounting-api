using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Handlers.Store;

public class UpdateStoreHandler : IRequestHandler<UpdateStoreRequest, UpdateStoreResponse>
{
    private readonly ILogger<UpdateStoreHandler> logger;
    private readonly IMapper mapper;
    private readonly IStoreRepository storeRepository;

    public UpdateStoreHandler(ILogger<UpdateStoreHandler> logger, IMapper mapper, IStoreRepository storeRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.storeRepository = storeRepository;
    }

    public async Task<UpdateStoreResponse> Handle(UpdateStoreRequest request, CancellationToken cancellationToken)
    {
        var store = mapper.Map<Infrastructure.Models.Store>(request.Store);
        storeRepository.Update(store);

        return new UpdateStoreResponse();
    }

}

public class UpdateStoreRequest : IRequest<UpdateStoreResponse>
{
    public StoreViewModel Store { get; set; }
    public int UserId { get; set; }
}

public class UpdateStoreResponse
{

}
