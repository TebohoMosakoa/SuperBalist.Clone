#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/Order/Order.Api/Order.Api.csproj", "src/Services/Order/Order.Api/"]
COPY ["src/Services/Order/Order.Infrastructure/Order.Infrastructure.csproj", "src/Services/Order/Order.Infrastructure/"]
COPY ["src/Services/Order/Order.Application/Order.Application.csproj", "src/Services/Order/Order.Application/"]
COPY ["src/Services/Order/Order.Domain/Order.Domain.csproj", "src/Services/Order/Order.Domain/"]
RUN dotnet restore "src/Services/Order/Order.Api/Order.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Order/Order.Api"
RUN dotnet build "Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Api.dll"]
