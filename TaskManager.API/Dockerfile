# Etapa 1: Build (Compilação)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia os arquivos de projeto (.csproj) e restaura as dependências
COPY ["TaskManager.API/TaskManager.API.csproj", "TaskManager.API/"]
COPY ["TaskManager.Application/TaskManager.Application.csproj", "TaskManager.Application/"]
COPY ["TaskManager/TaskManager.Domain.csproj", "TaskManager/"]
COPY ["TaskManager.Infrastructure/TaskManager.Infrastructure.csproj", "TaskManager.Infrastructure/"]
RUN dotnet restore "TaskManager.API/TaskManager.API.csproj"

# Copia o resto dos arquivos e compila
COPY . .
WORKDIR "/src/TaskManager.API"
RUN dotnet publish "TaskManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Runtime (Execução)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta 5000
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

# Comando para iniciar a API
ENTRYPOINT ["dotnet", "TaskManager.API.dll"]