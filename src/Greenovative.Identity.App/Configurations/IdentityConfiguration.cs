﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Greenovative.Identity.App.Extensions;
using Greenovative.Identity.Infrastructure;
using Greenovative.Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Greenovative.Identity.App.Configurations;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LotoMateConnection");
        services.AddDbContext<IdentityDbContext>(x => x.UseSqlServer(connectionString));

        var identity = services.AddIdentityCore<User>(opts => IdentityPolicy.BuildPasswordOptions());

        IdentityBuilder builder = new IdentityBuilder(identity.UserType, typeof(Role), identity.Services);
        builder.AddSignInManager<SignInManager<User>>();
        //TO DO : find out replacement for AddEntityFrameworkStores
        //builder.AddEntityFrameworkStores<IdentityDbContext>();
        builder.AddDefaultTokenProviders();
        builder.AddTokenProvider("LotoMate", typeof(DataProtectorTokenProvider<>).MakeGenericType(typeof(User)));
        builder.AddRoles<Role>();

        //remove default claims
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["Security:Tokens:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["Security:Tokens:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Security:Tokens:Key"])),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });

        return services;


    }
}
