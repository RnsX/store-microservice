#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InvoiceService/InvoiceServiceAPI.csproj", "InvoiceService/"]
COPY ["InvoiceServiceLib/InvoiceServiceLib.csproj", "InvoiceServiceLib/"]
COPY ["DataAccessLib/DataAccessLib.csproj", "DataAccessLib/"]
COPY ["DTO_InvoiceService/DTO_InvoiceService.csproj", "DTO_InvoiceService/"]
RUN dotnet restore "InvoiceService/InvoiceServiceAPI.csproj"
COPY . .
WORKDIR "/src/InvoiceService"
RUN dotnet build "InvoiceServiceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceServiceAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceServiceAPI.dll"]
