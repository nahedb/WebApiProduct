# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./bnahed.Api/bnahed.Api.csproj" --disable-parallel
RUN dotnet publish "./bnahed.Api/bnahed.Api.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "bnahed.Api.dll"]