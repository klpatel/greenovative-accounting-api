using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Handlers.Store;

public class AddNewStoreHandler : IRequestHandler<AddNewStoreRequest, AddNewStoreResponse>
{
    private readonly ILogger<AddNewStoreHandler> logger;
    private readonly IMapper mapper;
    private readonly IStoreRepository storeRepository;

    public AddNewStoreHandler(ILogger<AddNewStoreHandler> logger, IMapper mapper, IStoreRepository storeRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.storeRepository = storeRepository;
    }

    public async Task<AddNewStoreResponse> Handle(AddNewStoreRequest request, CancellationToken cancellationToken)
    {
        var store = mapper.Map<Infrastructure.Models.Store>(request.Store);
        storeRepository.Insert(store);

        return new AddNewStoreResponse();
    }

}

public class AddNewStoreRequest : IRequest<AddNewStoreResponse>
{
    public StoreViewModel Store { get; set; }
    public int UserId { get; set; }
}

public class AddNewStoreResponse
{

}
