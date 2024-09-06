using Microsoft.AspNetCore.Mvc;

namespace Greenovative.Accounting.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Route("[controller]")]
[ApiExplorerSettings(GroupName = "LotoMate.API")]

public class HomeController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly ILogger<HomeController> logger;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        this.configuration = configuration;
        this.logger = logger;
    }

    [HttpGet]
    public IEnumerable<GreenovativeInfo> Get()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new GreenovativeInfo
        {
            Date = DateTime.Now.AddDays(index),
            Message = "Welcome to LotoMate 2.0"
        })
        .ToArray();
    }

}