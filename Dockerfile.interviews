#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Interviews/Interviews.API/Interviews.API.csproj", "Services/Interviews/Interviews.API/"]
COPY ["Services/Interviews/ApplicationCore/ApplicationCore.csproj", "Services/Interviews/ApplicationCore/"]
COPY ["Services/Interviews/Infrastructure/Infrastructure.csproj", "Services/Interviews/Infrastructure/"]
RUN dotnet restore "Services/Interviews/Interviews.API/Interviews.API.csproj"
COPY . .
WORKDIR "/src/Services/Interviews/Interviews.API"
RUN dotnet build "Interviews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interviews.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionStrings="Server=tcp:may2023hrm.database.windows.net,1433;Initial Catalog=InterviewsDb;Persist Security Info=False;User ID=mayBatch;Password=Antra808Ax;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENTRYPOINT ["dotnet", "Interviews.API.dll"]