#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./Authentication.API/Authentication.API.csproj", "./Authentication.API/"]
RUN dotnet restore "./Authentication.API/Authentication.API.csproj"
COPY . .
WORKDIR "/src/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionStrings="Server=tcp:may2023hrm.database.windows.net,1433;Initial Catalog=AuthenticationDb;Persist Security Info=False;User ID=mayBatch;Password=Antra808Ax;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV angularURL="http://localhost:4200"
ENTRYPOINT ["dotnet", "Authentication.API.dll"]