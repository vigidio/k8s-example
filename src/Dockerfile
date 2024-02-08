FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY example-api/*.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY example-api/ ./

# Build the app
RUN dotnet publish --no-restore -c Release -o out

# Use the official ASP.NET Core runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 80 (adjust if your app uses a different port)
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "example-api.dll"]