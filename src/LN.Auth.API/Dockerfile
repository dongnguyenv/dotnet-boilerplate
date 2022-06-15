#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./LN.Auth.API.csproj src/LN.Auth.API/
RUN dotnet restore "src/LN.Auth.API/LN.Auth.API.csproj"

# copy everything else and build app
COPY /. /src/LN.Auth.API
WORKDIR /src/LN.Auth.API
RUN dotnet build ./LN.Auth.API.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./LN.Auth.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LN.Auth.API.dll"]