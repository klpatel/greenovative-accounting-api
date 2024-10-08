# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Greenovative.Accounting.Api/Greenovative.Accounting.Api.csproj", "src/Greenovative.Accounting.Api/"]
COPY ["src/Greenovative.Clients.App/Greenovative.Clients.App.csproj", "src/Greenovative.Clients.App/"]
COPY ["src/Greenovative.Clients.Infrastructure/Greenovative.Clients.Infrastructure.csproj", "src/Greenovative.Clients.Infrastructure/"]
COPY ["src/Greenovative.Accounting.Framework/Greenovative.Accounting.Framework.csproj", "src/Greenovative.Accounting.Framework/"]
COPY ["src/Greenovative.Identity.App/Greenovative.Identity.App.csproj", "src/Greenovative.Identity.App/"]
COPY ["src/Greenovative.Identity.Infrastructure/Greenovative.Identity.Infrastructure.csproj", "src/Greenovative.Identity.Infrastructure/"]
RUN dotnet restore "./src/Greenovative.Accounting.Api/Greenovative.Accounting.Api.csproj"
COPY . .
WORKDIR "/src/src/Greenovative.Accounting.Api"
RUN dotnet build "./Greenovative.Accounting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Greenovative.Accounting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Greenovative.Accounting.Api.dll"]