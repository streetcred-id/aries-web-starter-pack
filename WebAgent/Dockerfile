FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore "WebAgent.csproj" \
    -s "https://api.nuget.org/v3/index.json" \
    -s "https://www.myget.org/F/agent-framework/api/v3/index.json"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM streetcred/dotnet-indy:1.9.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://localhost:5000/
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebAgent.dll"]
