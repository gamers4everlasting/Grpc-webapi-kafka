FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TradeScriptRunner/TradeScriptRunner.csproj", "TradeScriptRunner/"]
RUN dotnet restore "TradeScriptRunner/TradeScriptRunner.csproj"
COPY . .
WORKDIR "/src/TradeScriptRunner"
RUN dotnet build "TradeScriptRunner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradeScriptRunner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradeScriptRunner.dll"]
