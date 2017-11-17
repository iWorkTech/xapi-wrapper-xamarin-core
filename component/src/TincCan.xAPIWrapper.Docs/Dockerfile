FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ../TincCan.xAPIWrapper.Docs/TincCan.xAPIWrapper.Docs.csproj ../TincCan.xAPIWrapper.Docs/
COPY xAPIWrapper/xAPIWrapper.csproj xAPIWrapper/
COPY ../TinCan.Standard/TinCan.Standard.csproj ../TinCan.Standard/
RUN dotnet restore
COPY . .
WORKDIR /src/../TincCan.xAPIWrapper.Docs
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TincCan.xAPIWrapper.Docs.dll"]
