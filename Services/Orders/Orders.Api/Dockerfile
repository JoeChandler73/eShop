FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["NuGet", "/NuGet"]
COPY ["Services/Orders/Orders.Api/Orders.Api.csproj", "Services/Orders/Orders.Api/"]
COPY ["Services/Orders/Orders.Application/Orders.Application.csproj", "Services/Orders/Orders.Application/"]
COPY ["Services/Orders/Orders.Domain/Orders.Domain.csproj", "Services/Orders/Orders.Domain/"]
COPY ["Infrastructure/Common.Logging/Common.Logging.csproj", "Infrastructure/Common.Logging/"]
COPY ["Infrastructure/Common.Configuration/Common.Configuration.csproj", "Infrastructure/Common.Configuration/"]
COPY ["Services/Orders/Orders.Infrastructure/Orders.Infrastructure.csproj", "Services/Orders/Orders.Infrastructure/"]
RUN dotnet nuget add source "/NuGet"
RUN dotnet restore "Services/Orders/Orders.Api/Orders.Api.csproj"
COPY . .
WORKDIR "/src/Services/Orders/Orders.Api"
RUN dotnet build "./Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Orders.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.Api.dll"]
