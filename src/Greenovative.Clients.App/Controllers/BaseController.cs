using Greenovative.Accounting.Framework.Authorisation;
using Greenovative.Accounting.Framework.Enumerations;
using Greenovative.Accounting.Framework.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Greenovative.Clients.App.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = AuthPolicy.UserAccess)]
[ApiExplorerSettings(GroupName = "Greenovative.Clients.App")]
public class BaseController : ControllerBase
{
    private readonly ILogger logger;

    public int? UserId { get; set; }

    public BaseController(ILogger logger)
    {
        this.logger = logger;

        UserId = null;
        if (User != null)
            UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    protected ObjectResult StatusCodeActionResult(string message, int statusCode = 422)
    {
        logger.LogError(message);

        string output = JsonConvert.SerializeObject(new ErrorResponse(statusCode, message));
        return new ObjectResult(output) { StatusCode = statusCode };
    }

    protected ObjectResult HandleException(Exception exception, string action)
    {
        var message = exception.Message;
        logger.LogError(exception, message);

        if (!(exception is RecordNotFoundException || exception is DuplicateNameException
            || exception is InvalidParameterException || exception is RecordFoundException))
            message = "Error while performing requested action " + action + ". Please start over by refreshing page if you encounter the issue again.";

        string output = JsonConvert.SerializeObject(new ErrorResponse(422, message));
        return new ObjectResult(output) { StatusCode = 422 };
    }
}
