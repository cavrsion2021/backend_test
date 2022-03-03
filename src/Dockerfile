FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["WebUI/WebUI.csproj", "WebUI/"]
WORKDIR /app
COPY ["WebUI/Anagrama.Api.WebUI.xml", "./"]
COPY ["Application/Anagrama.Api.Application.xml", "./"]
WORKDIR /src
RUN dotnet restore "WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Anagrama.Api.WebUI.dll"]