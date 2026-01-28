FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Development
#Release
WORKDIR /src
COPY ["CBTW.API.Gateway/CBTW.API.Gateway.csproj", "CBTW.API.Gateway/"]
RUN dotnet restore "CBTW.API.Gateway/CBTW.API.Gateway.csproj"
COPY . .
WORKDIR "/src/CBTW.API.Gateway"
RUN dotnet build "./CBTW.API.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
#Release
RUN dotnet publish "./CBTW.API.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CBTW.API.Gateway.dll"]
