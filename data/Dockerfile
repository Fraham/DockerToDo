FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DataAccess/*.csproj ./DataAccess/
COPY DataAccess.Tests/*.csproj ./DataAccess.Tests/
RUN dotnet restore

# copy everything else and build app
COPY . .
#WORKDIR /app/aspnetapp
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DataAccess.dll"]