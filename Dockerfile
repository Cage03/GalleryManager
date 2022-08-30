FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GalleryManager.csproj", "./"]
RUN dotnet restore "GalleryManager.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "GalleryManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GalleryManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GalleryManager.dll"]
