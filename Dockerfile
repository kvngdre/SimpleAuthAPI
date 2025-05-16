FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY *.sln .
COPY ["src/SimpleAuthAPI.API/SimpleAuthAPI.API.csproj", "./src/SimpleAuthAPI.API/"]
COPY ["src/SimpleAuthAPI.Application/SimpleAuthAPI.Application.csproj", "./src/SimpleAuthAPI.Application/"]
COPY ["src/SimpleAuthAPI.Domain/SimpleAuthAPI.Domain.csproj", "./src/SimpleAuthAPI.Domain/"]
COPY ["src/SimpleAuthAPI.Infrastructure/SimpleAuthAPI.Infrastructure.csproj", "./src/SimpleAuthAPI.Infrastructure/"]

RUN dotnet restore

COPY src/. ./src/
WORKDIR "/src/SimpleAuthAPI.API"
RUN dotnet build "SimpleAuthAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleAuthAPI.API.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleAuthAPI.API.dll"]