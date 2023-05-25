#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0  AS base
WORKDIR /app

# Expose http & https server port
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV ASPNETCORE_HTTPS_PORT=443
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/cert.pem
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="travelcertification"

WORKDIR /src
COPY ["travel_back/travel_back.csproj", "travel_back/"]
RUN dotnet restore "travel_back/travel_back.csproj"
COPY . .
WORKDIR "/src/travel_back"
RUN dotnet build "travel_back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "travel_back.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY travel_back/app/combined.pfx /app/combined.pfx
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "travel_back.dll"]