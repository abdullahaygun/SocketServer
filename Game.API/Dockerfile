#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Game.API/Game.API.csproj", "Game.API/"]
RUN dotnet restore "Game.API/Game.API.csproj"
COPY . .
WORKDIR "/src/Game.API"
RUN dotnet build "Game.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Game.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Game.API.dll"]