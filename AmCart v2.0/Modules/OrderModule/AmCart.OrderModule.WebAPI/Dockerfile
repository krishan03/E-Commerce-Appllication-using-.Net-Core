FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 54489
EXPOSE 44322

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY Modules/OrderModule/AmCart.OrderModule.WebAPI/AmCart.OrderModule.WebAPI.csproj Modules/OrderModule/AmCart.OrderModule.WebAPI/
RUN dotnet restore Modules/OrderModule/AmCart.OrderModule.WebAPI/AmCart.OrderModule.WebAPI.csproj
COPY . .
WORKDIR /src/Modules/OrderModule/AmCart.OrderModule.WebAPI
RUN dotnet build AmCart.OrderModule.WebAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AmCart.OrderModule.WebAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AmCart.OrderModule.WebAPI.dll"]
