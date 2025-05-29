FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Solutions/TreeStructure.API/TreeStructure.API.csproj", "TreeStructure.API/"]
COPY ["Solutions/TreeStructure.BLL/TreeStructure.BLL.csproj", "TreeStructure.BLL/"]
COPY ["Solutions/TreeStructure.Common/TreeStructure.Common.csproj", "TreeStructure.Common/"]
COPY ["Solutions/TreeStructure.DAL/TreeStructure.DAL.csproj", "TreeStructure.DAL/"]
RUN dotnet restore "TreeStructure.API/TreeStructure.API.csproj"
COPY . .
WORKDIR "/src/Solutions/TreeStructure.API"
RUN dotnet build "TreeStructure.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TreeStructure.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TreeStructure.API.dll"]