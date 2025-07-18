﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["NuGet", "/NuGet"]
COPY ["Services/Discount/Discount.Api/Discount.Api.csproj", "Services/Discount/Discount.Api/"]
COPY ["Services/Discount/Discount.Application/Discount.Application.csproj", "Services/Discount/Discount.Application/"]
COPY ["Services/Discount/Discount.Domain/Discount.Domain.csproj", "Services/Discount/Discount.Domain/"]
COPY ["Infrastructure/Common.Logging/Common.Logging.csproj", "Infrastructure/Common.Logging/"]
COPY ["Services/Discount/Discount.Infrastructure/Discount.Infrastructure.csproj", "Services/Discount/Discount.Infrastructure/"]
RUN dotnet nuget add source "/NuGet"
RUN dotnet restore "Services/Discount/Discount.Api/Discount.Api.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discount.Api"
RUN dotnet build "./Discount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Discount.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Api.dll"]
