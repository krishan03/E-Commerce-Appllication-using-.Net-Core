FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 61623
EXPOSE 44310

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY Service/Amcart.Web.API/Amcart.Web.API.csproj Service/Amcart.Web.API/
RUN dotnet restore Service/Amcart.Web.API/Amcart.Web.API.csproj
COPY . .
WORKDIR /src/Service/Amcart.Web.API
RUN dotnet build Amcart.Web.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Amcart.Web.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Amcart.Web.API.dll"]
