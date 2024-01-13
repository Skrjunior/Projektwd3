

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#FROM mcr.microsoft.com/dotnet/aspnet:7.0.15-alpine3.18-arm64v8 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjektWD3.csproj", "."]
RUN dotnet restore "./././ProjektWD3.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./ProjektWD3.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjektWD3.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjektWD3.dll"]