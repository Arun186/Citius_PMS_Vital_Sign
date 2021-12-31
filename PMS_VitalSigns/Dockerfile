#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PMS_VitalSigns/PMS_VitalSigns.csproj", "PMS_VitalSigns/"]
RUN dotnet restore "PMS_VitalSigns/PMS_VitalSigns.csproj"
COPY . .
WORKDIR "/src/PMS_VitalSigns"
RUN dotnet build "PMS_VitalSigns.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PMS_VitalSigns.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PMS_VitalSigns.dll"]