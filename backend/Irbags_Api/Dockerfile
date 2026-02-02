# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем только csproj для ускорения restore
COPY ["Irbags_Api/Irbags_Api.csproj", "Irbags_Api/"]
COPY ["Irbags.Core/Irbags.Core.csproj", "Irbags.Core/"]
COPY ["Irbags.Infrastructure/Irbags.Infrastructure.csproj", "Irbags.Infrastructure/"]
COPY ["Irbags.Application/Irbags.Application.csproj", "Irbags.Application/"]

RUN dotnet restore "Irbags_Api/Irbags_Api.csproj"

# Копируем всё остальное
COPY . .

RUN dotnet publish "Irbags_Api/Irbags_Api.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Irbags_Api.dll"]
