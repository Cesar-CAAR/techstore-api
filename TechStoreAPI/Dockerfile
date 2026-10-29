# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TechStoreAPI.csproj", "./"]
RUN dotnet restore "TechStoreAPI.csproj"
COPY . .
RUN dotnet publish "TechStoreAPI.csproj" -c Release -o /app/publish

# Etapa 2: Servidor en la Nube
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Render requiere que expongamos un puerto. .NET 8 usa el 8080 en contenedores por defecto
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TechStoreAPI.dll"]