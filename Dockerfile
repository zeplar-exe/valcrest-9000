FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["valcrest-9000/valcrest-9000.csproj", "valcrest-9000/"]
RUN dotnet restore "valcrest-9000/valcrest-9000.csproj"
COPY . .
WORKDIR "/src/valcrest-9000"
RUN dotnet build "valcrest-9000.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "valcrest-9000.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "valcrest-9000.dll"]
