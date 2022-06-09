#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HealthyCook-Backend/HealthyCook-Backend.csproj", "HealthyCook-Backend/"]
RUN dotnet restore "HealthyCook-Backend/HealthyCook-Backend.csproj"
COPY . .
WORKDIR "/src/HealthyCook-Backend"
RUN dotnet build "HealthyCook-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthyCook-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "HealthyCook-Backend.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HealthyCook-Backend.dll
