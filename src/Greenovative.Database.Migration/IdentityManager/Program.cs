using Greenovative.Identity.Infrastructure.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationIdentityDbContext>();

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}