FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env
WORKDIR /app

# Copy everything  and build
COPY . ./
RUN dotnet build
RUN dotnet publish -c Release -o out
RUN cp /app/WideWorldImporters.API/*.xml /app/WideWorldImporters.API/out/


# Build runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim 
WORKDIR /app
COPY --from=build-env /app/WideWorldImporters.API/out/ .
ENTRYPOINT ["dotnet", "WideWorldImporters.API.dll"]
