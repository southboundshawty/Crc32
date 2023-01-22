FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Crc32.Integration.Tests/Crc32.Integration.Tests.csproj", "Crc32.Integration.Tests/"]
RUN dotnet restore "Crc32.Integration.Tests/Crc32.Integration.Tests.csproj"
COPY . .
WORKDIR "/src/Crc32.Integration.Tests"
RUN dotnet build "Crc32.Integration.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crc32.Integration.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crc32.Integration.Tests.dll"]
