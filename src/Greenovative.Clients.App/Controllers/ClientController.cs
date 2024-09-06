using Greenovative.Accounting.Framework.Authorisation;
using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.App.Handlers.RBAClient;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greenovative.Clients.App.Controllers;

[Authorize(Policy = AuthPolicy.UserAccess)]
public class ClientController : BaseController
{
    private readonly ILogger<ClientController> logger;
    private readonly IMediator mediator;
    private readonly IUnitOfWork<ClientDbContext> unitOfWork;

    public ClientController(ILogger<ClientController> logger, IMediator mediator, IUnitOfWork<ClientDbContext> unitOfWork) : base(logger)
    {
        this.logger = logger;
        this.mediator = mediator;
        this.unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RBAClientViewModel clientView)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            var client = await mediator.Send(new AddNewClientRequest() { Client = clientView });
            await unitOfWork.SaveChangesAsync();
            return Ok(client);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while adding Client Detail.");
            return HandleException(ex, "Insert");
        }
    }
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching Client Detail Id {Id}", id);
            return HandleException(ex, "Get");
        }
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] RBAClientViewModel clientView)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while updating Client Detail.");
            return HandleException(ex, "Update");
        }
    }
}
