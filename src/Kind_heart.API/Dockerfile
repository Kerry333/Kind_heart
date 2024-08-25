FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Kind_heart.API/Kind_heart.API.csproj", "src/Kind_heart.API/"]
COPY ["src/Kind_heart.Application/Kind_heart.Application.csproj", "src/Kind_heart.Application/"]
COPY ["src/Kind_heart.Domain/Kind_heart.Domain.csproj", "src/Kind_heart.Domain/"]
COPY ["src/Kind_heart.Infrastructure/Kind_heart.Infrastructure.csproj", "src/Kind_heart.Infrastructure/"]
RUN dotnet restore "src/Kind_heart.API/Kind_heart.API.csproj"
COPY . .
WORKDIR "/src/src/Kind_heart.API"
RUN dotnet build "Kind_heart.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Kind_heart.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kind_heart.API.dll"]
