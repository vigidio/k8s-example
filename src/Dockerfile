# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the .csproj files and restore NuGet packages
COPY example-api/*.csproj ./
RUN dotnet restore

# Copy the entire project and build
COPY example-api/ ./
RUN dotnet build --no-self-contained -r linux-arm64
RUN dotnet publish --no-restore -c Release -o out -r linux-arm64

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0.1-jammy-arm64v8 AS final
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build-env /app/out .

# Expose the desired port
EXPOSE 5274

# Set the entry point for your application
ENTRYPOINT ["dotnet", "example-api.dll"]