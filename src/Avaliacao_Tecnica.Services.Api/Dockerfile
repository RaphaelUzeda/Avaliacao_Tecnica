#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Avaliacao_Tecnica.Services.Api/Avaliacao_Tecnica.Services.Api.csproj", "src/Avaliacao_Tecnica.Services.Api/"]
RUN dotnet restore "src/Avaliacao_Tecnica.Services.Api/Avaliacao_Tecnica.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/Avaliacao_Tecnica.Services.Api"
RUN dotnet build "Avaliacao_Tecnica.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Avaliacao_Tecnica.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avaliacao_Tecnica.Services.Api.dll"]
