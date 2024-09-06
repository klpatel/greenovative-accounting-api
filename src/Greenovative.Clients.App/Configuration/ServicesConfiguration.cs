using Greenovative.Accounting.Framework.Data;
using Greenovative.Clients.Infrastructure;
using Greenovative.Clients.Infrastructure.Repositories;
using LotoMate.Client.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Greenovative.Clients.App.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LottomateConnection");
        services.AddDbContext<ClientDbContext>(x => x.UseSqlServer(connectionString));

        //Inject UnitOfWork for an context
        services.AddScoped<IUnitOfWork<ClientDbContext>, UnitOfWork<ClientDbContext>>();

        //Continuous update :Inject all services and repositories here
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();
        services.AddScoped<IBusinessCategoryRepository, BusinessCategoryRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServicesConfiguration).GetTypeInfo().Assembly));

        return services;


    }
}
