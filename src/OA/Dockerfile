#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OA/OAWebAPI.csproj", "src/OA/"]
COPY ["src/OA.Infrastructure/OA.Prensentation.csproj", "src/OA.Infrastructure/"]
COPY ["src/OA.Service/OA.Service.csproj", "src/OA.Service/"]
COPY ["Contracts/OA.Contracts.csproj", "Contracts/"]
COPY ["src/OA.Domain/OA.Domain.csproj", "src/OA.Domain/"]
COPY ["src/OA.Persistence/OA.Persistence.csproj", "src/OA.Persistence/"]
COPY ["OA.Service.Abstraction/OA.Service.Abstraction.csproj", "OA.Service.Abstraction/"]
RUN dotnet restore "src/OA/OAWebAPI.csproj"
COPY . .
WORKDIR "/src/src/OA"
RUN dotnet build "OAWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OAWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OAWebAPI.dll"]