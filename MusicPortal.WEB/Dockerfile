#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MusicPortal.WEB/MusicPortal.WEB.csproj", "MusicPortal.WEB/"]
COPY ["MusicPortal.BLL/MusicPortal.BLL.csproj", "MusicPortal.BLL/"]
COPY ["MusicPortal.DAL/MusicPortal.DAL.csproj", "MusicPortal.DAL/"]
RUN dotnet restore "MusicPortal.WEB/MusicPortal.WEB.csproj"
COPY . .
WORKDIR "/src/MusicPortal.WEB"
RUN dotnet build "MusicPortal.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicPortal.WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicPortal.WEB.dll"]