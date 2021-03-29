#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Altamira.API/Altamira.API.csproj", "Altamira.API/"]
COPY ["Altamira.Entities/Altamira.Entities.csproj", "Altamira.Entities/"]
COPY ["Altamira.Bussiness/Altamira.Bussiness.csproj", "Altamira.Bussiness/"]
COPY ["Altamira.DataAccess/Altamira.DataAccess.csproj", "Altamira.DataAccess/"]
RUN dotnet restore "Altamira.API/Altamira.API.csproj"
COPY . .
WORKDIR "/src/Altamira.API"
RUN dotnet build "Altamira.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Altamira.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Altamira.API.dll"]