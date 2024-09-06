using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure;
using Greenovative.Identity.Infrastructure.Repositories;
using Greenovative.Identity.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Greenovative.Identity.App.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("GreenovativeAccountingConnection");
        services.AddDbContext<ApplicationIdentityDbContext>(x => x.UseSqlServer(connectionString));

        //Inject UnitOfWork for an context
        services.AddScoped<IUnitOfWork<ApplicationIdentityDbContext>, UnitOfWork<ApplicationIdentityDbContext>>();

        //Identity services and repositories here
        services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IAspnetUserRepository, AspnetUserRepository>();

        //Client Service
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IUserClientRoleRepository, UserClientRoleRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServicesConfiguration).GetTypeInfo().Assembly));

        return services;

    }
}
