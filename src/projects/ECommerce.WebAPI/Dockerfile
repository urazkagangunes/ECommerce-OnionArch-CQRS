# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/projects/ECommerce.WebAPI/ECommerce.WebAPI.csproj", "src/projects/ECommerce.WebAPI/"]
COPY ["src/projects/ECommerce.Application/ECommerce.Application.csproj", "src/projects/ECommerce.Application/"]
COPY ["src/core/Core.Application/Core.Application.csproj", "src/core/Core.Application/"]
COPY ["src/core/Core.CrossCuttingConcers/Core.CrossCuttingConcerns.csproj", "src/core/Core.CrossCuttingConcers/"]
COPY ["src/core/Core.Security/Core.Security.csproj", "src/core/Core.Security/"]
COPY ["src/core/Core.Persistence/Core.Persistence.csproj", "src/core/Core.Persistence/"]
COPY ["src/projects/ECommerce.Domain/ECommerce.Domain.csproj", "src/projects/ECommerce.Domain/"]
COPY ["src/projects/ECommerce.Persistence/ECommerce.Persistence.csproj", "src/projects/ECommerce.Persistence/"]
RUN dotnet restore "./src/projects/ECommerce.WebAPI/ECommerce.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/projects/ECommerce.WebAPI"
RUN dotnet build "./ECommerce.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerce.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.WebAPI.dll"]