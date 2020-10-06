FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./DotNETCoreIdentityPractice.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.8-buster-slim AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DotNETCoreIdentityPractice.dll"]
