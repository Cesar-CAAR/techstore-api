# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["TechStoreAPI.csproj", "./"]
RUN dotnet restore "TechStoreAPI.csproj"
COPY . .
RUN dotnet publish "TechStoreAPI.csproj" -c Release -o /app/publish

# Etapa 2: Servidor en la Nube
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TechStoreAPI.dll"]