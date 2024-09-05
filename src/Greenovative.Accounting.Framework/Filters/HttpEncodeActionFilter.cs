using Microsoft.AspNetCore.Mvc.Filters;

namespace Greenovative.Accounting.Framework.Filters;

/// <summary>
/// Action Filter to sanitize Http requests
/// </summary>
public class HttpEncodeActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        ProcessHtmlEncoding(context);
        var resultContext = await next();
        // do something after the action executes; resultContext.Result will be set
    }

    private static void ProcessHtmlEncoding(ActionExecutingContext context)
    {
        context.ActionArguments.ToList().ForEach(arg => { arg.Value.ParseProperties(); });
    }

}
