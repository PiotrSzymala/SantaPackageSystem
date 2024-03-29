FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SantaPackageSystem.csproj", "./"]
RUN dotnet restore "SantaPackageSystem.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SantaPackageSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SantaPackageSystem.csproj" -c Release -o /app/publish

# Kopiowanie pliku bazy danych SQLite do obrazu Docker
COPY app.db /app/


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SantaPackageSystem.dll"]
