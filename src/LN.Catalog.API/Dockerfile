# https://hub.docker.com/_/microsoft-dotnet

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./LN.Catalog.API.csproj src/LN.Catalog.API/
RUN dotnet restore "src/LN.Catalog.API/LN.Catalog.API.csproj"

# copy everything else and build app
COPY /. /src/LN.Catalog.API/
WORKDIR /src/LN.Catalog.API
RUN dotnet build ./LN.Catalog.API.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./LN.Catalog.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LN.Catalog.API.dll"]