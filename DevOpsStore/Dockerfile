FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DevOpsStore/DevOpsStore.csproj", "DevOpsStore/"]
RUN dotnet restore "DevOpsStore/DevOpsStore.csproj"
COPY . .
WORKDIR "/src/DevOpsStore"
RUN dotnet build "DevOpsStore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DevOpsStore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevOpsStore.dll"]