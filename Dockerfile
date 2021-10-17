FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src

COPY src/MerchandiseService/ MerchandiseService/

WORKDIR /src/MerchandiseService

RUN dotnet publish MerchandiseService.csproj -c Release -r linux-x64 -p:DebugType=None -p:DebugSymbols=false -p:PublishSingleFile=false --no-self-contained -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "MerchandiseService.dll"]
