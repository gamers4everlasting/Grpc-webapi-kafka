FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GrpcService.Server/GrpcService.Server.csproj", "GrpcService.Server/"]
RUN dotnet restore "GrpcService.Server/GrpcService.Server.csproj"
COPY . .
WORKDIR "/src/GrpcService.Server"
RUN dotnet build "GrpcService.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcService.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcService.Server.dll"]
